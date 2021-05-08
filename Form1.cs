using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        private Rectangle ksztalt;
        private bool _canDraw;
        private int _startX, _startY;
        float zoom = 1f;
        Graphics g;
        Pen pioro;
        int width;
        int height;
        Class1 s;
        Class1 obiekt;
        Class1 nazwa;

        public Form1()
        {
            InitializeComponent();
        }

        private void OtworzPlik()
        {
            string fileName = @"C:\Users\HP NoteBook\source\repos\WindowsFormsApp17\WindowsFormsApp17\bin\Debug\NowyPlik.txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    // Add some text to file    
                    //obiekt = new przyklad.Class1(e.X, e.Y, comboBox1.Text);
                    sw.WriteLine(obiekt.zapisPliku());

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystapil blad");
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Pen pioro = new Pen(Color.Black, 2);
            var wybor = comboBox1.SelectedIndex;
            switch (wybor)
            {
                case 0:
                    pioro = new Pen(Color.Red,2);
                    break;
                case 1:
                    pioro = new Pen(Color.Green,2);
                    break;
                case 2:
                    pioro = new Pen(Color.Blue,2);
                    break;
            }

            g.TranslateTransform(zoom, zoom);
            e.Graphics.DrawEllipse(pioro, ksztalt);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            zoom = trackBar1.Value / 100f;
            panel1.Invalidate();

            for(int i=0; i<=trackBar1.Value; i++)
            {
                if (i == 0)
                {
                    ksztalt.Size = new Size(width + i, height + i);
                }
                else
                {
                    ksztalt.Size = new Size(width + 10 * i, height + 10 * i);
                }
            }
            
            }
        
            private void panel1_MouseMove(object sender, MouseEventArgs e)
            {
                if (!_canDraw) return;

                int x = Math.Min(_startX, e.X);
                int y = Math.Min(_startY, e.Y);

                width = Math.Max(_startX, e.X) - Math.Min(_startX, e.X);
                height = Math.Max(_startY, e.Y) - Math.Min(_startY, e.Y);

                ksztalt = new Rectangle(x, y, width, height);
                Refresh();
            }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _canDraw = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _canDraw = true;
            
            _startX = e.X;
            _startY = e.Y;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void zapisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtworzPlik();
        }
    }
}
