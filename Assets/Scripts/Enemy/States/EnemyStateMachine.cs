using LearnGame.FSM;
using LearnGame.Enemy;
using LearnGame.Enemy.States;
using System.Collections.Generic;

namespace LearnGame.States
{
	public class EnemyStateMachine : BaseStateMachine
	{
		private const float NavMeshTurnOffDistance = 10f;
        public EnemyStateMachine(EnemyDirectionController enemyDirectionController,
            NavMesher navMesher, EnemyTarget target, BaseCharacter baseCharacter, EnemyAiController enemyAiController)
        {
            var idleState = new IdleState(enemyDirectionController);
            var findWayState = new FindWayState(target, navMesher, enemyDirectionController);
            var moveForwardState = new MoveForwardState(target, enemyDirectionController);
            var runaway = new RunAway(target, enemyDirectionController);

            SetInitialState(idleState);

            AddState(state: idleState, transitions: new List<Transition>
               {
                new Transition(
                    findWayState,
                    (() =>((target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance) && baseCharacter.CounterHealth == false))),
                new Transition(
                    moveForwardState,
                    () => ((target.DistanceToClosestfromAgent() <= NavMeshTurnOffDistance) && baseCharacter.CounterHealth == false)),
                 new Transition(
                    runaway,
                    () => baseCharacter.CounterHealth == true &&
                    target.DistanceToClosestfromAgent() <= NavMeshTurnOffDistance && 
                    enemyAiController.KForRunningAwayDevidedOn100 >= enemyAiController.Randomizer
                    ),
               }

            );
            AddState(state: findWayState, transitions: new List<Transition>
               {
                new Transition(
                    idleState,
                    () => target.Closest == null),
                new Transition(
                    moveForwardState,
                    () => target.DistanceToClosestfromAgent() <= NavMeshTurnOffDistance && baseCharacter.CounterHealth == false),
                
               }

            );
            AddState(state: moveForwardState, transitions: new List<Transition>
               {
                new Transition(
                    idleState,
                    () => target.Closest == null),
                new Transition(
                    findWayState,
                    () => ((target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance) && baseCharacter.CounterHealth == false)),
                new Transition(
                    runaway,
                    () => baseCharacter.CounterHealth == true && enemyAiController.KForRunningAwayDevidedOn100 >= enemyAiController.Randomizer),
               }

            );
            AddState(state: runaway, transitions: new List<Transition>
               {
                new Transition(
                idleState,
                    () => target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance || target.Closest.layer == LayerUtils.PickUpLayer),
               }

           );
        }

	}
}