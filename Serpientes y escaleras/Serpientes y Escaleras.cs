using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;


namespace Serpientes_y_escaleras
{
    public partial class Form1 : Form
    {
        Button[] casillas = new Button[26];
        int posAct;
        int posAnt;

        public Form1()
        {
            InitializeComponent();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icono;
            int h = 50;
            int w = 50;
            int x = 50, y = 430;
            int aux = 1;
            posAct = 1;
            posAnt = 1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    Button button1 = new Button();

                    if (i == 1 || i == 3)
                    {
                        button1.Location = new System.Drawing.Point(400 - ((j * 50) + (x * j)) + 50, y - (50 * (i * 2)));
                    }
                    else
                    {
                        button1.Location = new System.Drawing.Point((j * 50) + (x * j) + 50, y - (50 * (i * 2)));
                    }


                    button1.Name = "casilla" + aux.ToString();
                    button1.Size = new System.Drawing.Size(h, w);
                    button1.TabIndex = 0;
                    button1.Text = aux.ToString();
                    button1.UseVisualStyleBackColor = true;
                    button1.Enabled = false;
                    button1.BackColor = Color.White;
                    button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //this.Controls.Add(button1);
                    
                    if (aux==25)
                    {
                        button1.BackColor = Color.GreenYellow;
                    }
                    else if (aux==1)
                    {
                        button1.BackColor = Color.Aquamarine;
                    }

                    this.panel1.Controls.Add(button1);
                    casillas[aux] = button1;

                    aux++;
                    panel1.Refresh();

                }
            }
            buttonReiniciar.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
            Pen penBlue = new Pen(Color.Blue, 3);
            Pen penEsc = new Pen(Color.Green, 3);
            Pen penSer = new Pen(Color.Red, 3);

            Graphics g = e.Graphics;
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(4,4);
            penBlue.CustomEndCap = bigArrow;
            penEsc.CustomEndCap = bigArrow;
            penSer.CustomEndCap = bigArrow;

            g.DrawLine(penEsc, casillas[8].Location.X + 25, casillas[8].Location.Y, casillas[14].Location.X, casillas[14].Location.Y + 50);
            g.DrawLine(penEsc, casillas[17].Location.X + 25, casillas[17].Location.Y, casillas[23].Location.X + 50, casillas[23].Location.Y + 50);
            g.DrawLine(penEsc, casillas[3].Location.X + 25, casillas[3].Location.Y, casillas[7].Location.X , casillas[7].Location.Y + 50);
            g.DrawLine(penEsc, casillas[11].Location.X + 25, casillas[11].Location.Y, casillas[20].Location.X, casillas[20].Location.Y + 50);

            g.DrawLine(penSer, casillas[24].Location.X + 25, casillas[24].Location.Y + 50, casillas[13].Location.X +50, casillas[13].Location.Y);
            g.DrawLine(penSer, casillas[19].Location.X + 25, casillas[19].Location.Y + 50, casillas[10].Location.X + 50, casillas[10].Location.Y);
            g.DrawLine(penSer, casillas[15].Location.X + 25, casillas[15].Location.Y + 50, casillas[4].Location.X + 50, casillas[4].Location.Y);
            g.DrawLine(penSer, casillas[12].Location.X + 25, casillas[12].Location.Y + 50, casillas[1].Location.X + 50, casillas[1].Location.Y);


            for (int i=1;i<=25;i++)

            {
                if (i==6 ||i==16)
                {
                    g.DrawLine(penBlue, casillas[i - 1].Location.X+25 , casillas[i - 1].Location.Y , casillas[i].Location.X+25, casillas[i].Location.Y +50);
                }
                else if (i==11||i==21)
                {
                    g.DrawLine(penBlue, casillas[i - 1].Location.X + 25, casillas[i - 1].Location.Y, casillas[i].Location.X + 25, casillas[i].Location.Y + 50);
                }
                else if (i == 25)
                {
                    g.DrawLine(penBlue, casillas[i - 1].Location.X + 50, casillas[i - 1].Location.Y + 25, casillas[i].Location.X, casillas[i].Location.Y + 25);
                    g.DrawLine(penBlue, casillas[i].Location.X + 25, casillas[i].Location.Y + 50, casillas[16].Location.X + 25, casillas[16].Location.Y);
                }
                else if ( (i>=7 && i<=10) || (i >= 17 && i <= 20))
                {
                    g.DrawLine(penBlue, casillas[i - 1].Location.X , casillas[i - 1].Location.Y + 25, casillas[i].Location.X+50, casillas[i].Location.Y + 25);
                }
                else if (i != 1)
                {
                    g.DrawLine(penBlue, casillas[i-1].Location.X+50, casillas[i - 1].Location.Y +25, casillas[i].Location.X, casillas[i].Location.Y + 25);
                }

            }

            

