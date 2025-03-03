using UnityEngine;
using LearnGame.Movement;
using LearnGame.Shooting;
using Unity.VisualScripting;
using LearnGame.PickUp;


namespace LearnGame
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon _baseWeaponPrefab;

        [SerializeField]
        private Transform _hand;

        [SerializeField]
        private float _health = 2f;

        private CharacterMovementController _characterMovementController;
        private IMovementDirectionSource _movementDirectionSource;
        private ShootingController _shootingController;

        protected void Awake()
        {
            _characterMovementController = GetComponent<CharacterMovementController>();
            _movementDirectionSource = GetComponent<IMovementDirectionSource>();
            _shootingController = GetComponent<ShootingController>();
        }

        protected void Start()
        {
            _shootingController.SetWeapon(_baseWeaponPrefab, _hand);
        }
        protected void Update()
        {
            var direction = _movementDirectionSource.MovementDirection;
            var lookDirection = direction;
            if (_shootingController.HasTarget)
                lookDirection = (_shootingController.TargetPosition - transform.position).normalized;

            _characterMovementController.MovementDirection = direction;
            _characterMovementController.LookDirection = lookDirection;

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
                _shootingController.SetWeapon(pickup.WeaponPrefab, _hand);
                Destroy(other.gameObject);
            }
        }
    }
}
