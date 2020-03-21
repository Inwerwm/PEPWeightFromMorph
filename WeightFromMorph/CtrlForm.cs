using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WeightFromMorph
{
    public partial class CtrlForm : Form
    {
        IPERunArgs args;
        IPXPmx pmx;

        float threshold;

        public CtrlForm(IPERunArgs input)
        {
            InitializeComponent();
            args = input;
            pmx = args.Host.Connector.Pmx.GetCurrentState();
            listBoxVMorph.Items.AddRange(pmx.Morph.Where(m => m.IsVertex).Select(m => m.Name).ToArray());
            threshold = 1.0E-08f;
            textBoxThreshold.Text = threshold.ToString("E");
            comboBoxParentBone.Items.AddRange(pmx.Bone.Select(b => b.Name).ToArray());
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        delegate float GetRatioDelegate(IPXVertexMorphOffset offset);
        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (listBoxVMorph.SelectedIndex < 0)
                throw new ArgumentException("モーフを選択してください。");

            var selectedMorph = pmx.Morph.ToList().Find(m => m.Name == (string)listBoxVMorph.SelectedItem);

            // クラスタリング
            var clusters = new List<List<IPXVertexMorphOffset>>();
            if (radioButtonPosRL.Checked)
                clusters.AddRange(divideByAxisX(selectedMorph.Offsets.Select(o => (IPXVertexMorphOffset)o).ToList()));
            else if (radioButtonVecRL.Checked)
                clusters.AddRange(clusteringByVecX(selectedMorph.Offsets.Select(o => (IPXVertexMorphOffset)o).ToList()));
            else
                clusters.Add(selectedMorph.Offsets.Select(o => (IPXVertexMorphOffset)o).ToList());

            // 各クラスタに対する処理ループ
            int count = 1;
            foreach (List<IPXVertexMorphOffset> s in clusters)
            {
                var weights = s.Select(o => Utility.GetWeights(o.Vertex)).ToList();
                if (weights.Any(w => w.Count > 3))
                    throw new ArgumentException(
                        "すでにBDEF4である頂点が含まれています。" + Environment.NewLine +
                        "全ての頂点をBDEF3以下にしてください。" + Environment.NewLine +
                        "もしくはBDEF4でも少なくとも1つのウェイトが0であるようにしてください。"
                    );

                // ボーン生成
                var bone = args.Host.Builder.Pmx.Bone();
                var parentBone = comboBoxParentBone.SelectedIndex < 0 ? null : pmx.Bone[comboBoxParentBone.SelectedIndex];
                bone.Name = selectedMorph.Name + count;
                bone.Parent = parentBone;
                bone.Position.X = s.Average(o => o.Vertex.Position.X);
                bone.Position.Y = s.Average(o => o.Vertex.Position.Y);
                bone.Position.Z = s.Average(o => o.Vertex.Position.Z);
                bone.IsTranslation = true;
                pmx.Bone.Add(bone);

                // 割合ウェイトの分母
                float denominator;
                // 割合ウェイト算出デリゲート
                GetRatioDelegate getRatio = delegate (IPXVertexMorphOffset offset) { throw new NotImplementedException("割合算出デリゲートが設定されていません。"); };

                // 割合ウェイトの算出法を設定
                if (radioButtonRNorm.Checked)
                {
                    denominator = s.Max(o => o.Offset.Length());
                    getRatio = delegate (IPXVertexMorphOffset offset) { return offset.Offset.Length() / denominator; };
                }
                if (radioButtonRX.Checked)
                {
                    denominator = s.Max(o => Math.Abs(o.Offset.X));
                    getRatio = delegate (IPXVertexMorphOffset offset) { return Math.Abs(offset.Offset.X) / denominator; };
                }
                if (radioButtonRY.Checked)
                {
                    denominator = s.Max(o => Math.Abs(o.Offset.Y));
                    getRatio = delegate (IPXVertexMorphOffset offset) { return Math.Abs(offset.Offset.Y) / denominator; };
                }
                if (radioButtonRZ.Checked)
                {
                    denominator = s.Max(o => Math.Abs(o.Offset.Z));
                    getRatio = delegate (IPXVertexMorphOffset offset) { return Math.Abs(offset.Offset.Z) / denominator; };
                }

                // 各頂点に対する処理ループ
                for (int i = 0; i < s.Count; i++)
                {
                    // 新ボーンの割合ウェイトを取得
                    var w = getRatio(s[i]);
                    var parentWeightID = weights[i].FindIndex(t => t.bone == parentBone);

                    // 親ボーンがなければそのまま
                    if (parentBone == null || parentWeightID < 0)
                    {
                        // オフセット割合ウェイトを保証して正規化
                        weights[i] = Utility.NormalizeWeights(weights[i], 1 - w);
                        weights[i].Add((bone, w));
                    }
                    // 親ボーンがあれば親ボーンのウェイトから新ボーンのウェイトを引く
                    else
                    {
                        weights[i] = Utility.NormalizeWeights(weights[i]);
                        //親ボーンのウェイトから新ボーンのウェイトを引く
                        float parentW = weights[i][parentWeightID].weight;
                        var parentWeight = weights[i][parentWeightID];
                        parentWeight.weight = parentW > w ? parentW - w : 0;

                        switch (checkBoxParentLimit.CheckState)
                        {
                            case CheckState.Checked:
                                // 新ボーンのウェイトの上限を親ボーンの値にする
                                weights[i][parentWeightID] = parentWeight;
                                weights[i].Add((bone, parentW > w ? w : parentW));
                                break;
                            case CheckState.Unchecked:
                                // オフセット割合ウェイトを保証して正規化
                                weights[i].Remove(parentWeight);
                                weights[i] = Utility.NormalizeWeights(weights[i], parentW > w ? 1 - parentW : 1 - w);
                                if (parentWeight.weight != 0)
                                    weights[i].Add(parentWeight);
                                weights[i].Add((bone, w));
                                break;
                        }
                    }

                    var v = s[i].Vertex;
                    Utility.SetVertexWeights(weights[i], ref v);
                    s[i].Vertex = v;
                }
                count++;
            }
            Utility.Update(args.Host.Connector, pmx);
            MessageBox.Show("完了");
        }

        private void textBoxThreshold_TextChanged(object sender, EventArgs e)
        {
            try
            {
                threshold = float.Parse(textBoxThreshold.Text);
            }
            catch (Exception)
            {
                textBoxThreshold.Text = threshold.ToString("E");
            }
        }
    }
}