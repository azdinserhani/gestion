using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace gestion_tequte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void enregister() {
            FileStream fs = new FileStream("miage.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(comboBox1.Text + "#"+ dateTimePicker1.Text + "#" + comboBox2.Text + "#" + comboBox3.Text + "#" + textBox1.Text);
            sw.Close();
            fs.Close();
            
            }
        void Lister() {
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            dataGridView1.Rows.Clear();
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split('#');
                dataGridView1.Rows.Add(line[0], line[1], line[2], line[3], line[4]);
            }
            sr.Close();
            fs.Close();
        }
        void suppremer()
        {
            string st = "";
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            dataGridView1.Rows.Clear();
            while (sr.Peek() > -1)
            {
                string token = sr.ReadLine();
                string[] line = token.Split('#');
                if (comboBox1.Text != line[0])
                {
                    st = st + token + "\n";
                }

            }
            sr.Close();
            fs.Close();
            FileStream fs2 = new FileStream("miage.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(st);

            sw.Close();
            fs.Close();
        }
        void modifier() {

            string st = "";
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            dataGridView1.Rows.Clear();
            while (sr.Peek() > -1)
            {
                string token = sr.ReadLine();
                string[] line = token.Split('#');
                if (comboBox1.Text != line[0])
                {
                    st = st + token + "\n";
                }
                else {
                    st = st + comboBox1.Text + "#" + dateTimePicker1.Text + "#" + comboBox2.Text + "#" + comboBox3.Text + "#" + textBox1.Text + "\n";
                }

            }
            sr.Close();
            fs.Close();
            FileStream fs2 = new FileStream("miage.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(st);

            sw.Close();
            fs.Close();
        }
        void remplir() {

            FileStream fs = new FileStream("miage.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            comboBox1.Items.Clear();
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split('#');
                comboBox1.Items.Add(line[0]);
            }
            sr.Close();
            fs.Close();
        }
        void rechercher() {
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split('#');
                if (line[0] == comboBox1.Text)
                {
                    dateTimePicker1.Text = line[1];
                    comboBox2.Text = line[2];
                    comboBox3.Text = line[3];
                    textBox1.Text = line[4];
                }
            }
            sr.Close();
            fs.Close();
        }
        void calcul() {
            string destination = comboBox2.Text;
            string type = comboBox3.Text;
            float prix = 0;
            if (destination == "Madrid" && type == "1")
            {
                prix = 2500;
            }
            else if (destination == "Paris" && type == "1")
            {
                prix =3000;
            }
            else if (destination == "Barcelona" && type == "1")
            {
                prix = 2800;
            }
            else if (destination == "Madrid" && type == "2")
            {
                prix = 3500;
            }
            else if (destination == "Paris" && type == "2")
            {
                prix = 3500;
            }
            else if (destination == "Barcelona" && type == "2")
            {
                prix = 4000;
            }
            textBox1.Text = prix.ToString() + "DH";
        }
        void neuveau() {
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            enregister();
            Lister();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lister();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("confemer", "supremer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                suppremer();
                Lister();
            }
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("confemer", "modifier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                modifier();
                Lister();
            }
            
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            rechercher();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            remplir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcul();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            neuveau();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
