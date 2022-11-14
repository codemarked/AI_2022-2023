using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AI_CURS1
{
    public class Edge
    {
        public int idxVertexStart;
        public int idxVertexEnd;
        public int cost;

        public Edge(int idxVertexStart, int idxVertexEnd, int cost)
        {
            this.idxVertexStart = idxVertexStart;
            this.idxVertexEnd = idxVertexEnd;
            this.cost = cost;
        }

        public Edge(Edge edge)
        {
            this.idxVertexStart = edge.idxVertexStart;
            this.idxVertexEnd = edge.idxVertexEnd;
            this.cost = edge.cost;
        }

        public void Draw(Graphic handler, List<Vertex> v)
        {
            PointF start = v[idxVertexStart].mapLocation;
            PointF end = v[idxVertexEnd].mapLocation;
            handler.grp.DrawLine(Pens.Black, start, end);
            PointF center = new PointF((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            handler.grp.DrawString($"{this.cost}",new Font("Arial",10,FontStyle.Regular)
                ,new SolidBrush(Color.Black), center);
        }


    }
}
