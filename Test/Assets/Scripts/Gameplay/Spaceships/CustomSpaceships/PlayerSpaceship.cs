using Gameplay.ShipSystems;
using Gameplay.UI;
using Gameplay.Bonuses;
using Gameplay.Weapons;
using UnityEngine.Events;

namespace Gameplay.Spaceships.CustomSpaceships
{
    public class PlayerSpaceship : Spaceship, ITakeBonus                // у корабля играка есть возможность использовать бонусы
    {
        public event UnityAction<float> ArmorChanged;                   // событие вызываемое при изменении количества брони игрока

        public override void ApplyDamage(IDamageDealer damageDealer)
        {
            CurrentArmor -= damageDealer.Damage;
            ArmorChanged?.Invoke(CurrentArmor);                  // вызов события

            if (CurrentArmor <= 0)
                ProcessDie();
        }

        public void ApplyBonus(IBonusDealer bonusDealer)        // метод применения бонусов
        {
            switch (bonusDealer.BonusType)                      // классификация бонусов по типу
            {
                case BonusType.Armor:
                    ApplyArmorBonus(bonusDealer.BonusValue);
                    break;
                case BonusType.Fire:
                    ApplyFireBonus(bonusDealer.BonusValue);
                    break;
            }
        }

        private void ApplyArmorBonus(float armor)               // применить бонус брони
        {
            CurrentArmor += armor;

            if (CurrentArmor > MaxArmor)
                CurrentArmor = MaxArmor;

            ArmorChanged?.Invoke(CurrentArmor);                 // вызов события
        }

        private void ApplyFireBonus(float gainCoefficient)      // применить бонус брони
        {
            foreach (var weapon in WeaponSystem.Weapons)
            {
                weapon.SetCoolDown(weapon.Cooldown * gainCoefficient);
            }
        }

        public override void ProcessDie()
        {
            // объект ищется в сцене один раз, поэтому считаю вызов метода FindObjectOfType оправданным
            FindObjectOfType<LosePanel>().ShowLosePanel();

            Destroy(gameObject);
        }
    }
}
