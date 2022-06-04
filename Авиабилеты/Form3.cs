using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Авиабилеты
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BiletList.numberOfPeople > 0)
            {
                if (DateTime.Today.Year - dateTimePicker1.Value.Year >= 18)
                {
                    BiletList.Add(new Bilet(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, false));
                    BiletList.numberOfPeople--;
                    if (BiletList.numberOfPeople == 0)
                    {
                        label6.Text = "Детский билет";
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else if (textBox1.Text == "" | textBox3.Text == "" | textBox3.Text == "")
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("Введите ФИО", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Возраст меньше 18 лет", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (BiletList.numberOfPeople == 0 && BiletList.numberOfChildren == 0)
                {
                    Form4 fr4 = new Form4();
                    this.Hide();
                    fr4.Show();
                }
            }
            else if (BiletList.numberOfChildren > 0)
            {
                if (DateTime.Today.Year - dateTimePicker1.Value.Year < 18)
                {
                    BiletList.Add(new Bilet(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, true));
                    BiletList.numberOfChildren--;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Превышает возраст ребёнка", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (BiletList.numberOfPeople == 0 && BiletList.numberOfChildren == 0)
                {
                    Form4 fr4 = new Form4();
                    this.Hide();
                    fr4.Show();
                }
            }
        }
    }
}
