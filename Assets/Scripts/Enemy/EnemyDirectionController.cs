using UnityEngine;
using LearnGame.Movement;

namespace LearnGame.Enemy
{
	public class EnemyDirectionController : MonoBehaviour, IMovementDirectionSource
	{
		public Vector3 MovementDirection { get; private set; }

		void UpdateMovementDirection(Vector3 targetPosition)
		{
			var direction = targetPosition - transform.position;
			MovementDirection = direction.normalized;
		}
	}
}