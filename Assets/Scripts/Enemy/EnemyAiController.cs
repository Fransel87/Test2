
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

        protected void Awake()
        {
            var player = FindAnyObjectByType<PlayerCharacter>();
            var baseCharacter = GetComponent<BaseCharacter>();
            var enemyDirectionController = GetComponent<EnemyDirectionController>();
            var navMesher = new NavMesher(transform);
            _target = new EnemyTarget(transform, _viewRadius, player);
            _stateMachine = new EnemyStateMachine(enemyDirectionController, navMesher, _target, baseCharacter);
        }

        protected void Update()
        {
            _target.FindClosest();
            _stateMachine.Update();
        }
    }
}