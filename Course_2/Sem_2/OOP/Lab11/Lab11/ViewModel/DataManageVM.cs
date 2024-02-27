using Lab11.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.ViewModel
{
    class DataManageVM: INotifyPropertyChanged
    {
        private List<Lector> allLectors = DataLector.GetAllLectors();
        public List<Lector> AllLectors
        {
            get { return allLectors; }
            set
            {
                allLectors = value;
                NotifyPropertyChanged("AllLectors");
            }
        }
        private int _idlector;
        public int Idlector
        {
            get { return _idlector; }
            set
            {
                if (_idlector != value)
                {
                    _idlector = value;
                    NotifyPropertyChanged("Idlector");
                }
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    NotifyPropertyChanged("Surname");
                }
            }
        }
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    NotifyPropertyChanged("Subject");
                }
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }
        private int _interval;
        public int interval
        {
            get { return _interval; }
            set
            {
                if (_interval != value)
                {
                    _interval = value;
                    NotifyPropertyChanged("interval");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
