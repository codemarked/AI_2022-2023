using System.Drawing;
using System.Collections.Generic;
using System;

namespace AI_CURS1
{
    public class AG
    {
        public int N;
        public List<Graph> pop;
        public List<Graph> par;
        public float zoom = 10;
        public int K;

        public AG()
        {
            this.pop = new List<Graph>();
            this.par = new List<Graph>();
        }



        public float fadec(Graph g)
        {
            float sum = 0;
            for (int i = 0; i < g.vertices.Count - 1; i++) 
                for (int j = i + 1; j < g.vertices.Count; j++) 
                {
                    if (g.matrice[i, j] != 0)
                    {
                        sum += (float)Math.Pow(g.vertices[i].distance(g.vertices[j]) - zoom * g.matrice[i,j], 2);
                    }
                }
            return sum;
        }

        public void sortPop()
        {
            this.pop.Sort(delegate (Graph A,Graph B)
            {
                return fadec(A).CompareTo(fadec(B));
            });
        }

        public void selectPop()
        {
            this.par.Clear();
            for (int i = 0; i < this.K; i++)
            {
                this.par.Add(new Graph(this.pop[i]));
            }
        }

        public Graph mutate(Graph g)
        {
            Graph tor = new Graph(g);
            int idx = Graph.random.Next(g.vertices.Count);
            PointF center = g.vertices[idx].mapLocation;
            float f = (float)Graph.random.NextDouble() * zoom;
            float alfa = (float)(Graph.random.NextDouble() * Math.PI * 2);
            float x = center.X + f * (float)Math.Cos(alfa);
            float y = center.Y + f * (float)Math.Sin(alfa);
            tor.vertices[idx].mapLocation.X = x;
            tor.vertices[idx].mapLocation.Y = y;
            return tor;
        }

        public void demo()
        {
            this.pop.Clear();
            for (int i = 0; i < N; i++)
            {
                this.pop.Add(mutate(this.par[Graph.random.Next(K)]));
            }
        }

        public void initPop(int N)
        {
            this.N = N;
            this.K = N / 15;
            for (int i = 0; i < N; i++)
            {
                Graph localG = new Graph(Engine.demo);
                localG.DispersionRND(new PointF(Graph.random.Next(Graphic.width), Graph.random.Next(Graphic.height)),100);
                this.pop.Add(localG);
            }
        }

        public void Draw(int idx, Graphic handler)
        {
            handler.ClearGraph();
            for (int i = 0; i < idx; i++)
            {
                this.pop[i].Draw(handler);
                PointF L = this.pop[i].vertices[0].mapLocation;
                string T = fadec(this.pop[i]).ToString("0.0000");
                Font f = new Font("Arial", 14, FontStyle.Bold);
                handler.grp.DrawString(T, f, new SolidBrush(Color.Red), L);
            }
            handler.RefreshGraph();
        }
    }
}
