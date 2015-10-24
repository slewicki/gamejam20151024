using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	void Awake ()
	{
		PlayerMove.PlayerDeath += HandlePlayerDeath;
	}

	void HandlePlayerDeath ()
	{
		Application.LoadLevel ("this");
	}
}

