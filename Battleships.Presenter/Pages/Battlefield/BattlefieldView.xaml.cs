using System.Windows.Controls;

namespace Battleships.Presenter.Pages.Battlefield
{
    /// <summary>
    /// Interaction logic for BattlefieldView.xaml
    /// </summary>
    public partial class BattlefieldView : UserControl
    {
        public BattlefieldView()
        {
            InitializeComponent();
            BattlefieldMap.SelectedCellsChanged += (sender, args) => (sender as DataGrid)?.Items.Refresh();
        }
    }
}
