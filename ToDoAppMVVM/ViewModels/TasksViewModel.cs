using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using ToDoAppMVVM.Models;

namespace ToDoAppMVVM.ViewModels
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        private Task _selectedTask;

        public event PropertyChangedEventHandler PropertyChanged;

        public TasksViewModel()
        {
            Tasks.Add(new Task("Сделать пагинацию в главном меню"));
            Tasks.Add(new Task("Короче сделать scrollable list при выборе даты в таске"));
            Tasks.Add(new Task("Сделать так, чтобы дата таска выбиралась при создании"));
            Tasks.Add(new Task("Залить все на гитхаб"));

            AddTask = new RelayCommand((obj) =>
            {
                TextBox inputTextBox = (TextBox)obj;

                if (string.IsNullOrEmpty(inputTextBox.Text) || FindTask(inputTextBox.Text) != null) { return; }

                var task = new Task(inputTextBox.Text);
                Tasks.Add(task);
                inputTextBox.Text = string.Empty;
            });

            RemoveTask = new RelayCommand((obj) =>
            {
                Tasks.Remove(FindTask((string)obj));
            });
        }

        public RelayCommand AddTask { get; set; }
        public RelayCommand RemoveTask { get; set; }
        public ObservableCollection<Task> Tasks { get; } = new();

        public Task SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTask)));
            }
        }

        public Task FindTask(string taskName)
        {
            return Tasks.FirstOrDefault(t => t.Title == taskName);
        }
    }
}