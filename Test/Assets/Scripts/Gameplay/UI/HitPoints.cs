using UnityEngine;
using TMPro;

namespace Gameplay.UI
{
    public class HitPoints : MonoBehaviour
    {
        
        [SerializeField]
        private EnemyPool _enemyPool;

        [SerializeField]
        private TMP_Text _hitPointsText;

        private int _hitPoints;

        private void OnEnable()
        {
            _enemyPool.EnemyDead += OnChangedHitPoints;     // подписка на событие уничтожения вражеского корабля
        }

        private void OnChangedHitPoints()
        {
            _hitPoints++;                                       // начисление очков
            _hitPointsText.text = "Hit points: " + _hitPoints;  // текстовое представление
        }

        private void OnDisable()
        {
            _enemyPool.EnemyDead -= OnChangedHitPoints;     // отписка от этого события
        }

    }
}
