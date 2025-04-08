using UnityEngine;

namespace LearnGame
{
	public static class LayerUtils
	{
		public const string BulletLayerName = "Bullet";
        public const string EnemyLayerName = "Enemy";
        public const string PlayerLayerName = "Player";
        public const string PickUpLayerName = "PickUp";
        public const string PickUpBonusLayerName = "PickUpBonus";

        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);
		public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName);
        public static readonly int PlayerMask = LayerMask.GetMask(PlayerLayerName);
        public static readonly int PickUpLayer = LayerMask.NameToLayer(PickUpLayerName);
        public static readonly int PickUpBonusLayer = LayerMask.NameToLayer(PickUpBonusLayerName);
        public static readonly int ShootingTargetMask = PlayerMask | EnemyMask;
        public static readonly int PickUpMask = LayerMask.GetMask(PickUpLayerName);
        public static readonly int PlayerLayer = LayerMask.NameToLayer(PlayerLayerName);
        public static readonly int EnemyLayer = LayerMask.NameToLayer(EnemyLayerName);
        public static readonly int ShootingTargetLayer = PlayerLayer | EnemyLayer;
        public static bool IsBullet(GameObject other) => other.layer == BulletLayer;
        public static bool IsPickUp(GameObject other) => other.layer == PickUpLayer;
        public static bool IsPickUpBonus(GameObject other) => other.layer == PickUpBonusLayer;
    }
}


