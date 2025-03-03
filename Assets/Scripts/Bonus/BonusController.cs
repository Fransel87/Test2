
using UnityEngine;
using LearnGame.Movement;

namespace LearnGame.Bonus
{
	public class BonusController : MonoBehaviour
	{
		private SpeedBonus _speedBonus;
        private float _bonusTimer;
        public int counter = 0;

        void Update()
        {   if (counter >= 1) {
                _bonusTimer = _speedBonus._bonusTime;
            }
            if (counter !=0 && _bonusTimer >0)
            {
                _bonusTimer -= Time.deltaTime;

                CharacterMovementController._speed = _speedBonus._nMoreSpeed* 10f;
            }
               
            if (counter ==1 && _bonusTimer < 0)
            {
                CharacterMovementController._speed = 10f;
                counter = 0;
                Destroy(_speedBonus.gameObject);
            }
        }
            public void SetBonus(SpeedBonus _bonusPrefab, Transform hand)
        {
            _speedBonus = Instantiate(_bonusPrefab, hand);
            _speedBonus.transform.localPosition = Vector3.zero;
            _speedBonus.transform.localRotation = Quaternion.identity;
            counter++;

        }
   
	}
}