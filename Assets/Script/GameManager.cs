using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private GameObject deathUIContent;

	void Awake ()
	{
		PlayerMove.PlayerDeath += HandlePlayerDeath;
	}

	void HandlePlayerDeath ()
	{
		PlayerMove.PlayerDeath -= HandlePlayerDeath;
		if (deathUIContent != null) 
		{
			deathUIContent.SetActive (true);
		}

		Invoke ("LoadNewLevel", 4.0f);
	}

	private void LoadNewLevel ()
	{
		Application.LoadLevel ("this");
	}
}

