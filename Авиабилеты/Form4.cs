using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace Авиабилеты
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = BiletList.TicketListCount() + 1;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "Имя";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Отчество";
            dataGridView1.Columns[3].HeaderText = "Возраст";
            dataGridView1.Columns[4].HeaderText = "Скидка";
            dataGridView1.Columns[5].HeaderText = "Цена";
            int sum = 0;
            for (int i = 0; i < BiletList.TicketListCount(); i++)
            {
                int COST;
                if (BiletList.Show(i).sale == 0)
                {
                    COST = List.chosenCity.Price;
                }
                else if (BiletList.Show(i).sale == 50)
                {
                    COST = List.chosenCity.Price / 2;
                }
                else
                {
                    COST = 0;
                }
                string[] arr = BiletList.Show(i).ShowTicket(i);
                dataGridView1[0, i].Value = arr[0];
                dataGridView1[1, i].Value = arr[1];
                dataGridView1[2, i].Value = arr[2];
                dataGridView1[3, i].Value = arr[3];
                dataGridView1[4, i].Value = arr[4] + "%";
                dataGridView1[5, i].Value = COST;
                sum += COST;
            }
            dataGridView1[5, BiletList.TicketListCount()].Value = sum;
            dataGridView1[4, BiletList.TicketListCount()].Value = "Общая стоимость";

            label2.Text += List.chosenCity.NameCity;
        }

        int count = 0;
        int j = 0;

        private async void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Rows[count].Cells[i].Style.BackColor = Color.Silver;
            }
            count++;

            await Task.Run(() => Met());
            if (j == BiletList.TicketListCount())
            {
                button1.Enabled = false;
            }
        }

        private void Zapis(string subToReplace, string text, Word.Document worddoc)
        {
            var range = worddoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: subToReplace, ReplaceWith: text);
        }

        private void Met()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\\Шаблон билета.docx");

            Zapis("(Город!)", List.chosenCity.NameCity, wordDoc);
            Zapis("(стоимость)", List.chosenCity.Price.ToString() + "р.", wordDoc);
            Zapis("(ФИО пассажира)", BiletList.Show(j).ShowTicket(j, 0) + " " + BiletList.Show(j).ShowTicket(j, 1) + " " + BiletList.Show(j).ShowTicket(j, 2), wordDoc);
            Zapis("(текущая дата)", DateTime.Now.ToString(), wordDoc);
            Zapis("(взрослый или детский/бесплатный)", BiletList.Show(j).child == true ? "Детский" : "Взрослый", wordDoc);
            Zapis("(возраст пассажира)", BiletList.Show(j).Age.ToString(), wordDoc);
            wordDoc.SaveAs(Application.StartupPath + $@"\\bilet {BiletList.Show(j).ShowTicket(j, 0) + " " + BiletList.Show(j).ShowTicket(j, 1) + " " + BiletList.Show(j).ShowTicket(j, 2)}" + ".docx");
            if (checkBox1.Checked == true)
            {
                wordApp.Visible = true;
            }
            else
            {
                wordApp.Documents.Close();
                wordApp.Quit();
            }
            j++;
        }
    }
}
