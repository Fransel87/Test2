using UnityEngine;
using LearnGame.Movement;
using LearnGame.Enemy.States;

namespace LearnGame.Enemy
{
	public class EnemyDirectionController : MonoBehaviour, IMovementDirectionSource
	{
		public Vector3 MovementDirection { get; private set; }
        public float _currentEnemySpeed = CharacterMovementController._speed;
        public bool hasexecuted = false;
        protected void Update()
        {
            if (hasexecuted == true)   //ускорение при побеге
            {
                _currentEnemySpeed = 2 * CharacterMovementController._speed;
            }
        }
        public void UpdateMovementDirection(Vector3 targetPosition)
		{
			var realDirection = targetPosition - transform.position;
			MovementDirection = new Vector3(realDirection.x, 0 , realDirection.z).normalized;
		}
	}
}