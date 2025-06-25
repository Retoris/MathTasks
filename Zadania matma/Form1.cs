using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Zadania_matma
{

    public partial class MathTasks : Form
    {
        public Random losuj = new Random();

        public bool wr=false;

        //Dodawanie wr
        public int doverall = 0;
        public double dwin = 0;
        public double dtry = 0;
        public double dwr = 0;

        //Odejmowanie wr
        public int ooverall = 0;
        public double owin = 0;
        public double otry = 0;
        public double owr = 0;

        //Mnozenie wr
        public int moverall = 0;
        public double mwin = 0;
        public double mtry = 0;
        public double mwr = 0;

        //Dzielenie wr
        public int dzoverall = 0;
        public double dzwin = 0;
        public double dztry = 0;
        public double dzwr = 0;

        public int liczba1;
        public int liczba2;
        public const int G = 1;
        public const int N = 100;
        public decimal zm1;
        public decimal zm2;
        public decimal zm3;
        public decimal wynik;
        public bool d = false;
        public bool o = false;
        public bool m = false;
        public bool dz = false;

        public bool change = true;

        public MathTasks()
        {
            InitializeComponent();
            textBox2.BackColor = Color.LightGoldenrodYellow;
            this.dodajwr.Text = "Dodawanie % \nAttempts " + doverall.ToString();
            this.odejmnijwr.Text = "Odejmowanie % \nAttempts " + ooverall.ToString();
            this.mnozwr.Text = "Mnozenie % \nAttempts " + moverall.ToString();
            this.dzielwr.Text = "Dzielenie % \nAttempts " + dzoverall.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void wynik_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_Click(object sender, EventArgs e)
        {
            Check();

        }

        private void Check()
        {
            try
            {
                zm1 = decimal.Parse(label1.Text);
                zm2 = decimal.Parse(label3.Text);

                wynik = decimal.Parse(this.textBox1.Text);

                if (d)
                {
                    zm3 = zm1 + zm2;
                }

                if (o)
                {
                    zm3 = zm1 - zm2;
                }

                if (m)
                {
                    zm3 = zm1 * zm2;
                }

                if (dz)
                {
                    zm3 = zm1 / zm2;
                    zm3 = Math.Round(zm3, 1);
                }

                if (zm3 == wynik)
                {
                    textBox2.BackColor = Color.Green;
                }
                else
                {
                    textBox2.BackColor = Color.Red;
                }

                //Dodawanie wr
                if (d)
                {
                    if (zm3 == wynik && wr)
                    {
                        dwin++;
                        dtry++;

                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }
                    else
                    {
                        dtry++;

                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }
                    doverall++;
                    wr = false;
                    change = true;

                    dwr = dwin / dtry;
                    dwr = Math.Round(dwr, 2) * 100;
                    this.richTextBox1.Text = dwr.ToString() + "%";
                    this.dodajwr.Text = "Dodawanie % \nAttempts " + doverall.ToString();

                }

                if (o)
                {
                    if (zm3 == wynik && wr)
                    {
                        owin++;
                        otry++;

                        button1.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }
                    else
                    {
                        otry++;

                        button1.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }
                    ooverall++;
                    wr = false;
                    change = true;

                    owr = owin / otry;
                    owr = Math.Round(owr, 2) * 100;
                    this.richTextBox2.Text = owr.ToString() + "%";
                    this.odejmnijwr.Text = "Odejmowanie % \nAttempts " + ooverall.ToString();

                }

                if (m)
                {
                    if (zm3 == wynik && wr)
                    {
                        mwin++;
                        mtry++;

                        button2.Enabled = true;
                        button1.Enabled = true;
                        button4.Enabled = true;
                    }
                    else
                    {
                        mtry++;

                        button2.Enabled = true;
                        button1.Enabled = true;
                        button4.Enabled = true;
                    }
                    moverall++;
                    wr = false;
                    change = true;

                    mwr = mwin / mtry;
                    mwr = Math.Round(mwr, 2) * 100;
                    this.richTextBox3.Text = mwr.ToString() + "%";
                    this.mnozwr.Text = "Mnozenie % \nAttempts " + moverall.ToString();

                }

                if (dz)
                {
                    if (zm3 == wynik && wr)
                    {
                        dzwin++;
                        dztry++;

                        button2.Enabled = true;
                        button3.Enabled = true;
                        button1.Enabled = true;
                    }
                    else
                    {
                        dztry++;

                        button2.Enabled = true;
                        button3.Enabled = true;
                        button1.Enabled = true;
                    }
                    dzoverall++;
                    wr = false;
                    change = true;

                    dzwr = dzwin / dztry;
                    dzwr = Math.Round(dzwr, 2) * 100;
                    this.richTextBox4.Text = dzwr.ToString() + "%";
                    this.dzielwr.Text = "Dzielenie % \nAttempts " + dzoverall.ToString();

                }

                d = false;
                o = false;
                m = false;
                dz = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Operacje(int arg)
        {
            switch (arg) 
            {
                case 1:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;

                    change = false;

                    wr = true;
                    textBox2.BackColor = Color.LightGoldenrodYellow;
                    this.textBox1.Text = "";
                    label2.Text = "+";
                    label4.Text = "=";
                    liczba1 = losuj.Next(G, N);
                    liczba2 = losuj.Next(G, N);
                    label1.Text = liczba1.ToString();
                    label3.Text = liczba2.ToString();
                    d = true;
                    answerBox.Text = "";
                    zm3 = 0;
                    break;

                case 2:
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;

                    change = false;

                    wr = true;
                    textBox2.BackColor = Color.LightGoldenrodYellow;
                    this.textBox1.Text = "";
                    label2.Text = "-";
                    label4.Text = "=";
                    liczba1 = losuj.Next(G, N);
                    liczba2 = losuj.Next(G, N);
                    while (liczba1 <= liczba2)
                    {
                        liczba2 = losuj.Next(G, N);
                    }
                    label1.Text = liczba1.ToString();
                    label3.Text = liczba2.ToString();
                    o = true;
                    answerBox.Text = "";
                    zm3 = 0;
                    break;

                case 3:
                    button2.Enabled = false;
                    button1.Enabled = false;
                    button4.Enabled = false;

                    change = false;

                    wr = true;
                    textBox2.BackColor = Color.LightGoldenrodYellow;
                    this.textBox1.Text = "";
                    label2.Text = "*";
                    label4.Text = "=";
                    liczba1 = losuj.Next(G, N - 69);
                    liczba2 = losuj.Next(G, N - 69);
                    label1.Text = liczba1.ToString();
                    label3.Text = liczba2.ToString();
                    m = true;
                    answerBox.Text = "";
                    zm3 = 0;
                    break;

                case 4:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button1.Enabled = false;

                    change = false;

                    wr = true;
                    textBox2.BackColor = Color.LightGoldenrodYellow;
                    this.textBox1.Text = "";
                    label2.Text = "/";
                    label4.Text = "=";
                    liczba1 = losuj.Next(G, N);
                    liczba2 = losuj.Next(G, N);
                    label1.Text = liczba1.ToString();
                    label3.Text = liczba2.ToString();
                    dz = true;
                    answerBox.Text = "";
                    zm3 = 0;
                    break;

            }
                
        }


        //Dodawanie
        private void button1_Click(object sender, EventArgs e)
        {
            Operacje(1);
        }

        //Odejmowanie
        private void button2_Click(object sender, EventArgs e)
        {
            Operacje(2);
        }

        //Mnożenie
        private void button3_Click(object sender, EventArgs e)
        {
            Operacje(3);
        }

        //Dzielenie
        private void button4_Click(object sender, EventArgs e)
        {
            Operacje(4);
        }

        //Show Answer
        private void show_Click(object sender, EventArgs e)
        {
            if (zm3 > 0)
                answerBox.Text = zm3.ToString();
            else
                answerBox.Text = "LMAO";
        }

        private void answerBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                Check();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && change)
            {
                Operacje(1);
            }

            if (e.KeyCode == Keys.F2 && change)
            {
                Operacje(2);
            }

            if (e.KeyCode == Keys.F3 && change)
            {
                Operacje(3);
            }

            if (e.KeyCode == Keys.F4 && change)
            {
                Operacje(4);
            }
        }
    }
}
