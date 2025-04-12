using LearnGame.Enemy.States;
using LearnGame.FSM;
using LearnGame.States;
using UnityEngine;

namespace LearnGame.Enemy
{
	public class EnemyAiController : MonoBehaviour
	{
        [SerializeField]
        public float _viewRadius = 10f;
        
        [SerializeField]
        public float KForRunningAwayDevidedOn100 = 0.7f;
        [HideInInspector]
        public float Randomizer; // для обновления рандомного числа при переходах между состояниями, где имеется runaway
        [HideInInspector]
        public bool HasExecutedFor2States = false; // для обновления рандомного числа при переходах между состояниями, где имеется runaway

        private EnemyStateMachine _stateMachine;
        private EnemyTarget _target;

        protected void Start()
        {
            Randomizer = Random.value;
            var enemyAiController = GetComponent<EnemyAiController>();
            var enemyCharacter = GetComponent<EnemyCharacter>();
            var player = FindAnyObjectByType<PlayerCharacter>();
            var baseCharacter = GetComponent<BaseCharacter>();
            var enemyDirectionController = GetComponent<EnemyDirectionController>();
            var navMesher = new NavMesher(transform);
            _target = new EnemyTarget(transform, _viewRadius, player, baseCharacter);
            _stateMachine = new EnemyStateMachine(enemyDirectionController, navMesher, _target, baseCharacter, enemyAiController);
        }

        protected void Update()
        {
            _target.FindClosest();
            _stateMachine.Update();
        }
    }
}