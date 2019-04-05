using Autofac;
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
            DataContext = Ioc.Ioc.Instance.Resolve<IMainWindowViewModel>();
        }
    }
}
