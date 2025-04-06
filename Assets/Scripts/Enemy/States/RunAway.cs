using UnityEngine;
using LearnGame.FSM;
using LearnGame.Movement;

namespace LearnGame.Enemy.States
{
    public class RunAway : BaseState
    {
        private readonly EnemyTarget _target;
        private readonly EnemyDirectionController _enemyDirectionController;
        private Vector3 _currentPoint;
        private readonly BaseCharacter baseCharacter;
        private float Distance = 5f;
        public RunAway(EnemyTarget target, EnemyDirectionController enemyDirectionController)
        {
            _target = target;
            _enemyDirectionController = enemyDirectionController;
        }
        private bool hasExecuted = false;

        public void Enter()
        {
            if (!hasExecuted)
            {
                hasExecuted = true;
                // Выполнить код только при первом входе в состояние
                CharacterMovementController._speed = CharacterMovementController._speed * 2;
            }
        }
        public override void Execute()
        {
            Vector3 targetPosition = _target.Closest.transform.position;
            Vector3 direction = (baseCharacter.transform.position - targetPosition).normalized;
            _currentPoint = targetPosition + direction * Distance;
            _enemyDirectionController.UpdateMovementDirection(_currentPoint);
            
        }
    }
}