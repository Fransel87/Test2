using UnityEngine;
using LearnGame.Shooting;

namespace LearnGame.PickUp
{
	public class PickUpWeapon : PickUpItem
	{
		[SerializeField]
		private Weapon _weaponPrefab;

        public override void PickUp(BaseCharacter character)
        {
            base.PickUp(character);
            character.SetWeapon(_weaponPrefab);
        }
    }
}