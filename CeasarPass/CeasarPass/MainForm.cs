using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeasarPass
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            /* string m = textBox1.Text;
             int nomer; // Номер в алфавите

             string s; //Результат
             int j; // Переменная для циклов


             char[] massage = m.ToCharArray(); // Превращаем строку в массив символов.
             char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
             for (int i = 0; i < massage.Length; i++)
             {
                 // Ищем индекс буквы
                 for (j = 0; j < alfavit.Length; j++)
                 {
                     if (massage[i] == alfavit[j])
                     {
                         break;
                     }
                 }
                 if (j != 33) // Если j равно 33, значит символ не из алфавита
                 {
                     nomer = j; // Индекс буквы
                     d = nomer + 3; // Делаем смещение

                     // Проверяем, чтобы не вышли за пределы алфавита
                     if (d > 32)
                     {
                         d = d - 33;
                     }

                     massage[i] = alfavit[d]; // Меняем букву
                 }
             }
             s = new string(massage); // Собираем символы обратно в строку.
             File.WriteAllText("2.txt", s); // Записываем результат в файл.*/

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {


        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            string config = comboBox1.Text;
            string m = textBox1.Text;
            int nomer; // Номер в алфавите
            int key = 0;
            string s; //Результат
            int j; // Переменная для циклов
                   //string user_key = textBox2.Text; // смещение 
            bool isNumeric = int.TryParse(textBox2.Text, out key);
            string result;
            char[] massage = m.ToCharArray(); // Превращаем строку в массив символов.
            char[] alfavit = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'Z', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'X' };
            if (!isNumeric)
            {
                MessageBox.Show("Please enter a valid integer key.");
                return;
            }
            if (config == "Encrypt")
            {
                for (int i = 0; i < massage.Length; i++)
                {
                    // Ищем индекс буквы
                    for (j = 0; j < alfavit.Length; j++)
                    {
                        if (massage[i] == alfavit[j])
                        {
                            massage[i] = alfavit[j + key % alfavit.Length];
                            break;
                        }

                    }
                    // if (j == massage.Length) { break; }
                }
            }
            else
            {
                for (int i = 0; i < massage.Length; i++)
                {
                    // Ищем индекс буквы
                    for (j = 0; j < alfavit.Length; j++)
                    {
                        if (massage[i] == alfavit[j])
                        {
                            massage[i] = alfavit[j - key % alfavit.Length];
                            break;
                        }

                    }
                }
            }
            result = new string(massage);
            MessageBox.Show(result);
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string fileContent = sr.ReadToEnd();
                        //textBox1.Text("Содержимое файла:\n\n" + fileContent, "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = fileContent;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Выберите место для сохранения файла";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.Write(textBox1.Text); // Записываем текст из TextBox в файл
                        MessageBox.Show("Текст успешно записан в файл.", "Запись в файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при записи в файл: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}