using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AI_CURS1
{
    public class Graph
    {
        public static Random random = new Random();
        public int[,] matrice;
        public List<Edge> edges;
        public List<Vertex> vertices;

        public Graph()
        {
            edges = new List<Edge>();
            vertices = new List<Vertex>();
        }

        public Graph(Graph g)
        {
            this.edges = new List<Edge>();
            this.vertices = new List<Vertex>();

            foreach (Vertex v in g.vertices)
                this.vertices.Add(new Vertex(v));
            foreach (Edge e in g.edges)
                this.edges.Add(new Edge(e));
        }

        public void Load(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            int n = int.Parse(load.ReadLine());
            this.matrice = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                Vertex localV = new Vertex(i);
                vertices.Add(localV);
            }
            string buffer;
            while((buffer = load.ReadLine()) != null)
            {
                string[] localS = buffer.Split(' ');
                int x = int.Parse(localS[0]);
                int y = int.Parse(localS[1]);
                int z = int.Parse(localS[2]);
                Edge localE = new Edge(x,y,z);
                edges.Add(localE);
                this.matrice[x, y] = z;
                this.matrice[y, x] = z;
            }
            load.Close();
        }

        public List<string> View()
        {
            List<string> ret = new List<string>();
            for (int i = 0; i < this.vertices.Count; i++) 
            {
                string buffer = "";
                for (int j = 0; j < this.vertices.Count; j++)
                    buffer += this.matrice[i, j] + " ";
                ret.Add(buffer);
            }
            return ret;
        }

        public void Dispersion(PointF center, float radius)
        {
            float fi = (float)(Math.PI * 2) / vertices.Count;
            for(int i = 0; i < vertices.Count; i++)
            {
                float x = center.X + radius * (float)Math.Cos(i * fi);
                float y = center.Y + radius * (float)Math.Sin(i * fi);
                vertices[i].mapLocation = new PointF(x, y);
            }
        }

        public void DispersionRND(PointF center, float radius)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                float fi = (float)(random.NextDouble() * (Math.PI * 2));
                float r = (float)(random.NextDouble() * radius);
                float x = center.X + r * (float)Math.Cos(fi);
                float y = center.Y + r * (float)Math.Sin(fi);
                vertices[i].mapLocation = new PointF(x, y);
            }
        }

        public void NrI(Graphic handler)
        {
            for (int i = 0; i < edges.Count - 1; i++) 
                for(int j = i + 1; j< edges.Count; j++)
                {
                    PointF S = myMath.Inters(vertices[edges[i].idxVertexStart].mapLocation, vertices[edges[i].idxVertexEnd].mapLocation, vertices[edges[j].idxVertexStart].mapLocation, vertices[edges[j].idxVertexEnd].mapLocation);            
                        try
                        {
                            handler.grp.DrawEllipse(Pens.Red, S.X - 5, S.Y - 5, 11, 11); 
                        }
                        catch
                        { };
                }
        }
        public void Draw(Graphic handler)
        {
            foreach(Vertex vertex in vertices)
            {
                vertex.Draw(handler);
            }
            foreach(Edge edge in edges)
            {
                edge.Draw(handler, vertices);
            }
        }
    }
}
