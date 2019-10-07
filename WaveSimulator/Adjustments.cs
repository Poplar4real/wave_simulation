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
    public partial class Adjustments : Form
    {
        MainForm owner;
        public Adjustments(MainForm owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

      

        private void Form2_Shown(object sender, EventArgs e)
        {
            numericUpDown1.Value = (decimal)owner.we.Mass;
            numericUpDown2.Value = (decimal)owner.we.Limit;
            numericUpDown3.Value = (decimal)owner.we.ActionResolution;
            numericUpDown4.Value = (decimal)owner.we.Sustainability;
            numericUpDown5.Value = (decimal)owner.we.Delay;
            numericUpDown6.Value = (decimal)owner.we.Size;
            numericUpDown7.Value = (decimal)owner.we.EdgeSustainability;
            numericUpDown8.Value = (decimal)owner.we.Power;
            numericUpDown9.Value = (decimal)owner.we.PhaseRate1;
            numericUpDown10.Value = (decimal)owner.we.PhaseRate2;
            numericUpDown11.Value = (decimal)owner.we.AbsorbtionOffset;
            checkBox1.Checked = owner.we.HighContrast;
            checkBox2.Checked = owner.we.EdgeAbsorbtion;

            Color color1 = owner.we.Color1;
            Color color2 = owner.we.Color2;

            this.button2.BackColor = color1;
            this.button2.ForeColor = Color.FromArgb(255, 255 - color1.R, 255 - color1.G, 255 - color1.B);

            this.button3.BackColor = color2;
            this.button3.ForeColor = Color.FromArgb(255, 255 - color2.R, 255 - color2.G, 255 - color2.B);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = this.button1.BackColor;
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.button1.BackColor = cd.Color;
                this.button1.ForeColor = Color.FromArgb(255, 255 - cd.Color.R, 255 - cd.Color.G, 255 - cd.Color.B);
            }
            owner.we.ColorStatic = button1.BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = this.button2.BackColor;
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.button2.BackColor = cd.Color;
                this.button2.ForeColor = Color.FromArgb(255, 255 - cd.Color.R, 255 - cd.Color.G, 255 - cd.Color.B);
            }
            owner.we.Color1 = button2.BackColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = this.button3.BackColor;
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.button3.BackColor = cd.Color;
                this.button3.ForeColor = Color.FromArgb(255, 255 - cd.Color.R, 255 - cd.Color.G, 255 - cd.Color.B);
            }
            owner.we.Color2 = button3.BackColor;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            owner.we.Mass = (float)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            owner.we.Limit = (float)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            owner.we.ActionResolution = (float)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            owner.we.Sustainability = (float)numericUpDown4.Value;

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            owner.we.Delay = (int)numericUpDown5.Value;
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            owner.we.Power = (float)this.numericUpDown8.Value;
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            owner.we.PhaseRate1 = (float)this.numericUpDown9.Value;
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            owner.we.PhaseRate2 = (float)this.numericUpDown10.Value;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            owner.we.Size = (int)numericUpDown6.Value;

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            owner.we.EdgeSustainability = (float)this.numericUpDown7.Value;

           
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            owner.we.AbsorbtionOffset = (int)this.numericUpDown11.Value;

        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            owner.we.HighContrast = this.checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            owner.we.EdgeAbsorbtion = this.checkBox2.Checked;

          
        }

        private void radioButton1or2_CheckedChanged(object sender, EventArgs e)
        {
           owner.staticdraw = this.radioButton1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          owner.we.SetParticles(new Rectangle(0,0,owner.we.Size, owner.we.Size), 0f, WaveEngine.ParticleAttribute.Fixity);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            owner.we.SetParticles(new Rectangle(0, 0, owner.we.Size, owner.we.Size), 1f, WaveEngine.ParticleAttribute.Fixity);
        }


        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            owner.draw_thickness = (int)this.numericUpDown12.Value;
        }
      

      
    }
}
