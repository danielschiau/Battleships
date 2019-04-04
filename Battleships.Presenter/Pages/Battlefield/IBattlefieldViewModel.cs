using System;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Pages.Base;

namespace Battleships.Presenter.Pages.Battlefield
{
    public interface IBattlefieldViewModel : IViewModel
    {
        void Render(WorldCell[,] world, Action<WorldCell> onCellSelected);
    }
}
