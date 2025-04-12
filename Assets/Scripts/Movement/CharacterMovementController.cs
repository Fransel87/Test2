using LearnGame.Enemy;
using UnityEngine;

namespace LearnGame.Movement
{
	[RequireComponent(typeof(CharacterController))]
	public class CharacterMovementController : MonoBehaviour
	{
		private static readonly float sqrEpsilon = Mathf.Epsilon * Mathf.Epsilon;
        
		public static float _speed = 10f;
        [SerializeField]
        private float MaxRadiansDelta = 10f;
        public Vector3 MovementDirection { get; set; }
        public Vector3 LookDirection { get; set; }

        private float WhomSpeed = _speed;
        private CharacterController _CharacterController;
		private EnemyDirectionController _enemyDirectionController;
		private PlayerMovementDirectionController _playerMovementDirectionController;

        protected void Awake()
		{
			_CharacterController = GetComponent<CharacterController>();
			_playerMovementDirectionController = GetComponent<PlayerMovementDirectionController>();
            _enemyDirectionController = GetComponent<EnemyDirectionController>();
        }

	
		protected void Update()
		{
            if (gameObject.layer == LayerUtils.PlayerLayer)
            {
                WhomSpeed = _playerMovementDirectionController._currentSpeed;
            }
			if (gameObject.layer == LayerUtils.EnemyLayer)
			{
				WhomSpeed = _enemyDirectionController._currentEnemySpeed;
            }
            Translate();
			if (MaxRadiansDelta > 0f && LookDirection != Vector3.zero)
				Rotate();
		}
		private void Translate() {

            var delta = MovementDirection * WhomSpeed * Time.deltaTime;
            _CharacterController.Move(delta);
        }
		private void Rotate()
		{
			var currentLookDirection = transform.rotation * Vector3.forward;
			float sqrMagnitude = (currentLookDirection - LookDirection).sqrMagnitude;
			if (sqrMagnitude > sqrEpsilon)
			{
				var newRotation = Quaternion.Slerp(
					transform.rotation,
					Quaternion.LookRotation(LookDirection, Vector3.up),
					MaxRadiansDelta * Time.deltaTime
					);
				transform.rotation = newRotation;
					}

		}

	}
}