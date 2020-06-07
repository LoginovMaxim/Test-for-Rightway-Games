
namespace Gameplay.Bonuses
{
    public interface ITakeBonus
    {
        void ApplyBonus(IBonusDealer bonusDealer);
    }

    public enum BonusType   // новый тип данных отвечающий за классификацию банусов
    {
        Fire,   // бонус скорострельности
        Armor   // бонус брони
    }
}
