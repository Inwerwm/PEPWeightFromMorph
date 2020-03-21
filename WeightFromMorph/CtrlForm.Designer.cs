namespace WeightFromMorph
{
    partial class CtrlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxVMorph = new System.Windows.Forms.ListBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.comboBoxParentBone = new System.Windows.Forms.ComboBox();
            this.checkBoxParentLimit = new System.Windows.Forms.CheckBox();
            this.groupBoxClustering = new System.Windows.Forms.GroupBox();
            this.radioButtonVecRL = new System.Windows.Forms.RadioButton();
            this.radioButtonPosRL = new System.Windows.Forms.RadioButton();
            this.radioButtonNone = new System.Windows.Forms.RadioButton();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.groupBoxRatio = new System.Windows.Forms.GroupBox();
            this.radioButtonRNorm = new System.Windows.Forms.RadioButton();
            this.radioButtonRX = new System.Windows.Forms.RadioButton();
            this.radioButtonRY = new System.Windows.Forms.RadioButton();
            this.radioButtonRZ = new System.Windows.Forms.RadioButton();
            this.labelParent = new System.Windows.Forms.Label();
            this.labelParentBoneDesc = new System.Windows.Forms.Label();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.labelThresholdDesc = new System.Windows.Forms.Label();
            this.radioButtonPosUB = new System.Windows.Forms.RadioButton();
            this.radioButtonVecUB = new System.Windows.Forms.RadioButton();
            this.radioButtonPosFB = new System.Windows.Forms.RadioButton();
            this.radioButtonVecFB = new System.Windows.Forms.RadioButton();
            this.groupBoxClustering.SuspendLayout();
            this.groupBoxRatio.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxVMorph
            // 
            this.listBoxVMorph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxVMorph.FormattingEnabled = true;
            this.listBoxVMorph.ItemHeight = 20;
            this.listBoxVMorph.Location = new System.Drawing.Point(16, 20);
            this.listBoxVMorph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxVMorph.Name = "listBoxVMorph";
            this.listBoxVMorph.Size = new System.Drawing.Size(159, 484);
            this.listBoxVMorph.TabIndex = 0;
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Location = new System.Drawing.Point(182, 407);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(430, 97);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // comboBoxParentBone
            // 
            this.comboBoxParentBone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxParentBone.FormattingEnabled = true;
            this.comboBoxParentBone.Location = new System.Drawing.Point(182, 43);
            this.comboBoxParentBone.Name = "comboBoxParentBone";
            this.comboBoxParentBone.Size = new System.Drawing.Size(249, 28);
            this.comboBoxParentBone.TabIndex = 3;
            // 
            // checkBoxParentLimit
            // 
            this.checkBoxParentLimit.AutoSize = true;
            this.checkBoxParentLimit.Location = new System.Drawing.Point(182, 83);
            this.checkBoxParentLimit.Name = "checkBoxParentLimit";
            this.checkBoxParentLimit.Size = new System.Drawing.Size(361, 24);
            this.checkBoxParentLimit.TabIndex = 4;
            this.checkBoxParentLimit.Text = "作成ボーンのウェイトを親ボーンのウェイト値までに制限する";
            this.checkBoxParentLimit.UseVisualStyleBackColor = true;
            // 
            // groupBoxClustering
            // 
            this.groupBoxClustering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxClustering.Controls.Add(this.radioButtonVecFB);
            this.groupBoxClustering.Controls.Add(this.radioButtonVecUB);
            this.groupBoxClustering.Controls.Add(this.radioButtonVecRL);
            this.groupBoxClustering.Controls.Add(this.radioButtonPosFB);
            this.groupBoxClustering.Controls.Add(this.radioButtonPosUB);
            this.groupBoxClustering.Controls.Add(this.radioButtonPosRL);
            this.groupBoxClustering.Controls.Add(this.radioButtonNone);
            this.groupBoxClustering.Location = new System.Drawing.Point(182, 142);
            this.groupBoxClustering.Name = "groupBoxClustering";
            this.groupBoxClustering.Size = new System.Drawing.Size(430, 100);
            this.groupBoxClustering.TabIndex = 5;
            this.groupBoxClustering.TabStop = false;
            this.groupBoxClustering.Text = "クラスタリング";
            // 
            // radioButtonVecRL
            // 
            this.radioButtonVecRL.AutoSize = true;
            this.radioButtonVecRL.Location = new System.Drawing.Point(88, 56);
            this.radioButtonVecRL.Name = "radioButtonVecRL";
            this.radioButtonVecRL.Size = new System.Drawing.Size(99, 24);
            this.radioButtonVecRL.TabIndex = 1;
            this.radioButtonVecRL.Text = "移動の左右";
            this.radioButtonVecRL.UseVisualStyleBackColor = true;
            // 
            // radioButtonPosRL
            // 
            this.radioButtonPosRL.AutoSize = true;
            this.radioButtonPosRL.Location = new System.Drawing.Point(88, 26);
            this.radioButtonPosRL.Name = "radioButtonPosRL";
            this.radioButtonPosRL.Size = new System.Drawing.Size(99, 24);
            this.radioButtonPosRL.TabIndex = 1;
            this.radioButtonPosRL.Text = "位置の左右";
            this.radioButtonPosRL.UseVisualStyleBackColor = true;
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.AutoSize = true;
            this.radioButtonNone.Checked = true;
            this.radioButtonNone.Location = new System.Drawing.Point(6, 26);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(80, 24);
            this.radioButtonNone.TabIndex = 0;
            this.radioButtonNone.TabStop = true;
            this.radioButtonNone.Text = "行わない";
            this.radioButtonNone.UseVisualStyleBackColor = true;
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxThreshold.Location = new System.Drawing.Point(182, 374);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(430, 27);
            this.textBoxThreshold.TabIndex = 6;
            this.textBoxThreshold.Text = "1.0E-08";
            this.textBoxThreshold.TextChanged += new System.EventHandler(this.textBoxThreshold_TextChanged);
            // 
            // groupBoxRatio
            // 
            this.groupBoxRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRatio.Controls.Add(this.radioButtonRZ);
            this.groupBoxRatio.Controls.Add(this.radioButtonRY);
            this.groupBoxRatio.Controls.Add(this.radioButtonRX);
            this.groupBoxRatio.Controls.Add(this.radioButtonRNorm);
            this.groupBoxRatio.Location = new System.Drawing.Point(182, 248);
            this.groupBoxRatio.Name = "groupBoxRatio";
            this.groupBoxRatio.Size = new System.Drawing.Size(430, 100);
            this.groupBoxRatio.TabIndex = 7;
            this.groupBoxRatio.TabStop = false;
            this.groupBoxRatio.Text = "ウェイトに変換する移動量割合の算出法";
            // 
            // radioButtonRNorm
            // 
            this.radioButtonRNorm.AutoSize = true;
            this.radioButtonRNorm.Checked = true;
            this.radioButtonRNorm.Location = new System.Drawing.Point(7, 27);
            this.radioButtonRNorm.Name = "radioButtonRNorm";
            this.radioButtonRNorm.Size = new System.Drawing.Size(61, 24);
            this.radioButtonRNorm.TabIndex = 0;
            this.radioButtonRNorm.TabStop = true;
            this.radioButtonRNorm.Text = "ノルム";
            this.radioButtonRNorm.UseVisualStyleBackColor = true;
            // 
            // radioButtonRX
            // 
            this.radioButtonRX.AutoSize = true;
            this.radioButtonRX.Location = new System.Drawing.Point(74, 27);
            this.radioButtonRX.Name = "radioButtonRX";
            this.radioButtonRX.Size = new System.Drawing.Size(96, 24);
            this.radioButtonRX.TabIndex = 1;
            this.radioButtonRX.Text = "X軸移動量";
            this.radioButtonRX.UseVisualStyleBackColor = true;
            // 
            // radioButtonRY
            // 
            this.radioButtonRY.AutoSize = true;
            this.radioButtonRY.Location = new System.Drawing.Point(176, 27);
            this.radioButtonRY.Name = "radioButtonRY";
            this.radioButtonRY.Size = new System.Drawing.Size(95, 24);
            this.radioButtonRY.TabIndex = 1;
            this.radioButtonRY.Text = "Y軸移動量";
            this.radioButtonRY.UseVisualStyleBackColor = true;
            // 
            // radioButtonRZ
            // 
            this.radioButtonRZ.AutoSize = true;
            this.radioButtonRZ.Location = new System.Drawing.Point(277, 27);
            this.radioButtonRZ.Name = "radioButtonRZ";
            this.radioButtonRZ.Size = new System.Drawing.Size(96, 24);
            this.radioButtonRZ.TabIndex = 1;
            this.radioButtonRZ.Text = "Z軸移動量";
            this.radioButtonRZ.UseVisualStyleBackColor = true;
            // 
            // labelParent
            // 
            this.labelParent.AutoSize = true;
            this.labelParent.Location = new System.Drawing.Point(182, 20);
            this.labelParent.Name = "labelParent";
            this.labelParent.Size = new System.Drawing.Size(58, 20);
            this.labelParent.TabIndex = 8;
            this.labelParent.Text = "親ボーン";
            // 
            // labelParentBoneDesc
            // 
            this.labelParentBoneDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelParentBoneDesc.AutoSize = true;
            this.labelParentBoneDesc.Location = new System.Drawing.Point(437, 20);
            this.labelParentBoneDesc.Name = "labelParentBoneDesc";
            this.labelParentBoneDesc.Size = new System.Drawing.Size(175, 60);
            this.labelParentBoneDesc.TabIndex = 9;
            this.labelParentBoneDesc.Text = "選択するかは任意\r\n作成ボーンのウェイト値分\r\n親ボーンのウェイトを減算する";
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(178, 351);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(39, 20);
            this.labelThreshold.TabIndex = 10;
            this.labelThreshold.Text = "閾値";
            // 
            // labelThresholdDesc
            // 
            this.labelThresholdDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelThresholdDesc.AutoSize = true;
            this.labelThresholdDesc.Location = new System.Drawing.Point(288, 351);
            this.labelThresholdDesc.Name = "labelThresholdDesc";
            this.labelThresholdDesc.Size = new System.Drawing.Size(324, 20);
            this.labelThresholdDesc.TabIndex = 10;
            this.labelThresholdDesc.Text = "座標や移動量がこの数値以下であった場合0とみなす";
            this.labelThresholdDesc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // radioButtonPosUB
            // 
            this.radioButtonPosUB.AutoSize = true;
            this.radioButtonPosUB.Location = new System.Drawing.Point(193, 26);
            this.radioButtonPosUB.Name = "radioButtonPosUB";
            this.radioButtonPosUB.Size = new System.Drawing.Size(99, 24);
            this.radioButtonPosUB.TabIndex = 1;
            this.radioButtonPosUB.Text = "位置の上下";
            this.radioButtonPosUB.UseVisualStyleBackColor = true;
            // 
            // radioButtonVecUB
            // 
            this.radioButtonVecUB.AutoSize = true;
            this.radioButtonVecUB.Location = new System.Drawing.Point(193, 56);
            this.radioButtonVecUB.Name = "radioButtonVecUB";
            this.radioButtonVecUB.Size = new System.Drawing.Size(99, 24);
            this.radioButtonVecUB.TabIndex = 1;
            this.radioButtonVecUB.Text = "移動の上下";
            this.radioButtonVecUB.UseVisualStyleBackColor = true;
            // 
            // radioButtonPosFB
            // 
            this.radioButtonPosFB.AutoSize = true;
            this.radioButtonPosFB.Location = new System.Drawing.Point(298, 26);
            this.radioButtonPosFB.Name = "radioButtonPosFB";
            this.radioButtonPosFB.Size = new System.Drawing.Size(99, 24);
            this.radioButtonPosFB.TabIndex = 1;
            this.radioButtonPosFB.Text = "位置の前後";
            this.radioButtonPosFB.UseVisualStyleBackColor = true;
            // 
            // radioButtonVecFB
            // 
            this.radioButtonVecFB.AutoSize = true;
            this.radioButtonVecFB.Location = new System.Drawing.Point(298, 56);
            this.radioButtonVecFB.Name = "radioButtonVecFB";
            this.radioButtonVecFB.Size = new System.Drawing.Size(99, 24);
            this.radioButtonVecFB.TabIndex = 1;
            this.radioButtonVecFB.Text = "移動の前後";
            this.radioButtonVecFB.UseVisualStyleBackColor = true;
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 521);
            this.Controls.Add(this.labelThresholdDesc);
            this.Controls.Add(this.labelThreshold);
            this.Controls.Add(this.labelParentBoneDesc);
            this.Controls.Add(this.labelParent);
            this.Controls.Add(this.groupBoxRatio);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.groupBoxClustering);
            this.Controls.Add(this.checkBoxParentLimit);
            this.Controls.Add(this.comboBoxParentBone);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.listBoxVMorph);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 560);
            this.Name = "CtrlForm";
            this.Text = "CtrlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.groupBoxClustering.ResumeLayout(false);
            this.groupBoxClustering.PerformLayout();
            this.groupBoxRatio.ResumeLayout(false);
            this.groupBoxRatio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVMorph;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ComboBox comboBoxParentBone;
        private System.Windows.Forms.CheckBox checkBoxParentLimit;
        private System.Windows.Forms.GroupBox groupBoxClustering;
        private System.Windows.Forms.RadioButton radioButtonVecRL;
        private System.Windows.Forms.RadioButton radioButtonPosRL;
        private System.Windows.Forms.RadioButton radioButtonNone;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.GroupBox groupBoxRatio;
        private System.Windows.Forms.RadioButton radioButtonRNorm;
        private System.Windows.Forms.RadioButton radioButtonRX;
        private System.Windows.Forms.RadioButton radioButtonRZ;
        private System.Windows.Forms.RadioButton radioButtonRY;
        private System.Windows.Forms.RadioButton radioButtonVecFB;
        private System.Windows.Forms.RadioButton radioButtonVecUB;
        private System.Windows.Forms.RadioButton radioButtonPosFB;
        private System.Windows.Forms.RadioButton radioButtonPosUB;
        private System.Windows.Forms.Label labelParent;
        private System.Windows.Forms.Label labelParentBoneDesc;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.Label labelThresholdDesc;
    }
}