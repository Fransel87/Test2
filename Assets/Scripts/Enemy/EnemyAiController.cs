
using LearnGame.Enemy.States;
using LearnGame.States;
using UnityEngine;

namespace LearnGame.Enemy
{
	public class EnemyAiController : MonoBehaviour
	{
        [SerializeField]
        private float _viewRadius = 10f;

        private EnemyStateMachine _stateMachine;
        private EnemyTarget _target;

        protected void Awake()
        {
            var enemyCharacter = GetComponent<EnemyCharacter>();
            var player = FindAnyObjectByType<PlayerCharacter>();
            var baseCharacter = GetComponent<BaseCharacter>();
            var enemyDirectionController = GetComponent<EnemyDirectionController>();
            var navMesher = new NavMesher(transform);
            _target = new EnemyTarget(transform, _viewRadius, player);
            _stateMachine = new EnemyStateMachine(enemyDirectionController, navMesher, _target, baseCharacter, _viewRadius, enemyCharacter);
        }

        protected void Update()
        {
            _target.FindClosest();
            _stateMachine.Update();
        }
    }
}