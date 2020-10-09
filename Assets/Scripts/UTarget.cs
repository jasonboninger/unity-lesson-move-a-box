using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class UTarget : MonoBehaviour
	{
		protected void Start()
		{
			StartCoroutine(_Hover());
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
