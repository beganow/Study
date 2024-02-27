using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab2
{
   
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private ComboBox myComboBox;
        private TextBox mytextBox;
        private Label timeLabel;
        private Label timeLabel1;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            label1.Text = "Сортировка по:";
            ComboBox newComboBox = new ComboBox();
            newComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            newComboBox.Location = new Point(label1.Location.X + 100, label1.Location.Y);
            this.Controls.Add(newComboBox);
            myComboBox = newComboBox;
          
            if (mytextBox != null && mytextBox.Visible)
            {
                this.Controls.Remove(mytextBox);
            }
            myComboBox.Items.Add("Курсу");
            myComboBox.Items.Add("Ср. баллу");
            myComboBox.SelectedIndexChanged += (s, ev) =>
            {
                string sortBy = myComboBox.SelectedItem.ToString();
                SortBy(sortBy);
            }; 
            myComboBox.SelectedIndexChanged += new EventHandler(myComboBox_SelectedIndexChanged);
            SaveListViewData1("sort.xml");


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "Поиск";
            TextBox newTextBox = new TextBox();
            newTextBox.Location = new Point(label1.Location.X + 50, label1.Location.Y);
            newTextBox.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(newTextBox);
            if (myComboBox != null && myComboBox.Visible)
            {
                this.Controls.Remove(myComboBox);
            }
            mytextBox = newTextBox;
            mytextBox.TextChanged += new EventHandler(mytextBox_TextChanged);
            mytextBox.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    int numQuery;
                    string query = mytextBox.Text;
                    bool isNum = int.TryParse(query, out numQuery);
                    List<Student> results = SearchStudents(query);
                    listView2.Items.Clear();
                    foreach (Student student in results)
                    {
                        if (isNum && int.Parse(student.Ball) <= numQuery && numQuery<=10)
                        {
                            ListViewItem item = new ListViewItem(student.Name);
                            item.SubItems.Add(student.Surname);
                            item.SubItems.Add(student.Patronymic);
                            item.SubItems.Add(student.Speciality);
                            item.SubItems.Add(student.Ball);
                            item.SubItems.Add(student.Curs);
                            listView2.Items.Add(item);
                           
                        }
                        else if (!isNum)
                        {
                            ListViewItem item = new ListViewItem(student.Name);
                            item.SubItems.Add(student.Surname);
                            item.SubItems.Add(student.Patronymic);
                            item.SubItems.Add(student.Speciality);
                            item.SubItems.Add(student.Ball);
                            item.SubItems.Add(student.Curs);
                            if (listView2.Columns.Cast<ColumnHeader>().Any(col => Regex.IsMatch(item.SubItems[col.Index].Text, query, RegexOptions.IgnoreCase)) && !string.IsNullOrEmpty(query))
                            {
                                listView2.Items.Add(item);
                            }
                            else
                            {
                                listView2.Items.Remove(item);
                            }
                        }
                    }
                    SaveListViewData("search.xml");
                }
            };

        }
        private void mytextBox_TextChanged(object sender, EventArgs e)
        {
            // Получаем текущее время
            DateTime now = DateTime.Now;

            // Выводим время ввода в textbox на метку
            
            timeLabel.Text = "Поиск" + " " + now.ToString($"дата и время: {now:U}");
        }
        private void myComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime now1 = DateTime.Now;
            timeLabel1.Text = "Сортировка" + " " + now1.ToString($"дата и время: {now1:U}");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0.1 Dev:Obodov Pavel");
        }

       
        private void Form4_Load(object sender, EventArgs e)
        {
            int count = listView1.Items.Count;
            label3.Text = count.ToString();

            timeLabel = new Label();
            timeLabel.Text = "";
            timeLabel.Location = new Point(label4.Location.X + 120, label4.Location.Y);
           timeLabel.Size= new Size(200,20);
            this.Controls.Add(timeLabel);
            timeLabel1 = new Label();
            timeLabel1.Text = "";
            timeLabel1.Location = new Point(label4.Location.X + 120, label4.Location.Y+30);
            timeLabel1.Size = new Size(200, 20);
            this.Controls.Add(timeLabel1);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        public void FillListView(List<Student> students)
        {
            listView1.Items.Clear();
            foreach (Student student in Form1.Students)
            {
                ListViewItem item = new ListViewItem(student.Name);
                item.SubItems.Add(student.Surname);
                item.SubItems.Add(student.Patronymic);
                item.SubItems.Add(student.Speciality);
                item.SubItems.Add(student.Ball);
                item.SubItems.Add(student.Curs);
                listView1.Items.Add(item);
            }
        }
        private List<Student> SearchStudents(string query)
        {
            List<Student> results = new List<Student>();

            if (int.TryParse(query, out int queryNumber))
            {
                // фильтруем по среднему баллу, если введено число
                results = Form1.Students.Where(student => int.TryParse(student.Ball, out int ball) && ball <= queryNumber).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(query))
            {
                // иначе осуществляем поиск с использованием регулярных выражений
                string regexQuery = $"(?i){query}"; // игнорируем регистр
                results = Form1.Students.Where(student =>
                    Regex.IsMatch(student.Name, regexQuery) ||
                    Regex.IsMatch(student.Surname, regexQuery) ||
                    Regex.IsMatch(student.Patronymic, regexQuery) ||
                    Regex.IsMatch(student.Speciality, regexQuery) ||
                    Regex.IsMatch(student.Ball, regexQuery)).ToList();
            }
            return results;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
       
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView2.Clear();
        }

        private void SortBy(string sortBy)
        {
            List<Student> sortedStudents;
            if (sortBy == "Ср. баллу")
            {
                sortedStudents = Form1.Students.OrderBy(s => int.Parse(s.Ball)).ToList();
            }
            else if (sortBy == "Курсу")
            {
                sortedStudents = Form1.Students.OrderBy(s => int.Parse(s.Curs)).ToList();
            }
            else
            {
                return;
            }

            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (var student in sortedStudents)
            {
                ListViewItem item = new ListViewItem(student.Name);
                item.SubItems.Add(student.Surname);
                item.SubItems.Add(student.Patronymic);
                item.SubItems.Add(student.Speciality);
                item.SubItems.Add(student.Ball);
                item.SubItems.Add(student.Curs);
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.Items.Count - 1);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        private void SaveListViewData(string fileName)
        {
            List<Student> students = new List<Student>();

            foreach (ListViewItem item in listView2.Items)
            {
                Student student = new Student();
                student.Name = item.SubItems[0].Text;
                student.Surname = item.SubItems[1].Text;
                student.Patronymic = item.SubItems[2].Text;
                student.Speciality = item.SubItems[3].Text;
                student.Ball = item.SubItems[4].Text;
                student.Curs = item.SubItems[5].Text;

                students.Add(student);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, students);
            }
        }
        private void SaveListViewData1(string fileName)
        {
            List<Student> students = new List<Student>();

            foreach (ListViewItem item in listView1.Items)
            {
                Student student = new Student();
                student.Name = item.SubItems[0].Text;
                student.Surname = item.SubItems[1].Text;
                student.Patronymic = item.SubItems[2].Text;
                student.Speciality = item.SubItems[3].Text;
                student.Ball = item.SubItems[4].Text;
                student.Curs = item.SubItems[5].Text;

                students.Add(student);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, students);
            }
        }
                ToolStrip toolStrip2 = new ToolStrip();

        private bool showPanelButtonAdded = false;

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            toolStrip2.Location = toolStrip1.Location;
            this.Controls.Add(toolStrip2);

            if (toolStrip1.Visible)
            {
                // если панель видима, скрываем ее и добавляем кнопку
                toolStrip1.Visible = false;

                // добавляем кнопку только если она еще не добавлена
                if (!showPanelButtonAdded)
                {
                    ToolStripButton toolStripButton5 = new ToolStripButton();
                    toolStripButton5.Text = "Показать панель";
                    toolStrip2.Items.Add(toolStripButton5);
                    toolStripButton5.Click += new EventHandler(toolStripButton5_Click);
                    showPanelButtonAdded = true;
                }

                toolStrip2.Visible = true;
            }
            else
            {
                // если панель скрыта, удаляем кнопку и отображаем панель
                toolStrip2.Items.Clear();
                toolStrip1.Visible = true;
            }
        }

        // метод обработчика события для кнопки toolStripButton6
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = true;
            toolStrip2.Visible = false;
        }
    }
  
    }
