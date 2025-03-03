﻿using UnityEditor;
using UnityEngine;

namespace LearnGame.PickUp
{
	public class PickUpSpawner : MonoBehaviour
	{
		[SerializeField]
		private PickUpItem _pickUpPrefab;

		[SerializeField]
		private float _range = 2f;

        [SerializeField]
        private int _maxCount = 3;

        [SerializeField]
        private float _spawnIntervalSeconds = 10f; //время до спавна следующего предмета

		private float _currentSpawnTimerSeconds; //время с момента спавна

        private int _currentCount; // текущее количество заспавненных предметов

        void Update()
		{
            if (_currentCount < _maxCount)
            {
                _currentSpawnTimerSeconds += Time.deltaTime;
                if (_currentSpawnTimerSeconds > _spawnIntervalSeconds)
                {
                    _currentSpawnTimerSeconds = 0f;
                    _currentCount++;

                    var randomPointInsideRange = Random.insideUnitCircle * _range;
                    var randomPosition = new Vector3(randomPointInsideRange.x, 0f, randomPointInsideRange.y) + transform.position;

                    var pickUp = Instantiate(_pickUpPrefab, randomPosition, Quaternion.identity, transform);
                    pickUp.OnPickedUp += OnItemPickedUp;

                }
            }
		}
        private void OnItemPickedUp(PickUpItem pickedUpItem)
        {
            _currentCount--;
            pickedUpItem.OnPickedUp -= OnItemPickedUp;
        }

        protected void OnDrawGizmos()
        {
            var cashedColor = Handles.color;
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, Vector3.up, _range);
            Handles.color = cashedColor;


        }
    }
}