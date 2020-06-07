using UnityEngine;
using Gameplay.Weapons.Projectiles;

public class EnergyBall : Projectile
{
    protected override void Move(float speed)   // тот же метод что и у LaserBeam, но при желании можно изменить характер движения
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
