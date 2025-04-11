using UnityEngine;
using LearnGame.FSM;

namespace LearnGame.Enemy.States
{
	public class MoveForwardState : BaseState
	{
        private readonly EnemyTarget _target;
        private readonly EnemyDirectionController _enemyDirectionController;

        private EnemyAiController _enemyAiController;
        private Vector3 _currentPoint;
        public MoveForwardState(EnemyTarget target, EnemyDirectionController enemyDirectionController, EnemyAiController enemyAiController)
        {
            _target = target;
            _enemyDirectionController = enemyDirectionController;
            _enemyAiController = enemyAiController;
        }


        public override void Execute()
        {
            Vector3 targetPosition = _target.Closest.transform.position;

            if (_enemyAiController.HasExecutedFor2States == true)  // для обновления рандомного числа при переходах между состояниями, где имеется runaway
            {
                _enemyAiController.HasExecutedFor2States = false;
                _enemyAiController.Randomizer = Random.value;
            }

            if (_currentPoint != targetPosition)
            {
                _currentPoint = targetPosition;
                _enemyDirectionController.UpdateMovementDirection(targetPosition);
            }
        }
    }
}