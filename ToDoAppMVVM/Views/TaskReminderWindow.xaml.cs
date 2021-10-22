using System.Windows;
using ToDoAppMVVM.ViewModels;

namespace ToDoAppMVVM.Views
{
    public partial class TaskReminderWindow : Window
    {
        public TaskReminderWindow(CalendarViewModel dataContext, string textToRemind)
        {
            InitializeComponent();

            Closed += dataContext.OnTaskReminderClosed;
            DataContext = textToRemind;
        }
    }
}
