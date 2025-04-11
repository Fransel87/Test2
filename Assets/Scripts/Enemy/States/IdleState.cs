using LearnGame.FSM;
using UnityEngine;

namespace LearnGame.Enemy.States
{
    public class IdleState : BaseState
    {
        private readonly EnemyDirectionController _enemyDirectionController;
        private EnemyAiController _enemyAiController;
        public IdleState(EnemyDirectionController enemyDirectionController, EnemyAiController enemyAiController)
        {
            _enemyDirectionController = enemyDirectionController;
            _enemyAiController = enemyAiController;
        }
        public override void Execute()
        {   if (_enemyAiController.HasExecutedFor2States == false) // для обновления рандомного числа при переходах между состояниями, где имеется runaway
            {
                _enemyAiController.HasExecutedFor2States = true;
                _enemyAiController.Randomizer = Random.value;
            }
            _enemyDirectionController.UpdateMovementDirection(_enemyDirectionController.transform.position);
            
        }
    }   
    
}