using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace lab2
{

    public partial class Form1 : Form
    {
        public new string Name;
        public string Surname;
        public string Patronymic;
        public string birth;
        public string Speciality;
        public string curs;
        static public string City;
        static public int postIndex;
        static public string street;
        static public string house;
        static public string floate;
        public string group;
        public string ball;
        public string grants;
        public string gender;
        public static List<Student> Students = new List<Student>();

        public Adress adres = new Adress();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                Name = s1;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string s3 = textBox3.Text;
            if (!Regex.IsMatch(s3, "^[a-zA-Zа-яА-ЯёЁ ]*$"))
            {
                MessageBox.Show("Error");
            }
            else { Patronymic = textBox3.Text; }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSpec = this.comboBox1.SelectedItem.ToString();
            Speciality = selectedSpec.ToString();
            switch (comboBox1.Text)
            {
                case "ПОИТ":
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("4 группа");
                    comboBox2.Items.Add("5 группа");
                    comboBox2.Items.Add("6 группа");
                    break;
                case "ИСИТ":
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("1 группа");
                    comboBox2.Items.Add("2 группа");
                    comboBox2.Items.Add("3 группа");
                    break;
                case "ДЭЙиВИ":
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("9 группа");
                    comboBox2.Items.Add("10 группа");
                    break;
                case "ПОИБМС":
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("7 группа");
                    comboBox2.Items.Add("8 группа");
                    break;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));
            using (StreamReader rd = new StreamReader("students.xml"))
            {
                List<Student> students = (List<Student>)xml.Deserialize(rd);
                

                foreach (Student a in students)
                { 
                    


                        string text = $"Имя:{a.Name}\n Фамилия:{a.Surname} \n Отчество:{a.Patronymic} \n День рождения:{a.Birth} \n Специальность:{a.Speciality} \n Курс:{a.Curs} \n Группа:{a.Group}\n Средний балл:{a.Ball} \n  Стипендия:{a.Grants} \n  Пол:{a.Gender} \n Город: {Form1.City} \n Почтовый индекс: {Form2.postIndex} \n Улица: {Form2.street} \n Дом:{Form2.house} \n Квартира: {Form2.floate}";
                        richTextBox2.AppendText(text + Environment.NewLine);
                    
                }
                
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
          
            
            
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите специальность");
            }
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                // Ни один элемент не выбран
                MessageBox.Show("Выберите на каком вы курсе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Выберите группу");
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Выберите пол");
            }
            City = Form2.City;
            postIndex = Form2.postIndex;
            street = Form2.street;
            house = Form2.house;
           floate = Form2.floate;
            Form1.Students.Add(new Student(Name, Surname, Patronymic, birth, Speciality, curs, group, ball, grants, gender, City, postIndex, street, house, floate ));
            /*Student student = new Student(Name, Surname, Patronymic, birth, Speciality, curs, group, ball, grants, gender, City, postIndex, street, house, floate);

            ValidationContext context = new ValidationContext(student);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(student, context, results, true);

            if (isValid)
            {
                // сохраняем данные в базу
            }
            else
            {
                // обрабатываем ошибки валидации
                foreach (ValidationResult result in results)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }*/
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            monthCalendar1.SetDate(DateTime.Today);
            comboBox1.Text = " ";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            checkedListBox1.SelectedIndex = -1;
            comboBox2.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string s2 = textBox2.Text;
            if (!Regex.IsMatch(s2, "^[a-zA-Zа-яА-ЯёЁ ]*$"))
            {
                MessageBox.Show("Error");
            }
            else { Surname = textBox2.Text; }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedIndices.Count > 0)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
            }
            string Selectedcurs = this.checkedListBox1.Text.ToString();
            curs = Selectedcurs;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedgroup = this.comboBox2.SelectedItem.ToString();
            group = selectedgroup;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string s4 = textBox4.Text;
            if (Regex.IsMatch(s4, "^[a-zA-Zа-яА-ЯёЁ]*$"))
            {
                MessageBox.Show("Error");
            }
            else { ball = textBox4.Text.ToString(); }
            int number;
            if (int.TryParse(textBox4.Text, out number))
            {
                progressBar1.Maximum = 10;
                progressBar1.Minimum = 0;
                progressBar1.Value = number;
            }
            else
            {
                progressBar1.Value = 0;
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
                grants = textBox5.Text.ToString();
            }
            int number1;
            if (int.TryParse(textBox5.Text, out number1))
            {
                trackBar1.Maximum = 200;
                trackBar1.Minimum = 0;
                trackBar1.Value = number1;
            }
            else
            {
                trackBar1.Value = 0;
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Вычисляем возраст на основе выбранной даты
            DateTime birthDate = e.Start;
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            // Проверяем, соответствует ли возраст требуемому диапазону
            if (age < 18 || age > 30)
            {
                // Отменяем выбор даты
                monthCalendar1.SelectionStart = DateTime.Today;
                monthCalendar1.SelectionEnd = DateTime.Today;
            }
            else
            {
                DateTime selectedDate = e.Start;
                birth = selectedDate.ToShortDateString();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {

            XmlSerializer xml = new XmlSerializer(typeof(List<Student>)) ;
            using (FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, Students);
                MessageBox.Show("Данные успешно сохранены на XML;");

            }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        { 
            Form4 form4 = new Form4();
            form4.FillListView(Students);
            form4.Show();
            this.Hide();
        }

    }
    [Serializable]
    public partial class Student
    {
        //[Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }
        public string City { get; set; }
        //[CustomIndexValidation(ErrorMessage = "Некорректный индекс")]
        public int PostIndex { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Floate { get; set; }
        //[Required(ErrorMessage = "Фамилия обязательна")]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Birth { get; set; }
        public string Speciality { get; set; }
        public string Curs { get; set; }
        public string Group { get; set; }
        public string Ball { get; set; }
        public string Grants { get; set; }
        public string Gender { get; set; }  
        public Student()
        {

        }
        public Student(string name, string surname, string patronymic, string birth, string speciality, string curs, string group, string ball, string grants, string gender, string city, int postIndex, string street, string house, string floate)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birth = birth;
            Speciality = speciality;
            Curs = curs;
            Group = group;
            Ball = ball;
            Grants = grants;
            Gender = gender;
            City = city;
            PostIndex = postIndex;
            Street = street;
            House = house;
            Floate = floate;

        }
       
    }
    /*public class CustomIndexValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;

            var index = value.ToString();
            return index.Length == 6 && int.TryParse(index, out _);
        }
    }*/
    public partial class Form2
    {

    }
    public partial class Form3
    {

    }
    public partial class Form4
    {
        
    }
    public partial class Adress
    {
        
    }

}
