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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                BiletList.numberOfPeople = Convert.ToInt32(numericUpDown1.Value);
                BiletList.numberOfChildren = Convert.ToInt32(numericUpDown2.Value);

                Form3 fr3 = new Form3();
                this.Hide();
                fr3.Show();
            }
            else if (numericUpDown1.Value < 1 & numericUpDown2.Value > 0)
            {
                MessageBox.Show("Введите количество взрослых пассажиров", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Выберете колличество пассажиров", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
