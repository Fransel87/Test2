
using LearnGame.FSM;
using LearnGame.Enemy;
using LearnGame.Enemy.States;
using System.Collections.Generic;
using TMPro;
using static UnityEngine.GraphicsBuffer;

namespace LearnGame.States
{
	public class EnemyStateMachine : BaseStateMachine
	{
		private const float NavMeshTurnOffDistance = 5f;
        public EnemyStateMachine(EnemyDirectionController enemyDirectionController,
            NavMesher navMesher, EnemyTarget target, BaseCharacter baseCharacter, float _viewRadius, EnemyCharacter enemyCharacter)
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
                    () => target.DistanceToClosestfromAgent() > NavMeshTurnOffDistance && baseCharacter.counterHealth == false),
                new Transition(
                    moveForwardState,
                    () => target.DistanceToClosestfromAgent() <= NavMeshTurnOffDistance && baseCharacter.counterHealth == false),
                 new Transition(
                    runaway,
                    () => baseCharacter.counterHealth == true &&
                    target.Closest.layer == LayerUtils.ShootingTargetLayer &&
                     target.DistanceToClosestfromAgent() <= _viewRadius
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
                    () => target.Closest == null && baseCharacter.counterHealth == false),
                new Transition(
                    findWayState,
                    () => target.DistanceToClosestfromAgent() > _viewRadius && baseCharacter.counterHealth == false),
                new Transition(
                    runaway,
                    () => baseCharacter.counterHealth == true),
               }

            );
            AddState(state: runaway, transitions: new List<Transition>
               {
                new Transition(
                idleState,
                    () =>((target.DistanceToClosestfromAgent() > _viewRadius && target.Closest.layer == LayerUtils.ShootingTargetLayer ) || target.Closest.layer == LayerUtils.PickUpLayer)),
               }

           );
        }

	}
}