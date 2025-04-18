﻿using UnityEngine;
using LearnGame.Movement;
using LearnGame.Enemy.States;
using System.ComponentModel;

namespace LearnGame.Enemy
{
	public class EnemyDirectionController : MonoBehaviour, IMovementDirectionSource
	{
		public Vector3 MovementDirection { get; private set; }
        public float _currentEnemySpeed = CharacterMovementController._speed;

        [HideInInspector]
        public bool hasexecuted;
        protected void Awake ()
        {
            hasexecuted = false;
        }
        protected void Update()
        {
            if (hasexecuted == true)   //ускорение при побеге
            {
                _currentEnemySpeed = 0.1f + CharacterMovementController._speed;
            }
            
        }
        public void UpdateMovementDirection(Vector3 targetPosition)
		{
			var realDirection = targetPosition - transform.position;
			MovementDirection = new Vector3(realDirection.x, 0 , realDirection.z).normalized;
		}
	}
}