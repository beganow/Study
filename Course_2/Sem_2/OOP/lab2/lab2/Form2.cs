using System;

using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace lab2
{
    public partial class Form2 : Form
    {
        static public string City;
       static  public int postIndex;
        static public string street;
        static public string house;
        static public string floate;
        Adress adress = new Adress(City, postIndex, street, house, floate);
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                City = s1;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string s3 = textBox3.Text;
            if (!Regex.IsMatch(s3, "^[a-zA-Zа-яА-ЯёЁ ]*$"))
            {
                MessageBox.Show("Error");
            }
            else
            {
                street = s3;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string s2 = textBox2.Text;
            if (Regex.IsMatch(s2, "^[a-zA-Zа-яА-ЯёЁ]*$"))
            {
                MessageBox.Show("Error");
            }
            else { postIndex = int.Parse(textBox2.Text.ToString()); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            house = textBox4.Text.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            floate = textBox5.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }
    }
    
    public partial class Adress
    {
        private string City;
        public string city { get { return City; } set { City = value; } }
        private int PostIndex;
        public int postIndex { get { return PostIndex; } set { PostIndex = value; } }
        private string Street;
        public string street { get { return Street; } set { Street = value; } }
        private string House;
        public string house { get { return House; } set { House = value; } }
        private string Float;
        public string floate { get { return Float; } set { Float = value; } }
        public Adress()
        {

        }
        public Adress(string _city, int _postIndex, string _street, string _house, string _floate)
        {
            City = _city;
            PostIndex = _postIndex;
            Street = _street;
            House = _house;
            Float = _floate;
        }
    }
    public partial class Form1
    {

    }
}
