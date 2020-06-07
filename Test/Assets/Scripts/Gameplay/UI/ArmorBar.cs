using Gameplay.Spaceships;
using Gameplay.Spaceships.CustomSpaceships;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class ArmorBar : MonoBehaviour
    {
        [SerializeField]
        private PlayerSpaceship _playerSpaceship;

        [SerializeField]
        private Slider _armorBar;

        private void OnEnable()
        {
            _playerSpaceship.ArmorChanged += OnChangeArmor;     // подписка на событие изменения количества брони
        }

        private void OnChangeArmor(float value)
        {
            _armorBar.value = _playerSpaceship.CurrentArmor / _playerSpaceship.MaxArmor;    // изменяем значение слайдера в безразмерных единицах
        }

        private void OnDisable()
        {
            _playerSpaceship.ArmorChanged -= OnChangeArmor;     // отписка от этого события
        }
    }
}
