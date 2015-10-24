using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 15000.0f;
    [SerializeField]
    private int hp = 100;
    private float defaultJumpForce;

    [SerializeField]
	private Rigidbody2D rigidBody;
	[SerializeField]
	private Animator anim;
    [SerializeField]
    private BoxCollider2D hitBox;
    [SerializeField]
    private BoxCollider2D attackBox;
	[SerializeField]
	private GameObject zombieDeathParticles;

    private bool isGrounded = true;

	private float currentBoostDuration = 0.0f;
	private float boostTimer = 0.0f;

	void Start ()
	{
		defaultJumpForce = jumpForce;
        attackBox.enabled = false;
    }

	void Update ()
	{
		if (currentBoostDuration > 0.0f)
		{
			if (boostTimer >= currentBoostDuration)
			{
				RemoveJumpBoost ();
				boostTimer = 0.0f;
				currentBoostDuration = 0.0f;
			}
			else
			{
				boostTimer += Time.deltaTime;
			}
		}
	}

	// Update is called once per frames
	private void FixedUpdate ()
	{
		float horizontalInput = Input.GetAxis ("Horizontal");
        bool hasJumped = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W));

        if (horizontalInput > 0 || horizontalInput < 0) 
		{
			if (anim != null)
			{
				anim.SetFloat ("Horizontal", Mathf.Abs (horizontalInput));
			}

			int direction = (int) Mathf.Sign (horizontalInput);
			if (Mathf.Sign (direction) != Mathf.Sign (transform.localScale.x))
			{
				transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y);
			}

            rigidBody.AddForce(Vector2.right * horizontalInput * moveSpeed * Time.fixedDeltaTime);
        }

        if (hasJumped && isGrounded)
        {
            rigidBody.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime);
            isGrounded = false;
            attackBox.enabled = true;
			anim.SetBool ("isGrounded", isGrounded);
        }

        // Have player take into account a drag coefficient if we're on the ground and no longer moving
        // Used so that the player does not slide throughout the level
        if (horizontalInput == 0 && isGrounded)
            rigidBody.drag = 5.0f;
        else
            rigidBody.drag = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.name == "Cube")
        {
            isGrounded = true;
            attackBox.enabled = false;
        }
||||||| merged common ancestors
        if (collision.gameObject.name == "Cube")
            isGrounded = true;
=======
        if (collision.gameObject.name == "Cube") 
		{
			isGrounded = true;
			anim.SetBool ("isGrounded", isGrounded);
		}
>>>>>>> 1d6c3bd5720636a0b2df129dd1cb58a8f13806c7
    }

	public void ApplyJumpBoost (float jumpBoost, float duration)
	{
		if (duration > 0.0f) 
		{
			jumpForce = jumpBoost;
			currentBoostDuration = duration;
		}
	}

	private void RemoveJumpBoost ()
	{
		jumpForce = defaultJumpForce;
	}

    private void ApplyDamage(int damage)
    {
        hp -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if our attack box collided with an enemy
        if (collider.gameObject.tag == "Enemy")
        {
			if (zombieDeathParticles != null)
			{
				GameObject.Instantiate (zombieDeathParticles, collider.transform.position, collider.transform.rotation);
			}

            // Kill a bitch
            collider.gameObject.SetActive(false);
            Destroy(collider.gameObject);

			rigidBody.AddForce (Vector2.up * jumpForce * Time.fixedDeltaTime);
        }
    }
}

