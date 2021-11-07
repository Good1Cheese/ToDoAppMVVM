using ToDoAppMVVM.Views;
using ToDoAppMVVM.Models;
using System;
using System.Windows.Media;

namespace ToDoAppMVVM.ViewModels
{
    public class CalendarViewModel
    {
        private const string _NOTIFICATION_SOUND_PATH = @"C:\Users\29166.DESKTOP-3A4STP9\source\repos\WPF Learning\ToDoAppMVVM\ToDoAppMVVM\Assets\DeadlineSound.mp3";
        private readonly TasksViewModel _taskViewModel;
        private CalendarWindow _calendarWindow;
        private readonly MediaPlayer _mediaPlayer = new();
        private string _currentTaskTitle;

        public CalendarViewModel(TasksViewModel taskViewModel)
        {
            _taskViewModel = taskViewModel;

            OpenCalendar = new RelayCommand((object obj) =>
            {
                _calendarWindow = new CalendarWindow(this);
                _currentTaskTitle = (string)obj;

                _calendarWindow.ShowDialog();
            });

            CloseCalendar = new RelayCommand((object obj) =>
            {
                RemindTask(TaskTime.GetDateTime());
            });
        }

        public RelayCommand OpenCalendar { get; set; }
        public RelayCommand CloseCalendar { get; set; }
        public TaskTime TaskTime { get; set; } = new TaskTime();

        public async System.Threading.Tasks.Task RemindTask(TimeSpan timeSpan)
        {
            string taskTitle = _currentTaskTitle;

            await System.Threading.Tasks.Task.Delay(timeSpan);

            if (_taskViewModel.FindTask(taskTitle) == null) { return; }

            PlayReminderSound();
            new TaskReminderWindow(this, taskTitle).ShowDialog();
        }

        public void OnTaskReminderClosed(object sender, EventArgs e)
        {
            _mediaPlayer.Stop();
        }

        private void PlayReminderSound()
        {
            Uri source = new(_NOTIFICATION_SOUND_PATH, UriKind.RelativeOrAbsolute);
            _mediaPlayer.Open(source);
            _mediaPlayer.Play();
        }
    }
}
