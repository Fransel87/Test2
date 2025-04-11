using LearnGame.FSM;

namespace LearnGame.Enemy.States
{
    public class IdleState : BaseState
    {
        private readonly EnemyDirectionController _enemyDirectionController;
        public IdleState(EnemyDirectionController enemyDirectionController)
        {
            _enemyDirectionController = enemyDirectionController;
        }
        public override void Execute()
        {
            
                _enemyDirectionController.UpdateMovementDirection(_enemyDirectionController.transform.position);
            

        }
    }   
    
}