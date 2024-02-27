using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private List<Author> DataBaseAuthors;
        private List<Book> DataBaseBooks;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Create()
        {
            try
            {
                var dbContext = new MyDbContext(connectionString);
                var unitOfWOrk = new UnitOfWork(dbContext);
                var nameOfAuthor = NameTextBox.Text;
                var adress = AddressTextBox.Text;
                var nameOfBook = BookNameTextBox.Text;
                var genre = GenreBookTextBox.Text;
                if (AuthorRadio.IsChecked == true && nameOfAuthor != "" && adress != "")
                {
                    unitOfWOrk.AuthorRepository.Add(new Author() { Name = nameOfAuthor, Address = adress });
                    unitOfWOrk.Commit();
                }
                if (BookRadio.IsChecked == true && nameOfBook != "" && genre != "")
                {
                    Author selectedAuthor = AuthorsList.SelectedItem as Author;
                    Author author = unitOfWOrk.AuthorRepository.Entities.Include(e => e.Books).Where(e => e.ID == selectedAuthor.ID).FirstOrDefault();
                    if (author.Books is null)
                    {
                        author.Books = new List<Book>();
                    }
                    author.Books.Add(new Book() { Title = nameOfBook, Genre = genre });
                    unitOfWOrk.Commit();
                }

            }
            catch (TargetException e)
            {
                MessageBox.Show("Не выбран автор книги");
            }
        }
        public void Read()
        {
            var dbContext = new MyDbContext(connectionString);
            var unitOfWOrk = new UnitOfWork(dbContext);
            DataBaseAuthors = unitOfWOrk.AuthorRepository.Entities.ToList();
            DataBaseBooks = unitOfWOrk.BookRepository.Entities.ToList();
            AuthorsList.ItemsSource = DataBaseAuthors;
            BooksList.ItemsSource = DataBaseBooks;

        }

        public void Update()
        {
            var dbContext = new MyDbContext(connectionString);
            var unitOfWOrk = new UnitOfWork(dbContext);
            var nameOfAuthor = NameTextBox.Text;
            var adress = AddressTextBox.Text;
            var nameOfBook = BookNameTextBox.Text;
            var genre = GenreBookTextBox.Text;
            Regex regex = new Regex(@"[\d!,./']");
            Match m = regex.Match(nameOfAuthor);
            Match a = regex.Match(nameOfBook);
            Match b = regex.Match(genre);
            if (AuthorsTab.IsSelected && FirstColumn.IsEnabled && nameOfAuthor != "" && adress != "" && m.Success == false)
            {
                Author selectedAuthor = AuthorsList.SelectedItem as Author;

                Author author = unitOfWOrk.AuthorRepository.Entities.First(e => e.ID == selectedAuthor.ID);
                author.Name = nameOfAuthor;
                author.Address = adress;
                unitOfWOrk.Commit();
            }
            if (m.Success)
            {
                MessageBox.Show("Не валидно имя!");
            }
            if (a.Success)
            {
                MessageBox.Show("Не валидно имя!");
            }
            if (b.Success)
            {
                MessageBox.Show("Не валиден жанр!");
            }
            if (BooksTab.IsSelected && SecondColumn.IsEnabled && nameOfBook != "" && genre != "" && a.Success == false && b.Success == false)
            {
                Book selectedBook = BooksList.SelectedItem as Book;

                Book book = unitOfWOrk.BookRepository.Entities.First(e => e.ID == selectedBook.ID);

                book.Title = nameOfBook;
                book.Genre = genre;
                unitOfWOrk.Commit();
            }

        }
        public void Delete()
        {
            try
            {
                var dbContext = new MyDbContext(connectionString);
                var unitOfWOrk = new UnitOfWork(dbContext);
                if (AuthorsTab.IsSelected)
                {
                    Author selectedAuthor = AuthorsList.SelectedItem as Author;

                    Author author = unitOfWOrk.AuthorRepository.Entities.First(e => e.ID == selectedAuthor.ID);
                    unitOfWOrk.AuthorRepository.Remove(author);
                    unitOfWOrk.Commit();
                }
                if (BooksTab.IsSelected)
                {
                    Book selectedBook = BooksList.SelectedItem as Book;

                    Book book = unitOfWOrk.BookRepository.Entities.First(e => e.ID == selectedBook.ID);
                    unitOfWOrk.BookRepository.Remove(book);
                    unitOfWOrk.Commit();
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите объект для удаления!");
            }

        }



        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }
        private void ReadButton_Click(Object sender, RoutedEventArgs e)
        {
            Read();
        }
        private void UpdateButton_Click(Object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void DeleteButton_Click(Object sender, RoutedEventArgs e)
        {
            Delete();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AuthorsList.Items.Clear();
            BooksList.Items.Clear();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AuthorsTab.IsSelected)
                {
                    List<Author> list = AuthorsList.ItemsSource as List<Author>;
                    list = list.OrderBy(user => user.Name).ToList();
                    AuthorsList.ItemsSource = null;
                    AuthorsList.ItemsSource = list;
                }
                if (BooksTab.IsSelected)
                {
                    List<Book> list = BooksList.ItemsSource as List<Book>;
                    list = list.OrderBy(book => book.Title).ToList();
                    BooksList.ItemsSource = null;
                    BooksList.ItemsSource = list;
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Не заполнена таблица");
            }

        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AuthorsTab.IsSelected && SearchTextBox != null)
                {
                    List<Author> list = AuthorsList.ItemsSource as List<Author>;
                    List<Author> Clear = new List<Author>();
                    List<Author> listSearch = new List<Author>();
                    foreach (Author author in list.ToList())
                    {
                        if (author.Name.Contains(SearchTextBox.Text))
                        {
                            listSearch.Add(author);
                        }
                    }
                    AuthorsList.ItemsSource = Clear;
                    AuthorsList.ItemsSource = listSearch;
                }
                if (BooksTab.IsSelected && SearchTextBox != null)
                {
                    List<Book> list = BooksList.ItemsSource as List<Book>;
                    List<Book> Clear = new List<Book>();
                    List<Book> listSearch = new List<Book>();
                    foreach (Book book in list.ToList())
                    {
                        if (book.Title.Contains(SearchTextBox.Text))
                        {
                            listSearch.Add(book);
                        }
                    }
                    BooksList.ItemsSource = Clear;
                    BooksList.ItemsSource = listSearch;
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Пустая таблица");
            }

        }
    }
}
