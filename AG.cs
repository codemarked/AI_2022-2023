using System.Drawing;
using System.Collections.Generic;

namespace AI_CURS1
{
    public class AG
    {
        public int N;
        public List<Graph> pop;

        public AG()
        {
            this.pop = new List<Graph>();
        }

        public void initPop(int N)
        {
            this.N = N;
            for (int i = 0; i < N; i++)
            {
                Graph localG = new Graph(Engine.demo);
                localG.DispersionRND(new PointF(Graph.random.Next(Graphic.width), Graph.random.Next(Graphic.height)),100);
                pop.Add(localG);
            }
        }

        public void Draw(int idx, Graphic handler)
        {
            handler.ClearGraph();
            for (int i = 0; i < idx; i++)
            {
                pop[i].Draw(handler);
            }
            handler.RefreshGraph();
        }
    }
}
