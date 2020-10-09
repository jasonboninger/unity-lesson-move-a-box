using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class UPlayer : MonoBehaviour
	{
		public float speedMovement;
		public float speedRotation;
		public List<UTarget> targets;
		
		private readonly Dictionary<UTarget, Coroutine> _targetToCoroutineRunAwayMappings = new Dictionary<UTarget, Coroutine>();

		protected void Update()
		{
			// Move self
			_MoveSelf();
			// Destroy target
			_DestroyTarget();
		}

		private void _MoveSelf()
		{
			var up = Input.GetKey(KeyCode.UpArrow);
			if (up)
			{
				transform.position += transform.forward * speedMovement * Time.deltaTime;
			}
			var down = Input.GetKey(KeyCode.DownArrow);
			if (down)
			{
				transform.position -= transform.forward * speedMovement * Time.deltaTime;
			}
			var left = Input.GetKey(KeyCode.LeftArrow);
			if (left)
			{
				transform.Rotate(new Vector3(0, -speedRotation * Time.deltaTime, 0));
			}
			var right = Input.GetKey(KeyCode.RightArrow);
			if (right)
			{
				transform.Rotate(new Vector3(0, speedRotation * Time.deltaTime, 0));
			}
		}

		private void _DestroyTarget()
		{
			for (int i = 0; i < targets.Count; i++)
			{
				var target = targets[i];
				var distance = Vector3.Distance(transform.position, target.transform.position);
				if (distance <= 5)
				{
					if (!target.IsRunningAway())
					{
						target.StartRunningAway(() => transform.position);
					}
				}
				else
				{
					target.StopRunningAway();
				}
				if (distance <= 1)
				{
					Destroy(target.gameObject);
					targets.Remove(target);
					Debug.Log("TARGET DESTROYED!");
				}
			}
		}
	}
}
