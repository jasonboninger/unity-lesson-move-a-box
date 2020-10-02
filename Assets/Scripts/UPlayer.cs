using UnityEngine;

namespace Assets.Scripts
{
	public class UPlayer : MonoBehaviour
	{
		public float speed;
		public UTarget[] targets;

		protected void Start()
		{
			for (int i = 0; i < targets.Length; i++)
			{
				var target = targets[i];

				Debug.Log(target.name);

			}
		}

		protected void Update()
		{
			var up = Input.GetKey(KeyCode.UpArrow);
			if (up)
			{
				Vector3 position = transform.position;
				position.z -= speed * Time.deltaTime;
				transform.position = position;
			}
			var down = Input.GetKey(KeyCode.DownArrow);
			if (down)
			{
				Vector3 position = transform.position;
				position.z += speed * Time.deltaTime;
				transform.position = position;
			}
			var left = Input.GetKey(KeyCode.LeftArrow);
			if (left)
			{
				Vector3 position = transform.position;
				position.x += speed * Time.deltaTime;
				transform.position = position;
			}
			var right = Input.GetKey(KeyCode.RightArrow);
			if (right)
			{
				Vector3 position = transform.position;
				position.x -= speed * Time.deltaTime;
				transform.position = position;
			}
		}
	}
}
