using LearnGame.Bonus;
using UnityEngine;


namespace LearnGame.Movement
{
    public class PlayerMovementDirectionController : MonoBehaviour, IMovementDirectionSource 
    {
		public Vector3 MovementDirection { get; private set; }
		private UnityEngine.Camera _camera;
        [SerializeField]
        private int _nTimesMoreSpeed = 2;  // увеличение скорости в n раз
        public float _currentSpeed;
        protected void Start()
        {
			_camera = UnityEngine.Camera.main;
          
        }

        protected void Update()
		{
            if (Input.GetKey(KeyCode.Space))   //ускорение на пробел
            {
                _currentSpeed = _nTimesMoreSpeed * CharacterMovementController._speed;
            }
            else if (BonusController.counter == 0)
            {
                _currentSpeed = CharacterMovementController._speed;
            }
                var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
			var direction = new Vector3(horizontal, 0, vertical);
			direction = _camera.transform.rotation * direction;
			direction.y = 0;
			MovementDirection = direction.normalized;
        }
	}
}