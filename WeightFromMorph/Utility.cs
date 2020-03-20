﻿using PEPlugin;
using PEPlugin.Pmx;
using System.Collections.Generic;
using System.Linq;

namespace WeightFromMorph
{
    /// <summary>
    /// 便利メソッド集
    /// </summary>
    static class Utility
    {
        /// <summary>
        /// モデル・フォーム・ビューを一括更新する
        /// </summary>
        /// <param name="connector">ホストへのコネクタ</param>
        /// <param name="pmx">更新用プラグインPMX</param>
        /// <param name="option">更新対象</param>
        /// <param name="index">任意の対象Index</param>
        public static void Update(IPEConnector connector, IPXPmx pmx, PmxUpdateObject option = PmxUpdateObject.All, int index = -1)
        {
            connector.Pmx.Update(pmx, option, index);
            connector.Form.UpdateList(ConvUObjrct_DtoX(option));
            connector.View.PmxView.UpdateModel();
        }

        /// <summary>
        /// PmxUpdateObjectからPmd.UpdateObjectに変換する
        /// </summary>
        /// <param name="input">変換するPmxUpdateObject</param>
        /// <returns></returns>
        public static PEPlugin.Pmd.UpdateObject ConvUObjrct_DtoX(PmxUpdateObject input)
        {
            PEPlugin.Pmd.UpdateObject output;
            switch (input)
            {
                case PmxUpdateObject.None:
                    output = PEPlugin.Pmd.UpdateObject.None;
                    break;
                case PmxUpdateObject.All:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
                case PmxUpdateObject.Header:
                    output = PEPlugin.Pmd.UpdateObject.Header;
                    break;
                case PmxUpdateObject.ModelInfo:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
                case PmxUpdateObject.Vertex:
                    output = PEPlugin.Pmd.UpdateObject.Vertex;
                    break;
                case PmxUpdateObject.Face:
                    output = PEPlugin.Pmd.UpdateObject.Face;
                    break;
                case PmxUpdateObject.Material:
                    output = PEPlugin.Pmd.UpdateObject.Material;
                    break;
                case PmxUpdateObject.Bone:
                    output = PEPlugin.Pmd.UpdateObject.Bone;
                    break;
                case PmxUpdateObject.Morph:
                    output = PEPlugin.Pmd.UpdateObject.Morph;
                    break;
                case PmxUpdateObject.Node:
                    output = PEPlugin.Pmd.UpdateObject.Node;
                    break;
                case PmxUpdateObject.Body:
                    output = PEPlugin.Pmd.UpdateObject.Body;
                    break;
                case PmxUpdateObject.Joint:
                    output = PEPlugin.Pmd.UpdateObject.Joint;
                    break;
                case PmxUpdateObject.SoftBody:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
                default:
                    output = PEPlugin.Pmd.UpdateObject.All;
                    break;
            }

            return output;
        }

        /// <summary>
        /// 入力頂点のボーン・ウェイトをタプルリストに変換する
        /// </summary>
        /// <param name="vertex">入力頂点</param>
        /// <returns>(ボーン,ウェイト)のタプルリスト</returns>
        public static List<(IPXBone bone, float weight)> GetWeights(IPXVertex vertex)
        {
            var weights = new List<(IPXBone bone, float weight)>();
            weights.Add((vertex.Bone1, vertex.Weight1));
            weights.Add((vertex.Bone2, vertex.Weight2));
            weights.Add((vertex.Bone3, vertex.Weight3));
            weights.Add((vertex.Bone4, vertex.Weight4));
            weights.RemoveAll(w => w.bone == null);
            return weights;
        }

        /// <summary>
        /// タプルリストから頂点にボーン・ウェイト情報を正規化して格納する
        /// </summary>
        /// <param name="weights">(ボーン,ウェイト)タプルのリスト</param>
        /// <param name="vertex">格納する頂点</param>
        public static void SetVertexWeights(List<(IPXBone bone, float weight)> weights, ref IPXVertex vertex)
        {
            //正規化
            var weight = NormalizeWeights(weights);

            //頂点に入力
            vertex.Bone1 = weight[0].bone;
            vertex.Weight1 = weight[0].weight;
            if (weight.Count > 1)
            {
                vertex.Bone2 = weight[1].bone;
                vertex.Weight2 = weight[1].weight;
            }
            if (weight.Count > 2)
            {
                vertex.Bone3 = weight[2].bone;
                vertex.Weight3 = weight[2].weight;
            }
            if (weight.Count > 3)
            {
                vertex.Bone4 = weight[3].bone;
                vertex.Weight4 = weight[3].weight;
            }
        }

        /// <summary>
        /// ウェイトを正規化する
        /// </summary>
        /// <param name="weights">正規化する(ボーン,ウェイト)タプルのリスト</param>
        /// <returns>正規化された(ボーン,ウェイト)タプルのリスト</returns>
        public static List<(IPXBone bone, float weight)> NormalizeWeights(List<(IPXBone bone, float weight)> weights)
        {
            //weightを基準に降順でソート
            weights.Sort((v, w) => w.weight.CompareTo(v.weight));

            //大きい方から4つまでを残す
            weights.Take(4);

            //正規化
            var sum = weights.Select(w => w.weight).Sum();
            return weights.Select(w => (w.bone, w.weight / sum)).ToList();
        }

        /// <summary>
        /// ウェイトを正規化する
        /// </summary>
        /// <param name="vertex">正規化する頂点</param>
        public static void NormalizeWeights(ref IPXVertex vertex)
        {
            SetVertexWeights(GetWeights(vertex), ref vertex);
        }
    }
}
