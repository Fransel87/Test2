using UnityEngine;
using UnityEngine.UIElements;

namespace LearnGame.Movement
{
	[RequireComponent(typeof(CharacterController))]
	public class CharacterMovementController : MonoBehaviour
	{
		private static readonly float sqrEpsilon = Mathf.Epsilon * Mathf.Epsilon;

        [SerializeField]
        private int _nTimesMoreSpeed = 2;  // увеличение скорости в n раз
        [SerializeField]
		public static float _speed = 10f;
        [SerializeField]
        private float MaxRadiansDelta = 10f;
        public Vector3 MovementDirection { get; set; }
        public Vector3 LookDirection { get; set; }

        private CharacterController _CharacterController;

		protected void Awake()
		{
			_CharacterController = GetComponent<CharacterController>();
		}

	
		protected void Update()
		{
			if (Input.GetKey(KeyCode.Space))   //ускорение на пробел
			{
				_speed = _nTimesMoreSpeed * 10f;
			}
			else
			{
				_speed = 10f;
			}

				Translate();
			if (MaxRadiansDelta > 0f && LookDirection != Vector3.zero)
				Rotate();
		}
		private void Translate() {

            var delta = MovementDirection * _speed * Time.deltaTime;
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