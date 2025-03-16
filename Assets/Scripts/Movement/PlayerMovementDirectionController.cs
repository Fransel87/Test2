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
        public static float _currentSpeed = CharacterMovementController._speed;
        protected void Awake()
        {
			_camera = UnityEngine.Camera.main;
          
        }

        protected void Update()
		{
            if (Input.GetKey(KeyCode.Space))   //ускорение на пробел
            {
                _currentSpeed = _nTimesMoreSpeed * CharacterMovementController._speed;
            }
            else
            {
                if (BonusController._gotIt ==true)     //бонус 
                {
                    _currentSpeed = BonusController._speedBonus._nMoreSpeed * CharacterMovementController._speed;
                }
                else
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