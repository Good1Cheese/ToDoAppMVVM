using ToDoAppMVVM.ViewModels;

namespace ToDoAppMVVM
{
    public class ApplicationViewModel
    {
        public TasksViewModel TasksViewModel { get; set; } = new TasksViewModel();
        public CalendarViewModel CalendarViewModel { get; set; }

        public ApplicationViewModel()
        {
            CalendarViewModel = new CalendarViewModel(TasksViewModel);
        }
    }
}