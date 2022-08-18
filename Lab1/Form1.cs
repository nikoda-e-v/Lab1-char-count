using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        string selectfilename;
        string resultfilename;
        int commoncount;
        int charcount;

        public Form1()
        {
            InitializeComponent();
        }

        // 1) кнопка выбора файла Текст.тхт с формы
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            selectfilename = openFileDialog1.FileName;
            textBox1.Text = selectfilename;
            // обнуляем данные для нового подсчета
            commoncount = 0; charcount = 0;
            textBox2.Text = "";
            textBox3.Text = "";
        }

        // 2) для подсчета количества всех символов в файле Текст.тхт
        private void btnCalcStat_Click(object sender, EventArgs e)
        {
            if (selectfilename != null)
            {
                // читаем файл в строку
                string fileText = File.ReadAllText(selectfilename, Encoding.Default);

                // в цикле подсчитываем каждый символ строки
                foreach (char symbol in fileText)
                {
                    commoncount++; // получаем общее число символов


                    // отдельно считаем количество букв
                    if (Char.IsLetter(symbol)) charcount++;// получаем общее число букв
                }
                // 3) окно для вывода результатов подсчета 
                string resultText = "Загальна кількість символіву файлі: " + commoncount.ToString() + "\n";
                resultText += "Кількість букв у файлі: " + charcount.ToString();
                textBox2.Text = "Підрахунок завершено успішно.";
                MessageBox.Show(resultText, "Результат підрахунку символів у файлі");
            }           
        }

        // 4) кнопка для записи результата в файл Результат.тхт 
        private void btnSaveStat_Click(object sender, EventArgs e)
        {
            if (selectfilename != null)
            {
                // создаем файл Результат.txt в той же папке, что и файл Текст.тхт
                resultfilename = selectfilename + "Результат.txt";

                // Формируем строки для записи в файл  Результат.txt
                string resultText = "Файл " + selectfilename + "\r\n";
                resultText += "\r\n" + "Загальна кількість символіву файлі: " + commoncount.ToString() + "\r\n";
                resultText += "Кількість букв у файлі: " + charcount.ToString();
                // сохраняем статистику в файл
                File.WriteAllText(resultfilename, resultText);
                textBox3.Text = resultfilename;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
