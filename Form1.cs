using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_CURS1
{
    public partial class Form1 : Form
    {
        Graphic graphic;
        PointF A = new PointF(50, 400);
        PointF B = new PointF(300, 50);
        PointF C = new PointF(0, 0);
        PointF D = new PointF(450, 300);

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.demo = new Graph();
            Engine.demo.Load(@"..\..\demo.in");
            graphic = new Graphic();
            graphic.InitGraph(pictureBox1);
            graphic.ClearGraph();
            //demo.Dispersion(new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), 150);
            //demo.Draw(graphic);
            //demo.NrI(graphic);
            //foreach (string s in demo.View())
            //{
            //    listBox1.Items.Add(s);
            //}
            //PointF S = myMath.Inters(A, B, C, D);
            //graphic.grp.DrawLine(Pens.Black, A, B);
            //graphic.grp.DrawLine(Pens.Black, C, D);
            //graphic.grp.DrawEllipse(Pens.Red, S.X - 5, S.Y - 5, 11, 11);
            AG ag = new AG();
            ag.initPop(100);
            ag.Draw(15, graphic);
            graphic.RefreshGraph();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
