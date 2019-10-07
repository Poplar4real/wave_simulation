using System;
using System.Drawing;
using System.Windows.Forms;

namespace WaveSimulator
{
    public partial class MainForm : Form
    {

        public WaveEngine we;

        OneDView frm3; // "1D View" form.
        Adjustments frm2; // "Adjustments" form.

        public bool staticdraw = true; // True = drawing mode, False = Erasing mode
        public int draw_thickness = 3;

        public MainForm()
        {
            InitializeComponent();

           
            we = new WaveEngine(this);

            we.Run();
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                we.SetParticles(new Rectangle(0, 0, we.Size, we.Size), 0f, WaveEngine.ParticleAttribute.Acceleration | WaveEngine.ParticleAttribute.Height | WaveEngine.ParticleAttribute.Velocity);
            }
            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                we.Oscillator1Active = false;
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2 )
            {
                we.Oscillator2Active = false;
            }
        }

        private void adjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm2 != null)
            {
                if (frm2.IsDisposed == true)
                {
                    frm2 = new Adjustments(this);
                    frm2.Show();
                }
            }
            else
            {
                frm2 = new Adjustments(this);
                frm2.Show();
            }
        }

      
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                try
                {
                    // Threaded to reduce the gaps.
                    System.Threading.ThreadPool.QueueUserWorkItem((Object arg1) =>
                    {
                        we.SetParticles(new Rectangle((int)(((float)e.X / (float)ClientSize.Width) * (float)we.Size), (int)(((float)e.Y / (float)ClientSize.Height) * (float)we.Size), draw_thickness, draw_thickness), Convert.ToSingle(staticdraw), WaveEngine.ParticleAttribute.Fixity);
                    });
                    }
                catch
                { }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    we.Oscillator1Position = new Point((int)(((float)e.X / (float)ClientSize.Width) * (float)we.Size), (int)(((float)e.Y / (float)ClientSize.Height) * (float)we.Size));
                    we.Oscillator1Active = true;
                }
                catch
                { }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                try
                {
                    we.Oscillator2Position = new Point((int)(((float)e.X / (float)ClientSize.Width) * (float)we.Size), (int)(((float)e.Y / (float)ClientSize.Height) * (float)we.Size));
                    we.Oscillator2Active = true;
                }
                catch
                { }
            }
        }

        private void dViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm3 != null)
            {
                if (frm3.IsDisposed == true)
                {
                    frm3 = new OneDView(this);
                    frm3.Show();
                }
            }
            else
            {
                frm3 = new OneDView(this);
                frm3.Show();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpWindow frm4 = new HelpWindow();
            frm4.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            we.Dispose();
        }

      
      
      
    }
}
