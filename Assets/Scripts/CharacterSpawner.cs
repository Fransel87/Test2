using LearnGame.Enemy;
using UnityEditor;
using UnityEngine;

namespace LearnGame
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField]
        private PlayerCharacter _playerCharacter;
        [SerializeField]
        private EnemyCharacter _enemyCharacter;

        [SerializeField]
        private float _range = 2f;

        [SerializeField]
        private int _maxCount = 1;

       
        void Awake()
        {
            var randomPointInsideRange = Random.insideUnitCircle * _range;
            var randomPosition = new Vector3(randomPointInsideRange.x, 0f, randomPointInsideRange.y) + transform.position;
            Instantiate(_enemyCharacter, randomPosition, Quaternion.identity, transform);
            Instantiate(_playerCharacter, randomPosition, Quaternion.identity, transform);
        }
        
        protected void OnDrawGizmos()
        {
            var cashedColor = Handles.color;
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, Vector3.up, _range);
            Handles.color = cashedColor;
        }
    }
}