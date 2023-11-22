using Chop8.Views;
namespace Chop8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _ClientsUserControl1 = new ClientsUserControl1();
            _ClientsUserControl1.DataContext = new ClientsUserControlViewModel();
            _SecurytiGuardsUserControl = new SecurityGuardsUserControl();
            _SecurytiGuardsUserControl.DataContext = new SecurityGuardsUserControlViewModel();
        }

        public ClientsUserControl1 _ClientsUserControl1 { get; set; }
        public SecurityGuardsUserControl _SecurytiGuardsUserControl { get; set; }
    }
}