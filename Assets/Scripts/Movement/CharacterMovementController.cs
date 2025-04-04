using UnityEngine;

namespace LearnGame.Movement
{
	[RequireComponent(typeof(CharacterController))]
	public class CharacterMovementController : MonoBehaviour
	{
		private static readonly float sqrEpsilon = Mathf.Epsilon * Mathf.Epsilon;

        
        [SerializeField]
		public static float _speed = 10f;
        [SerializeField]
        private float MaxRadiansDelta = 10f;
        public Vector3 MovementDirection { get; set; }
        public Vector3 LookDirection { get; set; }
        public float WhomSpeed = _speed;
        private CharacterController _CharacterController;

		protected void Awake()
		{
			_CharacterController = GetComponent<CharacterController>();
        }

	
		protected void Update()
		{
            if (gameObject.name == "Player")
            {
                WhomSpeed = PlayerMovementDirectionController._currentSpeed;
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