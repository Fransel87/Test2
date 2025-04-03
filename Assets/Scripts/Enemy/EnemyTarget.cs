using UnityEngine;
using LearnGame.Movement;

namespace LearnGame.Enemy
{
	public class EnemyTarget 

     {
        public GameObject Closest { get; private set; }
        private readonly Transform _agentTransform;
        public EnemyTarget(Transform agent)
        {
            _agentTransform = agent;
        }
        public float DistanceToClosestfromAgent()
        {
            if (Closest != null)
                DistenaceFromAgentTo(Closest);

            return 0;
        }

        private float DistenaceFromAgentTo(GameObject go) => (_agentTransform.position - go.transform.position).magnitude;
     }
    
}