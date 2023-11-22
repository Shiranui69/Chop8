using Chop8.Views;
namespace Chop8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _ClientsUserControl1 = new ClientsUserControl1();
            _ClientsUserControl1.DataContext = new ClientsUserControlViewModel();
        }

        public ClientsUserControl1 _ClientsUserControl1 { get; set; }
    }
}