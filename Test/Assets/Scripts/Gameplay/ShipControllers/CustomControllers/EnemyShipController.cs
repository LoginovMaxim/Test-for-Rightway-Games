using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipController : ShipController
{

    [SerializeField]
    private Vector2 _fireDelay;

    [SerializeField]
    private bool _complicatedMovement;              // присутствует ли у корабля способность к сложному движению

    [SerializeField]
    [Range(1, 3)]
    private int _periodLaterialMovement;            // период бокового движения корабля

    private bool _fire = true;
    private float _elapsedTimeLaterialMovement;     // время в течении которого корабль движется боком

    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);

        if (!_complicatedMovement)                  // если сложного движения нет, выходим из метода минуя логику бокового движения
            return;

        ProcessLateralMovement(movementSystem);     // процесс бокового движения
    }

    private void ProcessLateralMovement(MovementSystem movementSystem)
    {
        float direction = 1f;                   // направление бокового движения (по умолчанию вправо)

        if (_elapsedTimeLaterialMovement < 0)   // изменение направления движения корабля (влево)
            direction = -1f;

        movementSystem.LateralMovement(direction * Time.deltaTime * 0.1f);

        _elapsedTimeLaterialMovement -= Time.deltaTime;                 // отсчёт прошедшего времени бокового движения
        if (_elapsedTimeLaterialMovement < -_periodLaterialMovement)    // если мы вышли за рамки периода,
            _elapsedTimeLaterialMovement = _periodLaterialMovement;     // снова устанавливаем "секундомер" на заданный период
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }


    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }
}
