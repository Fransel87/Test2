using LearnGame.Enemy;
using UnityEditor;
using UnityEngine;

namespace LearnGame
{
    public class CharacterSpawnerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;

        [SerializeField]
        private GameObject enemy;

        public static int Rand;

        public static GameObject player1;

        void Awake()
        {
            Rand = Random.Range(0, 2);
            if (Rand == 1)
            {
                player1 = Instantiate(player, CharacterSpawner.randomPosition1, Quaternion.identity, transform);
                Instantiate(enemy, CharacterSpawner2.randomPosition, Quaternion.identity, transform);
            }
            else
            {
                player1 = Instantiate(player, CharacterSpawner2.randomPosition, Quaternion.identity, transform);
                Instantiate(enemy, CharacterSpawner.randomPosition1, Quaternion.identity, transform);
            }
        }
    }
}