using PEPlugin.Pmx;
using PEPlugin.SDX;
using SlimDX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeightFromMorph
{
    public partial class CtrlForm
    {
        public void ReLoad()
        {
            pmx = args.Host.Connector.Pmx.GetCurrentState();
            listBoxVMorph.Items.AddRange(pmx.Morph.Where(m => m.IsVertex).Select(m => m.Name).ToArray());
        }

        List<List<IPXVertexMorphOffset>> divideByAxisX(List<IPXVertexMorphOffset> source)
        {
            var clusters = new List<List<IPXVertexMorphOffset>>();

            clusters.Add(source.Where(o => filter(o.Vertex.Position.X) < 0).ToList());
            clusters.Add(source.Where(o => filter(o.Vertex.Position.X) > 0).ToList());

            return clusters;
        }

        List<List<IPXVertexMorphOffset>> divideByAxisY(List<IPXVertexMorphOffset> source)
        {
            var clusters = new List<List<IPXVertexMorphOffset>>();

            clusters.Add(source.Where(o => filter(o.Vertex.Position.Y) < 0).ToList());
            clusters.Add(source.Where(o => filter(o.Vertex.Position.Y) > 0).ToList());

            return clusters;
        }

        List<List<IPXVertexMorphOffset>> divideByAxisZ(List<IPXVertexMorphOffset> source)
        {
            var clusters = new List<List<IPXVertexMorphOffset>>();

            clusters.Add(source.Where(o => filter(o.Vertex.Position.Z) < 0).ToList());
            clusters.Add(source.Where(o => filter(o.Vertex.Position.Z) > 0).ToList());

            return clusters;
        }

        List<List<IPXVertexMorphOffset>> clusteringByVecX(List<IPXVertexMorphOffset> source)
        {
            var clusters = new List<List<IPXVertexMorphOffset>>();
            clusters.Add(new List<IPXVertexMorphOffset>());
            clusters.Add(new List<IPXVertexMorphOffset>());

            var vA = new V3(-1, 0, 0);
            var vB = new V3(1, 0, 0);

            foreach (IPXVertexMorphOffset offset in source)
            {
                var o = ToVector3ByThreshold(offset.Offset);

                var iA = Vector3.Dot(o, vA.ToVector3());
                var iB = Vector3.Dot(o, vB.ToVector3());

                if (iA > iB)
                    clusters[0].Add(offset);
                if (iA < iB)
                    clusters[1].Add(offset);
            }

            return clusters;
        }

        Vector3 ToVector3ByThreshold(V3 vec)
        {
            var v = vec.ToVector3();
            if (Math.Abs(v.X) < threshold)
                v.X = 0;
            if (Math.Abs(v.Y) < threshold)
                v.Y = 0;
            if (Math.Abs(v.Z) < threshold)
                v.Z = 0;
            return v;
        }

        float filter(float value)
        {
            return Math.Abs(value) < threshold ? 0 : value;
        }
    }
}
