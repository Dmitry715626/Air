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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List.Add(new City("Москва", 1500));
            List.Add(new City("Адлер", 4000));
            List.Add(new City("Томск", 1000));
            List.Add(new City("Астрахань", 1500));

            for (int i = 0; i < List.ListCity.Count; i++)
            {
                comboBox1.Items.Add(List.Show(i));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            if (comboBox1.SelectedItem != null)
            {
                List.chosenCity = List.ListCity[comboBox1.SelectedIndex];
                Form2 fr2 = new Form2();
                this.Hide();
                fr2.Show();
            }
            else
            {
                MessageBox.Show("Выберете город", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
    }
}
