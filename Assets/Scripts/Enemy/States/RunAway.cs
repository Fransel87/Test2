using UnityEngine;
using LearnGame.FSM;
using LearnGame.Movement;

namespace LearnGame.Enemy.States
{
    public class RunAway : BaseState
    {
        private readonly EnemyTarget _target;
        private EnemyDirectionController _enemyDirectionController;
        private Vector3 _currentPoint;
        private readonly float Distance = 15f;

        public RunAway(EnemyTarget target, EnemyDirectionController enemyDirectionController)
        {
            _target = target;
            _enemyDirectionController = enemyDirectionController;
        }
       
        public override void Execute()
        {
            _enemyDirectionController.hasexecuted = true;
            Vector3 targetPosition = _target.Closest.transform.position;
            Vector3 direction = (_enemyDirectionController.transform.position - targetPosition).normalized;
            _currentPoint = targetPosition + direction * Distance;
            _enemyDirectionController.UpdateMovementDirection(_currentPoint);
            
        }
    }
}