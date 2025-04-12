using UnityEngine;
using System;

namespace LearnGame.Camera
{
	public class CameraController : MonoBehaviour
	{
        [SerializeField]
        private Vector3 _followCameraOffset = Vector3.zero;

        [SerializeField]
        private Vector3 _rotationOffset = Vector3.zero;
        protected void Start()
		{
			if (CharacterSpawnerController.player1 == null)
				throw new NullReferenceException($"Ну где игрок {nameof(CharacterSpawnerController.player1)}?");
		}

	
		protected void LateUpdate()
		{
			if (CharacterSpawnerController.player1 != null)
			{
				Vector3 targetRotation = _rotationOffset - _followCameraOffset;
                transform.position = CharacterSpawnerController.player1.transform.position + _followCameraOffset;
				transform.rotation = Quaternion.LookRotation(targetRotation, Vector3.up);
			}
        }
	}
}