using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DeathPit : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "Player") 
		{
			PlayerMove playerMove = col.gameObject.GetComponent<PlayerMove> ();

			if (playerMove != null)
			{
				playerMove.Kill ();
			}
		}
	}
}

