
using LearnGame.FSM;
using LearnGame.Enemy;
using LearnGame.Enemy.States;
using System.Collections.Generic;
using LearnGame.Movement;

namespace LearnGame.States
{
	public class EnemyStateMachine : BaseStateMachine
	{
		private const float NavMeshTurnOffDistance = 5;
		public EnemyStateMachine(EnemyDirectionController enemyDirectionController,
			NavMesher navMesher, EnemyTarget target)
		{
			var idleState = new IdleState();
			var findWayState = new FindWayState(target, navMesher, enemyDirectionController);
			var moveForwardState = new MoveForwardState(target, enemyDirectionController);
            var runaway = new RunAway(target, enemyDirectionController);

            SetInitialState(idleState);

			AddState(state: idleState, transitions: new List<Transition>
			   {
				new Transition(
					findWayState,
					() => target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance),
                new Transition(
                    moveForwardState,
                    () => target.DistanceToClosestfromAgent() <= NavMeshTurnOffDistance),
                 new Transition(
                    runaway,
                    () => BaseCharacter.counterHealth>0
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
                    () => target.DistanceToClosestfromAgent() <= NavMeshTurnOffDistance),
               }

            );
            AddState(state: moveForwardState, transitions: new List<Transition>
               {
                new Transition(
                    idleState,
                    () => target.Closest == null),
                new Transition(
                    findWayState,
                    () => target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance),
                new Transition(
                    runaway,
                    () => BaseCharacter.counterHealth>0
                    ),
               }

            );
        }

	}
}