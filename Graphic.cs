using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace AI_CURS1
{
    public class Graphic
    {
        public PictureBox display;
        public Graphics grp;
        public Bitmap bmp;
        public Color backColor = Color.AliceBlue;
        public static int width, height;
        

        public void InitGraph(PictureBox display)
        {
            this.display = display;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            width = display.Width;
            height = display.Height;
        }

        public void RefreshGraph()
        {
            display.Image = bmp;
        }
        
        public void ClearGraph()
        {
            grp.Clear(backColor);
        }
    }
}
