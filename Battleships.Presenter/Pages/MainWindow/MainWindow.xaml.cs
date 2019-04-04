using Autofac;
using Battleships.Presenter.Ioc;
using MahApps.Metro.Controls;

namespace Battleships.Presenter.Pages.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = IocSetup.Instance.Resolve<IMainWindowViewModel>();
        }
    }
}
