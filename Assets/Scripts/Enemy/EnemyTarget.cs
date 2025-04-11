using UnityEngine;

namespace LearnGame.Enemy
{
	public class EnemyTarget 

     {
        public GameObject Closest { get; private set; }
        public static Transform _agentTransform;
        private readonly float _viewRadius;
        private readonly PlayerCharacter _player;
        private readonly Collider[] _colliders = new Collider[10];
        private readonly BaseCharacter _baseCharacter;
        private int _targetLayer;
        public EnemyTarget(Transform agent, float viewRadius, PlayerCharacter player, BaseCharacter baseCharacter)
        {
            _agentTransform = agent;
            _viewRadius = viewRadius;
            _player = player;
            _baseCharacter = baseCharacter;
        }
        public void FindClosest()
        {
            float minDistance = float.MaxValue;

            if (_baseCharacter.IsPickedUpWeapon != true)
            {
                _targetLayer = LayerUtils.PickUpMask;
            }
            else
            {
                _targetLayer = LayerUtils.ShootingTargetMask;
            }

                var count = FindAllTargets(_targetLayer);
            for (int i = 0; i < count; i++)
            {
                var go = _colliders[i].gameObject;
                if (go == _agentTransform.gameObject) continue;

                var distance = DistanceFromAgentTo(go);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    Closest = go;
                }

            }
            if (_player != null && DistanceFromAgentTo(_player.gameObject) < minDistance)
                Closest = _player.gameObject;
        }
        
           
        public float DistanceToClosestfromAgent()
        {
            if (Closest != null)
                return DistanceFromAgentTo(Closest);

            return 0;
        }
        private int FindAllTargets(int layerMask)
        {
            var size = Physics.OverlapSphereNonAlloc(
                _agentTransform.position,
                _viewRadius,
                _colliders,
                layerMask
                );
            return size;
        }

        public static float DistanceFromAgentTo(GameObject go) => (_agentTransform.position - go.transform.position).magnitude;
     }
    
}