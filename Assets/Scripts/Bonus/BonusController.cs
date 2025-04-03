
using UnityEngine;
using LearnGame.Movement;
using UnityEngine.InputSystem.Controls;

namespace LearnGame.Bonus
{
	public class BonusController : MonoBehaviour
	{
		private static SpeedBonus _speedBonus;
        private float _bonusTimer = -10f;
        public static int counter = 0;

        void Update()
        {   
            if (_bonusTimer > 0f) 
                _bonusTimer -= Time.deltaTime;
            
            if (-9f <=_bonusTimer && _bonusTimer <= 0f)
            {
                PlayerMovementDirectionController._currentSpeed /= _speedBonus.NMoreSpeed;
                _bonusTimer = -10f;
                counter = 0;
                Destroy(_speedBonus.gameObject);
            }
        }
        public void SetBonus(SpeedBonus _bonusPrefab, Transform hand)
        {   if (counter == 0)
            {
                _speedBonus = Instantiate(_bonusPrefab, hand);
                _speedBonus.transform.localPosition = Vector3.zero;
                _speedBonus.transform.localRotation = Quaternion.identity;
                _bonusTimer = _speedBonus.BonusTime;
                PlayerMovementDirectionController._currentSpeed *= _speedBonus.NMoreSpeed;
                counter++;
            }
        }
	}
}