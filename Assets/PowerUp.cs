using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class PowerUp : MonoBehaviour
{
	[SerializeField]
	private float boostedJumpForce = 30000.0f;
	[SerializeField]
	private float boostDuration = 10.0f;

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "Player") 
		{
			PlayerMove playerMove = col.gameObject.GetComponent<PlayerMove> ();

			if (playerMove != null)
			{
				playerMove.ApplyJumpBoost (boostedJumpForce, boostDuration);

				GameObject.Destroy (gameObject);
			}
		}
	}
}

