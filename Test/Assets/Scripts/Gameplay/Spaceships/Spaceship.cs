using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.UI;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    [RequireComponent(typeof(ShipController))]      // затребовать компонент типа ShipController
    [RequireComponent(typeof(MovementSystem))]      // затребовать компонент типа MovementSystem
    [RequireComponent(typeof(WeaponSystem))]        // затребовать компонент типа WeaponSystem
    public abstract class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField]
        private float _maxArmor;                            // максимальное количество брони

        private ShipController _shipController;
        private MovementSystem _movementSystem;
        private WeaponSystem _weaponSystem;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        public float MaxArmor => _maxArmor;
        public float CurrentArmor { get; protected set; }   // текущее количество брони


        private void Start()
        {
            _shipController = GetComponent<ShipController>();       //
            _movementSystem = GetComponent<MovementSystem>();       // кэширование компонентов
            _weaponSystem = GetComponent<WeaponSystem>();           //

            CurrentArmor = _maxArmor;

            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public virtual void ApplyDamage(IDamageDealer damageDealer)
        {
            CurrentArmor -= damageDealer.Damage;

            if (CurrentArmor <= 0)
                ProcessDie();
        }

        public abstract void ProcessDie();      // процесс уничтожения корабля
    }
}
