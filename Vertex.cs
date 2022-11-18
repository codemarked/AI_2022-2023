using System;
using System.Drawing;

namespace AI_CURS1
{
    public class Vertex
    {
        int idx;
        public PointF mapLocation;

        public Vertex(int idx, PointF mapLocation)
        {
            this.idx = idx; 
            this.mapLocation = mapLocation; 
        }
        public Vertex(int idx)
        {
            this.idx = idx;
            this.mapLocation = new PointF(0,0);
        }

        public Vertex(Vertex v)
        {
            this.idx = v.idx;
            this.mapLocation = new PointF(v.mapLocation.X, v.mapLocation.Y);
        }


        public float distance(Vertex B)
        {
            return (float)Math.Sqrt((this.mapLocation.X - B.mapLocation.X) * (this.mapLocation.X - B.mapLocation.X) + (this.mapLocation.Y - B.mapLocation.Y) * (this.mapLocation.Y - B.mapLocation.Y));
        }

        public void Draw(Graphic handler)
        {
            handler.grp.DrawEllipse(Pens.Red, mapLocation.X - 7, mapLocation.Y - 7, 15, 15);
            handler.grp.DrawString($"{this.idx}", new Font("Arial", 20, FontStyle.Regular), new SolidBrush(Color.Black), this.mapLocation);
        }
    }
}
