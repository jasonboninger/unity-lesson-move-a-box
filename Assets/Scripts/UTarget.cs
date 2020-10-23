using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class UTarget : MonoBehaviour
	{
		private float _speed;
		private Coroutine _runningAway;

		public UTarget Initialize(Vector3 position, float speed)
		{
			transform.position = position;
			_speed = speed;
			return this;
		}

		protected void Start()
		{
			StartCoroutine(_Hover());
		}

		public bool IsRunningAway()
		{
			return _runningAway != null;
		}

		public void StartRunningAway(Func<Vector3> getPosition)
		{
			StopRunningAway();
			_runningAway = StartCoroutine(_RunAway(getPosition));
		}

		public void StopRunningAway()
		{
			if (IsRunningAway())
			{
				StopCoroutine(_runningAway);
				_runningAway = null;
			}
		}

		private IEnumerator _RunAway(Func<Vector3> getPosition)
		{
			while (true)
			{
				var positionRunAwayFrom = getPosition();
				var positionSelf = transform.position;

				var direction = positionSelf - positionRunAwayFrom;
				direction.y = 0;
				direction.Normalize();
				positionSelf += direction * _speed * Time.deltaTime;
				transform.position = positionSelf;

				yield return null;
			}
		}

		private IEnumerator _Hover()
		{
			var y = transform.position.y;
			var value = 0f;

			while (true)
			{
				var position = transform.position;
				value += Time.deltaTime;
				position.y = y + Mathf.Sin(value) * 0.5f;
				transform.position = position;

				yield return null;

			}
		}
	}
}
