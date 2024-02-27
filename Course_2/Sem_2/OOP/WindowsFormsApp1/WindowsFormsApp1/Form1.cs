using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form, ICalculator
    {
        public delegate string InString(string str);
        public static event InString example;
        public static string Changeble(string str)
        {
            return Convert.ToString(str);
        }
        public Form1()
        {
            InitializeComponent();
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void label2_Click(object sender, EventArgs e)
        {

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s1, s2, s3, s4, i;
                int p, r;
                InString instring = new InString(Changeble);
                example += instring;
                s1 = example(textBox1.Text);
                s2 = example(textBox3.Text);
                s3 = example(textBox4.Text);
                s4 = example(textBox5.Text);
                i = example(textBox6.Text);
                int length = textBox1.TextLength;
                char[] delimiters = new char[] { '.', '!', '?' };
                switch (comboBox1.Text)
                {
                    case "замена подстроки на другую подстроку":
                        if (!s1.Contains(s2))
                        {
                            textBox2.Text = "";
                            MessageBox.Show("Строка не содержит исходную подстроку");
                        }
                        else { textBox2.Text = Convert.ToString(s1.Replace(s2, s3)); }
                        break;
                    case "":
                        MessageBox.Show("Выберите операцию");
                        break;
                    case "удаление заданных подстрок (символов)":
                        if (!s1.Contains(s4))
                        {
                            textBox2.Text = "";
                            MessageBox.Show("Строка не содержит исходную подстроку");
                        }
                        else { textBox2.Text = Convert.ToString(s1.Replace(s4, "")); }
                        break;
                    case "получение символа по индексу":
                        p = int.Parse(i);
                        char ch = s1[p];
                        textBox2.Text = Convert.ToString(ch);
                        break;
                    case "длина строки":
                        if (s1 != "")
                            textBox2.Text = Convert.ToString(length);
                        break;
                    case "количество гласных и согласных":
                        int vowels = 0;
                        int consonants = 0;
                        for (r = 0; r < s1.Length; r++)
                        {
                            char ch1 = char.ToLower(s1[r]);
                            if (ch1 == 'a' || ch1 == 'e' || ch1 == 'i' || ch1 == 'o' || ch1 == 'u')
                            {
                                vowels++;
                            }
                            else if (ch1 >= 'a' && ch1 <= 'z')
                            {
                                consonants++;
                            }
                        }

                        textBox2.Text = Convert.ToString($"Гласных: {vowels} , согласных: {consonants}");
                        break;
                    case "количество предложений":
                        int count = s1.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
                        textBox2.Text = Convert.ToString($"Количество предложений : {count} ");
                        break;
                    case "количество слов в строке":
                        int wordCount = s1.Split(new char[] { ' ', '.', ',', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        textBox2.Text = Convert.ToString($"Количество слов в строке: {wordCount}");
                        break;

                }
            }
            catch
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MessageBox.Show("Вводить можно только строку, проверьте что вы ввели ");
            }
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void label5_Click(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        public void label6_Click(object sender, EventArgs e)
        {

        }

        public void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
