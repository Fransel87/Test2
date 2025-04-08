
using UnityEngine;
using LearnGame.Movement;

namespace LearnGame.Bonus
{
	public class BonusController : MonoBehaviour
	{
		private static SpeedBonus _speedBonus;
        private float _bonusTimer = -10f;
        public static int counter = 0;
        private PlayerMovementDirectionController _playerMovementDirectionController;

        private void Awake()
        {
            _playerMovementDirectionController = GetComponent<PlayerMovementDirectionController>();
        }
        void Update()
        {   
            if (_bonusTimer > 0f) 
                _bonusTimer -= Time.deltaTime;
            
            if (-9f <=_bonusTimer && _bonusTimer <= 0f)
            {
                _playerMovementDirectionController._currentSpeed /= _speedBonus.NMoreSpeed;
                _bonusTimer = -10f;
                Destroy(_speedBonus.gameObject);
                counter = 0;
                BaseCharacter.counter1 = 0;
            }
        }
        public void SetBonus(SpeedBonus _bonusPrefab, Transform hand)
        {   if (counter == 0)
            {
                _speedBonus = Instantiate(_bonusPrefab, hand);
                _speedBonus.transform.localPosition = Vector3.zero;
                _speedBonus.transform.localRotation = Quaternion.identity;
                _bonusTimer = _speedBonus.BonusTime;
                _playerMovementDirectionController._currentSpeed *= _speedBonus.NMoreSpeed;
                counter++;
            }
        }
	}
}