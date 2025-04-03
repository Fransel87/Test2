using LearnGame.FSM;
using UnityEngine;

namespace LearnGame.Enemy.States
{
	public class FindWayState : BaseState
	{
        private EnemyTarget _target;
        public FindWayState(EnemyTarget target)
        {
            _target = target;
        }

        public override void Execute()
        {
            Vector3 targetPosition = _target.Closest.transform.position;
        }
    }
}