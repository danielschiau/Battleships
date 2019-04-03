namespace Battleships.Business.BattleService
{
    public interface IBattleService<out T, in TK>
    {
        T CreateBattle(TK settings);
    }
}
