using UnityEngine;
using LearnGame.Shooting;

namespace LearnGame.PickUp
{
	public class PickUpWeapon : MonoBehaviour
	{
		[field: SerializeField]
        public Weapon WeaponPrefab { get; private set; }
	}
}