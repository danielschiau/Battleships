using Battleships.GameEngine.Games;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.Battlefield;

namespace Battleships.Presenter.Pages.GamePlay
{
    public interface IGamePlayViewModel : IViewModel
    {
        IBattlefieldViewModel BattleField { get; set; }
        void StartBattle(GameSettings settings);
    }
}
