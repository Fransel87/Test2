using UnityEngine;
using LearnGame.Movement;
using LearnGame.Shooting;
using LearnGame.PickUp;
using LearnGame.Bonus;

namespace LearnGame
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon _baseWeaponPrefab;

        [SerializeField]
        private SpeedBonus _BonusPrefab;

        [SerializeField]
        private Transform _hand;

        [SerializeField]
        private float _health = 10f;
        private float _maxHealth;
        [SerializeField]
        private float _kForHealthForRunAwayDevidedOn100 = 0.3f;
        public bool IsPickedUpWeapon;
        

        public bool CounterHealth = false;
        public static int Counter1 = 0;

        private CharacterMovementController _characterMovementController;
        private IMovementDirectionSource _movementDirectionSource;
        private ShootingController _shootingController;
        private BonusController _bonusController;

        protected void Awake()
        {
            _characterMovementController = GetComponent<CharacterMovementController>();
            _movementDirectionSource = GetComponent<IMovementDirectionSource>();
            _shootingController = GetComponent<ShootingController>();
            _bonusController = GetComponent<BonusController>();
            _maxHealth = _health;
            IsPickedUpWeapon = false;
        }

             protected void Start()
        {
            SetWeapon(_baseWeaponPrefab);
        }
        protected void Update()
        {
            var direction = _movementDirectionSource.MovementDirection;
            var lookDirection = direction;
            if (_shootingController.HasTarget)
                lookDirection = (_shootingController.TargetPosition - transform.position).normalized;

            _characterMovementController.MovementDirection = direction;
            _characterMovementController.LookDirection = lookDirection;
            if (_health <= _maxHealth* _kForHealthForRunAwayDevidedOn100)
                CounterHealth = true;

            if (_health <= 0f)
                Destroy(gameObject);

        }

        protected void OnTriggerEnter(Collider other)
        {
            if (LayerUtils.IsBullet(other.gameObject))
            {
                var bullet = other.gameObject.GetComponent<Bullet>();
                _health -= bullet.Damage;
                Destroy(other.gameObject);

            }
            else if (LayerUtils.IsPickUp(other.gameObject))
            {
                var pickup = other.gameObject.GetComponent<PickUpWeapon>();
                pickup.PickUp(this);
                IsPickedUpWeapon = true;
                Destroy(other.gameObject);
            }
            else if (LayerUtils.IsPickUpBonus(other.gameObject))
            {
                if (gameObject.layer == LayerUtils.PlayerLayer && Counter1 == 0)
                {
                    var pickup = other.gameObject.GetComponent<PickUpBonus>();
                    pickup.PickUp(this);
                    Counter1++;
                    Destroy(other.gameObject);
                }
                
            }
        }
        public void SetWeapon(Weapon weapon)
        {
            _shootingController.SetWeapon(weapon, _hand);
        }

        public void SetBonus (SpeedBonus bonus)
        {
            _bonusController.SetBonus(bonus, _hand);
        }
    }
}
