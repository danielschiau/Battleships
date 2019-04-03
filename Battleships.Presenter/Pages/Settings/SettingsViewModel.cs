using System.Collections.Generic;
using Battleships.Business.BattleService;
using Battleships.Models;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Battlefield;
using Battleships.Presenter.Pages.GamePlay;

namespace Battleships.Presenter.Pages.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly GamePlayViewModel _gamePlayViewModel;

        private BattlefieldViewModel _battlefieldViewModel;
        public BattlefieldViewModel BattlefieldViewModel
        {
            get => _battlefieldViewModel;
            set { _battlefieldViewModel = value; OnPropertyChanged(nameof(BattlefieldViewModel));}
        }


        public SettingsViewModel(INavigationService navigationService, IBattleService<SeaBattle, SeaBattleSettings> battleService, GamePlayViewModel gamePlayViewModel, BattlefieldViewModel battlefieldViewModel)
        {
            _navigationService = navigationService;
            _gamePlayViewModel = gamePlayViewModel;
            BattlefieldViewModel = battlefieldViewModel;

            var match = battleService.CreateBattle(new SeaBattleSettings
            {
                Columns = 10,
                Rows = 10,
                Ships = new List<Ship>
                {
                    new Ship
                    {
                        Name = "A",
                        Size = 3
                    },
                    new Ship
                    {
                        Name = "B",
                        Size = 2
                    }
                }
            });

            BattlefieldViewModel.Render(match);
        }

        public DelegateCommand NavigateToGamePlayCommand => new DelegateCommand(() =>
        {
            _navigationService.NavigateToViewModel(_gamePlayViewModel);
        });
    }
}
