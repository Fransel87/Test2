using UnityEditor;
using UnityEngine;

namespace LearnGame
{
    public class CharacterSpawner2 : MonoBehaviour
    {
        public static Vector3 randomPosition;

        [SerializeField]
        private float _range = 2f;

        void Awake()
        {
            var randomPointInsideRange = Random.insideUnitCircle * _range;
            randomPosition = new Vector3(randomPointInsideRange.x, 0f, randomPointInsideRange.y) + transform.position;
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