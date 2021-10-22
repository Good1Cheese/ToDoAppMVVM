using System.Windows;

namespace ToDoAppMVVM.Views
{
    public partial class CalendarWindow : Window
    {
        public CalendarWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
