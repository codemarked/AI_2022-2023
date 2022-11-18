using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CURS1
{
    public static class Engine
    {

        public static Graph demo;

        public static float distance(Vertex A, Vertex B)
        {
            return (float)Math.Sqrt((A.mapLocation.X - B.mapLocation.X) * (A.mapLocation.X - B.mapLocation.X) + (A.mapLocation.Y - B.mapLocation.Y) * (A.mapLocation.Y - B.mapLocation.Y));
        }
    }
}
