using System.ComponentModel;

namespace ToDoAppMVVM.Models
{
    public class Task : INotifyPropertyChanged
    {
        private string _title;

        public event PropertyChangedEventHandler PropertyChanged;

        public Task(string title)
        {
            Title = title;
        }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value)) { return; }

                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

    }
}
