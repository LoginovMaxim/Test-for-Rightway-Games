using Gameplay.ShipSystems;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        private bool _canMoveRight = true;      // может ли корабль игрока двигаться вправо
        private bool _canMoveLeft = true;       // может ли корабль игрока двигаться влево

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            float direction = Input.GetAxis("Horizontal");

            if (TryMoveTo(direction))   // выйти из метода, если движение пользователя в заданном направлении не разрешено
                return;

            movementSystem.LateralMovement(direction * Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }


        // вернуть true если корабль не может двигаться вправо и нажимает на копку "вправо" или не может двигаться влево и нажимает на копку "влево"
        private bool TryMoveTo(float direction) => (!_canMoveRight && direction > 0) || (!_canMoveLeft && direction < 0);

        public void SetPossibleRightMove(bool value) => _canMoveRight = value;  // установление возможности двигаться вправо

        public void SetPossibleLeftMove(bool value) => _canMoveLeft = value;    // установление возможности двигаться влево

    }
}
