using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 10.0f;

	private Rigidbody2D rigidBody;
	private int direction = -1;

    // Player object
    private Transform target;

	private void Start ()
	{
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
        target = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	private void FixedUpdate ()
	{
        // Get change of direction to face the player
        int curDirection = Mathf.Abs(direction);
        curDirection = (target.position.x < transform.position.x) ? curDirection * -1 : curDirection;
        
		if (curDirection != direction) 
		{
			direction = curDirection;
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y);
		}

		transform.position = new Vector3 (transform.position.x + direction * moveSpeed * Time.fixedDeltaTime, transform.position.y);

//		if (rigidBody != null) 
//		{
//			rigidBody.AddForce (-1 * transform.right * moveSpeed);
//		}
	}
}

