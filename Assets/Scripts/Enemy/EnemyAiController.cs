
using LearnGame.States;
using UnityEngine;

namespace LearnGame.Enemy
{
	public class EnemyAiController : MonoBehaviour
	{
        [SerializeField]
        private float _viewRadius = 20f;

        private EnemyStateMachine _stateMachine;
        private EnemyTarget _target;

        [System.Obsolete]
        protected void Awake()
        {
            var player = FindObjectOfType<PlayerCharacter>();

            var enemyDirectionController = GetComponent<EnemyDirectionController>();
            var navMesher = new NavMesher(transform);
            _target = new EnemyTarget(transform,_viewRadius,player);
            _stateMachine = new EnemyStateMachine(enemyDirectionController, navMesher, _target);
        }

        protected void Update()
        {
            _target.FindClosest();
            _stateMachine.Update();
        }
    }
}