            //g.Dispose();
        }

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            mover(posAct,1);
            casillas[25].BackColor = Color.GreenYellow;
            posAct = 1;
            posAnt = 1;
            buttonLanzarDado.Enabled = true;
        }

        private void buttonLanzarDado_Click(object sender, EventArgs e)
        {
            Random dado = new Random();
            int randomNum = dado.Next(1, 5);
            Random sb = new Random();
            int randomSB = sb.Next(1,100);
            if (randomSB<50)
            {
                randomSB = 1;
            }
            else
            {
                randomSB = 2;
            }



            if (posAct+randomNum > 25)
            {
                if (randomSB == 1)
                {
                    MessageBox.Show("Tirada del dado: " + randomNum + "\nCasilla Siguente: " + (15-(25 - (posAct + randomNum))).ToString() + "\nS/B: S", "Dado", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Tirada del dado: " + randomNum + "\nCasilla Siguente: " + (15 - (25 - (posAct + randomNum))).ToString() + "\nS/B: B", "Dado", MessageBoxButtons.OK);
                }

                posAnt = posAct;
                posAct = 15 - (25 - (posAct + randomNum));
                mover(posAnt,posAct);
            }
            else
            {
                if (randomSB == 1)
                {
                    MessageBox.Show("Tirada del dado: " + randomNum + "\nCasilla Siguente: "+ (posAct + randomNum).ToString() + "\nS/B: S", "Dado", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Tirada del dado: " + randomNum + "\nCasilla Siguente: " + (posAct + randomNum).ToString() + "\nS/B: B", "Dado", MessageBoxButtons.OK);
                }

                posAnt = posAct;
                posAct += randomNum;

                switch (posAct)
                {
                    case 1:
                        mover(posAnt, posAct);
                        break;
                    case 2:
                        mover(posAnt, posAct);
                        break;
                    case 3:
                        mover(posAnt, posAct);

                        if (randomSB == 1)
                        {
                            posAnt = posAct;
                            posAct = 7;
                            mover(posAnt,posAct);

                        }

                        break;
                    case 4:
                        mover(posAnt, posAct);
                        break;
                    case 5:
                        mover(posAnt, posAct);
                        break;
                    case 6:
                        mover(posAnt, posAct);
                        break;
                    case 7:
                        mover(posAnt, posAct);
                        break;
                    case 8:
                        mover(posAnt, posAct);

                        if (randomSB == 1)
                        {
                            posAnt = posAct;
                            posAct = 14;
                            mover(posAnt, posAct);

                        }
                        break;
                    case 9:
                        mover(posAnt, posAct);
                        break;
                    case 10:
                        mover(posAnt, posAct);
                        break;
                    case 11:
                        mover(posAnt, posAct);
                        if (randomSB == 1)
                        {
                            posAnt = posAct;
                            posAct = 20;
                            mover(posAnt, posAct);

                        }
                        break;
                    case 12:
                        mover(posAnt, posAct);
                        if (randomSB == 2)
                        {
                            posAnt = posAct;
                            posAct = 1;
                            mover(posAnt, posAct);

                        }
                        break;
                    case 13:
                        mover(posAnt, posAct);
                        break;
                    case 14:
                        mover(posAnt, posAct);
                        break;
                    case 15:
                        mover(posAnt, posAct);
                        if (randomSB == 2)
                        {
                            posAnt = posAct;
                            posAct = 4;
                            mover(posAnt, posAct);

                        }
                        break;
                    case 16:
                        mover(posAnt, posAct);
                        break;
                    case 17:
                        mover(posAnt, posAct);
                        if (randomSB == 1)
                        {
                            posAnt = posAct;
                            posAct = 23;
                            mover(posAnt, posAct);

                        }
                        break;
                    case 18:
                        mover(posAnt, posAct);
                        break;
                    case 19:
                        mover(posAnt, posAct);
                        if (randomSB == 2)
                        {
                            posAnt = posAct;
                            posAct = 10;
                            mover(posAnt, posAct);

                        }
                        break;
                    case 20:
                        mover(posAnt, posAct);
                        break;
                    case 21:
                        mover(posAnt, posAct);
                        break;
                    case 22:
                        mover(posAnt, posAct);
                        break;
                    case 23:
                        mover(posAnt, posAct);
                        break;
                    case 24:
                        mover(posAnt, posAct);
                        if (randomSB == 2)
                        {
                            posAnt = posAct;
                            posAct = 13;
                            mover(posAnt, posAct);

                        }
                        break;
                    case 25:
                        mover(posAnt, posAct);
                        buttonLanzarDado.Enabled = false;
                        MessageBox.Show("Felicidades, ha ganado la partida!", "Partida terminada", MessageBoxButtons.OK);
                        break;
                }
            }


        }

        void mover(int inicio,int final)
        {
            
            casillas[inicio].BackColor = Color.White;
            casillas[final].BackColor = Color.Aquamarine;
            

        }
    }
}
