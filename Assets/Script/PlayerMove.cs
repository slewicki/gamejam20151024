using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 10000.0f;
    [SerializeField]
	private Rigidbody2D rigidBody;

    private bool isGrounded = true;
	
	// Update is called once per frames
	void FixedUpdate ()
	{
		float horizontalInput = Input.GetAxis ("Horizontal");
        bool hasJumped = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W));

		if (horizontalInput > 0 || horizontalInput < 0) 
		{
			Debug.Log (horizontalInput);
			rigidBody.AddForce(Vector2.right * horizontalInput * moveSpeed * Time.fixedDeltaTime);
		}

        if (hasJumped && isGrounded)
        {
            Debug.Log(hasJumped);
            rigidBody.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime);

            isGrounded = false;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cube")
            isGrounded = true;
    }
}

