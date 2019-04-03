using Battleships.Models;

namespace Battleships.Business.BattleService
{
    public interface IBattleService<T, in TK>
    {
        T CreateBattle(TK settings);
        void EvaluateHit(T battle, MapCell hit);
    }
}
