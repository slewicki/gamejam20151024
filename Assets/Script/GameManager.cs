using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private int bossCounter;

	void Awake ()
	{
		PlayerMove.PlayerDeath += HandlePlayerDeath;
        PlayerMove.EnemyDeath += HandleEnemyDeath;
        bossCounter = 10;
	}

    void HandlePlayerDeath()
    {
        Application.LoadLevel("this");
    }

    void HandleEnemyDeath()
    {
        if (bossCounter <= 0)
        {
            // Spawn our boss
            return;
        }

        bossCounter--;
    }
}

