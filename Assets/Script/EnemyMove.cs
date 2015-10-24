using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 10.0f;

	private Rigidbody2D rigidBody;
	private int direction = -1;

	void Start ()
	{
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.BackQuote)) 
		{
			direction *= -1;
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y);
		}

		transform.position = new Vector3 (transform.position.x + direction * moveSpeed * Time.fixedDeltaTime, transform.position.y);

//		if (rigidBody != null) 
//		{
//			rigidBody.AddForce (-1 * transform.right * moveSpeed);
//		}
	}
}

