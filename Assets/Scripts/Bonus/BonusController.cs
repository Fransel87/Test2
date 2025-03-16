
using UnityEngine;
using LearnGame.Movement;

namespace LearnGame.Bonus
{
	public class BonusController : MonoBehaviour
	{
		public static SpeedBonus _speedBonus;
        private float _bonusTimer;
        public int counter = 0;
        public static bool _gotIt = false;

        void Update()
        {   if (counter >0 && _bonusTimer<=0) {
                _bonusTimer = _speedBonus._bonusTime;
            }
            if (_bonusTimer >0)
            {
                _bonusTimer -= Time.deltaTime;

                CharacterMovementController._whomSpeed = _speedBonus._nMoreSpeed* CharacterMovementController._speed;
                _gotIt = true;
            }
               
            if (counter >0 && _bonusTimer <=0 && _gotIt==true)
            {
                CharacterMovementController._whomSpeed = CharacterMovementController._speed;
                counter = 0;
                Destroy(_speedBonus.gameObject);
                _gotIt = false;
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