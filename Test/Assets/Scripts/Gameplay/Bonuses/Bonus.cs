using UnityEngine;

namespace Gameplay.Bonuses
{
    public class Bonus : MonoBehaviour, IBonusDealer
    {

        [SerializeField]
        private BonusType _bonusType;   // тип бонуса

        [SerializeField]
        private float _bonusValue;      // числовое значени бонуса

        [SerializeField]
        private float _speedFall;       // скорость падения бонуса


        public BonusType BonusType => _bonusType;
        public float BonusValue => _bonusValue;


        private void Update()
        {
            transform.Translate(_speedFall * Vector3.down * Time.deltaTime);    // движение бонуса вниз с постоянной скоростью
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<ITakeBonus>();

            if (damagableObject != null)
            {
                damagableObject.ApplyBonus(this);   // применить бонус к объекту имеющему интерфейс ITakeBonus
                Destroy(gameObject);
            }
        }
    }
}
