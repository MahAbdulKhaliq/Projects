using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
  Class:  Form1.cs
  Author: Mahmood Abdul-Khaliq
  Date:   December 6, 2019

I, Mahmood Abdul-Khaliq, student number #000788833, certify that all code submitted is my own work; 
                           that I have not copied it from any other source.  
                           I also certify that I have not allowed my work to be copied by others.
*/


namespace Lab5A
{
    public partial class Form1 : Form
    {
        private Graphics g;                         //Encapsulates a GDI+ drawing surface
        private Pen p;                              //Pens are used to draw objects
        private SolidBrush b;                       //Brushes are used to fill graphics shapes
        private Color c = Color.SkyBlue;            //Default colour for fluid
        private int ticks;                          //Value used for time-related properties

        private bool reset = false;                 //Used for resetting beaker when full
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);

        }

        /// <summary>
        /// Paints initial lines for the 'bucket' and sets up Graphics object
        /// with PaintEventHandler
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default PaintEventArgs</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            p = new Pen(Color.White);
            g.DrawLine(p, 300, 250, 300, 450);
            g.DrawLine(p, 100, 250, 100, 450);
            g.DrawLine(p, 100, 450, 300, 450);
        }

        /// <summary>
        /// Gracefully closes the environment when the 'Exit' button is
        /// clicked.
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default EventArgs</param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        /// <summary>
        /// Changes the colour of the fluid to whatever the user
        /// desires via a colorDialog prompt.
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default EventArgs</param>
        private void ColorBtn_Click(object sender, EventArgs e)
        {
            //Confirms the dialog box works; then, switches the default colour to a user-selected one.
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog.Color;
            }
        }

        /// <summary>
        /// Adds a stream from the faucet based off of the trackbar scroll progress.
        /// Will hide the stream if the trackbar is set to 0 (and subsequently, stop the trackTimer object).
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default EventArgs</param>
        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            
            //Resets the object once the bucket is full
            if (reset)
            {
                b = new SolidBrush(Color.Black); //Sets up a brush with black colour to hide the previous filling
                g.FillRectangle(b, 101, 249, 199, 200);
                reset = false;
            }
            b = new SolidBrush(c); //Sets up a brush with selected colour
          
            //Stream position co-ordinates for open-faucet fluid. Used for simplicity
            //as whent the faucet is shut off a black rectangle is drawn over the stream.
            Rectangle streamPosition = new Rectangle(125, 200, 20, (250-ticks));

            //Draws a stream based off of the selected colour and starts the trackTimer
            if (trackBar.Value >= 1)
            {                
                g.FillRectangle(b, streamPosition);
                trackTimer.Start();
                trackTimer.Enabled = true;
            }
            //Draws a black rectangle over the stream and stops the trackTimer
            else
            {
                b = new SolidBrush(Color.Black); //Sets up a brush with black colour to hide the previous stream
                g.FillRectangle(b, streamPosition);
                trackTimer.Stop();
            }
        }


        /// <summary>
        /// Controls all time-based commands, from flow-rate to current
        /// beaker status.
        /// 
        /// This is all controlled via 'ticks' in the timer - an increased tick
        /// leads to an increased value; this value determines increase with height
        /// scaling of the fluid.
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default EventArgs</param>
        private void TrackTimer_Tick(object sender, EventArgs e)
        {
            //Increases ticks and controls tick growth based off of trackBar value
            ticks += 1 * (trackBar.Value);

            //Stream position co-ordinates for open-faucet fluid. Used for simplicity
            Rectangle streamPosition = new Rectangle(125, 200, 20, (250 - ticks));           g = this.CreateGraphics();
            b = new SolidBrush(c); //Sets up a brush with selected colour to fill beaker with fluid

            g.FillRectangle(b, 101, 450-ticks, 199, (trackBar.Value)); //Fills beaker with selected fluid; scales height and y-position appropriately based off of tick parameters

            //Just before the beaker is filled: stops the flow, trackTimer, and forces a reset upon next fill attempt.
            if (ticks >= 180)
            {
                trackTimer.Stop();
                b = new SolidBrush(Color.Black);
                g.FillRectangle(b, streamPosition);
                trackBar.Value = 0;
                ticks = 0;
                reset = true;
            }
        }
    }
}
