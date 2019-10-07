using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaveSimulator
{
    public partial class OneDView : Form
    {
       
        public PointF[] pnts;
        MainForm owner;

         // 1D View variables
         int xperc = 50; // This percentage determines the location of the linear input in X-axis.
         int yperc = 50; // This percentage determines the location of the linear input in Y-axis.
         bool horizon = true; // True for horizontal line input, false for vertical line input.

        public OneDView(MainForm owner)
        {
            InitializeComponent();
            this.owner = owner;
            if (horizon)
                comboBox1.SelectedIndex = 0;
            else
                comboBox1.SelectedIndex = 1;
            pnts = new PointF[owner.we.Size];
            timer1.Interval = 20;
            timer1.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = owner.we.Delay; // Don't forget to update.
            pnts = new PointF[owner.we.Size];
            // We will find out the "1D View" graph points here.
            try
            {
                float xmulti = 400f / (float)owner.we.Size; // This will be used to find out an offset.
                if (horizon)
                {
                    float[] rawoutput = owner.we.GetParticles(new Rectangle(0, (int)(((float)yperc / 100f) * (float)owner.we.Size), owner.we.Size, 1), WaveEngine.ParticleAttribute.Height);


                    for (int i = 0; i < rawoutput.Length; i++)
                    {
                        pnts[i] = new PointF(xmulti * (float)i, (rawoutput[i] / owner.we.Limit) * 100f + 100f);
                    }
                }
                else
                {
                    float[] rawoutput = owner.we.GetParticles(new Rectangle((int)(((float)xperc / 100f) * (float)owner.we.Size), 0, 1, owner.we.Size), WaveEngine.ParticleAttribute.Height);


                    for (int i = 0; i < rawoutput.Length; i++)
                    {
                        pnts[i] = new PointF(xmulti * (float)i, (rawoutput[i] / owner.we.Limit) * 100f + 100f);
                    }
                }

                this.pictureBox1.Invalidate();
            }
            catch
            { }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (pnts != null)
            e.Graphics.DrawCurve(new Pen(Color.Black, 2f), pnts);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            xperc = (int)numericUpDown1.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                horizon = true;
            else
                horizon = false;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            yperc = (int)numericUpDown2.Value;
        }
    }
}
