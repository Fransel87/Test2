

using LearnGame.Bonus;
using LearnGame.Shooting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace LearnGame.PickUp
{
	public class PickUpBonus : PickUpItem
	{
        [SerializeField]
        private SpeedBonus _bonusPrefab;
        

        public override void PickUp(BaseCharacter character)
        {
                base.PickUp(character);
                character.SetBonus(_bonusPrefab);
        }
    }
}