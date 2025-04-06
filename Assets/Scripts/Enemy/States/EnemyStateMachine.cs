
using LearnGame.FSM;
using LearnGame.Enemy;
using LearnGame.Enemy.States;
using System.Collections.Generic;
using LearnGame.Movement;
using UnityEngine;

namespace LearnGame.States
{
	public class EnemyStateMachine : BaseStateMachine
	{
		private const float NavMeshTurnOffDistance = 5;
		public EnemyStateMachine(EnemyDirectionController enemyDirectionController,
			NavMesher navMesher, EnemyTarget target, BaseCharacter baseCharacter)
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
					() => target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance && BaseCharacter.counterHealth == false),
                new Transition(
                    moveForwardState,
                    () => target.DistanceToClosestfromAgent() <= NavMeshTurnOffDistance && BaseCharacter.counterHealth == false),
                 new Transition(
                    runaway,
                    () => BaseCharacter.counterHealth == true
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
                    () => target.Closest == null && BaseCharacter.counterHealth == false),
                new Transition(
                    findWayState,
                    () => target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance && BaseCharacter.counterHealth == false),
                new Transition(
                    runaway,
                    () => BaseCharacter.counterHealth == true),
               }

            );
            AddState(state: runaway, transitions: new List<Transition>
               {
                new Transition(
                    idleState,
                    () => target.Closest == null),
               }

           );
        }

	}
}