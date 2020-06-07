using UnityEngine;
using Gameplay.ShipControllers.CustomControllers;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private bool _isRightWall;      // находится ли стена справа

    public bool IsRightWall => _isRightWall;


    private void OnCollisionEnter2D(Collision2D collision)      // проверка на столкновение со стеной
    {
        var playerShipController = collision.gameObject.GetComponent<PlayerShipController>();

        AllowMovement(playerShipController, false);
    }

    private void OnCollisionExit2D(Collision2D collision)       // проверка на размыкание контакта со стеной
    {
        var playerShipController = collision.gameObject.GetComponent<PlayerShipController>();

        AllowMovement(playerShipController, true);
    }


    private void AllowMovement(PlayerShipController playerShipController, bool isAllowed)   // установление правил движения игрока при контакте со стеной
    {
        if (playerShipController != null)
        {
            if (_isRightWall)
            {
                playerShipController.SetPossibleRightMove(isAllowed);
            }
            else
            {
                playerShipController.SetPossibleLeftMove(isAllowed);
            }
        }
    }

}
