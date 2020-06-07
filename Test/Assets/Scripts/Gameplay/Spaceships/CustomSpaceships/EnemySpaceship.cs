using UnityEngine;
using Gameplay.Bonuses;

namespace Gameplay.Spaceships.CustomSpaceships
{
    public class EnemySpaceship : Spaceship
    {
        [SerializeField]
        private Bonus _bonusPrefab;

        [SerializeField]
        [Range(2, 9)]
        private int _dropChance;

        public override void ProcessDie()
        {
            // EnemyPool не кэшируется, так как вызывается единажды
            transform.parent.gameObject.GetComponent<EnemyPool>().OnEnemyDead();

            TryToDropBonus();
            Destroy(gameObject);
        }

        private void TryToDropBonus()
        {
            if (Random.Range(0, _dropChance) == 0)
            {
                if (_bonusPrefab != null)
                    Instantiate(_bonusPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
