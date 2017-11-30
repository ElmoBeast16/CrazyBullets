using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crazybullets
{
    public partial class Form1 : Form
    {
        // create an array list to hold bullets
        List<Label> bullets = new List<Label>();
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = lblship.Location.X;
            int y = lblship.Location.Y;

            if(e.KeyCode == Keys.Left){
                if (lblship.Left > 10)
                {
                    x -= 10;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if(lblship.Right < this.Width){
                x += 10;
                }
            }
            if(e.KeyCode == Keys.Space){              
                if(count < 10){
                    //create object
                    bullets.Add(new Label()); 
                    //set properties
                    this.Controls.Add(bullets.ElementAt(count));
                    bullets.ElementAt(count).Height = 10;
                    bullets.ElementAt(count).Width = 10;
                    bullets.ElementAt(count).BackColor = Color.Blue;
                    bullets.ElementAt(count).Left = lblship.Left + 45;
                    bullets.ElementAt(count).Top = lblship.Top - 10;
                    count++;
                }
            }

            lblship.Location = new Point(x, y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < count; i++) {
                bullets.ElementAt(i).Top -= 10;
            }
            //remove bullet
            for (int k = 0; k < count; k++ ) {
                if(bullets.ElementAt(k).Top < 0){
                    this.Controls.Remove(bullets.ElementAt(k));
                    bullets.RemoveAt(k);
                    count -= 1;
                    if(count <= 0){
                        bullets = new List<Label>();
                        count = 0;
                        break;
                    
                    }
                } 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblship_Click(object sender, EventArgs e)
        {

        }
    }
}
