using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.IO;

namespace lab2
{
    public partial class Form3 : Form
    {
        public string Company;
        public string Post;
        public string expir;
        public string phone;
        public string sphere;
        public string salary;
        List<Work> worker = new List<Work>();
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            if (!Regex.IsMatch(s1, "^[a-zA-Zа-яА-ЯёЁ ]*$"))
            {
                MessageBox.Show("Error");
            }
            else
            {
                Company = s1;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string s2 = textBox2.Text;
            if (!Regex.IsMatch(s2, "^[a-zA-Zа-яА-ЯёЁ ]*$"))
            {
                MessageBox.Show("Error");
            }
            else
            {
                Post = s2;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string s3 = textBox3.Text;
            if (Regex.IsMatch(s3, "^[a-zA-Zа-яА-ЯёЁ]*$"))
            {
                MessageBox.Show("Error");
            }
            else
            {
                expir = textBox3.Text.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string s5 = textBox5.Text;
            if (Regex.IsMatch(s5, "^[a-zA-Zа-яА-ЯёЁ]*$"))
            {
                MessageBox.Show("Error");
            }
            else
            {
                phone = textBox5.Text.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedgroup = this.comboBox1.SelectedItem.ToString();
            sphere = selectedgroup;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string s4 = textBox4.Text;
            if (Regex.IsMatch(s4, "^[a-zA-Zа-яА-ЯёЁ]*$"))
            {
                MessageBox.Show("Error");
            }
            else
            {
                 salary = textBox4.Text.ToString();
            }
            int number2;
            if (int.TryParse(textBox4.Text, out number2))
            {
                trackBar1.Maximum = 2000;
                trackBar1.Minimum = 0;
                trackBar1.Value = number2;
            }
            else
            {
                trackBar1.Value = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите специальность");
            }
            this.worker.Add(new Work(Company, Post, expir, phone, sphere, salary));
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            comboBox1.Text = " ";


            XmlSerializer xml = new XmlSerializer(typeof(List<Work>));
            using (FileStream fs = new FileStream("workers.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, worker);
                MessageBox.Show("Данные успешно сохранены на XML;");

            }
        }
    }
    [Serializable]
    public class Work
    {
        public string Company { get; set; }
        public string Post { get; set; }
        public string Expir { get; set; }
        public string Phone { get; set; }
        public string Sphere { get; set; }
        public string Salary { get; set; }
        public Work()
        {

        }
        public Work(string _company, string _post, string _expir, string _phone, string _sphere, string salary)
        {
            Company = _company;
            Post = _post;
            Expir = _expir;
            Phone = _phone;
            Sphere = _sphere;
            Salary = salary;
        }
    }
}
