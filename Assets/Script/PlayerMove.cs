using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 5.0f;
	[SerializeField]
	private Rigidbody2D rigidBody;
	
	// Update is called once per frames
	void FixedUpdate ()
	{
		float horizontalInput = Input.GetAxis ("Horizontal");

		if (horizontalInput > 0 || horizontalInput < 0) 
		{
			Debug.Log (horizontalInput);
			rigidBody.AddForce(Vector2.right * horizontalInput * moveSpeed * Time.fixedDeltaTime);
		}
	}
}

