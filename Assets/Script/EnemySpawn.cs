using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyUnits;
    [SerializeField]
    private float spawnTime = 5.0f;

    private float spawnUpdateTime;
    private float spawnRadius = 5.0f;

    private void Start()
    {
        SetSpawnTime();
    }
	
	// Update is called once per frame
	private void FixedUpdate ()
    {
        if (spawnUpdateTime < Mathf.Epsilon)
        {
            // Check to see if we can spawn anything or if something is in our spawn box
            if (!Physics.CheckSphere(transform.position, spawnRadius))
            {
                int randomIndex = UnityEngine.Random.Range(0, enemyUnits.Length);
                GameObject enemy = enemyUnits[randomIndex];
                Instantiate(enemy, transform.position, Quaternion.identity);
                enemy.name = enemyUnits[randomIndex].name;
            }

            SetSpawnTime();
            return;
        }

        spawnUpdateTime -= Time.fixedDeltaTime;
    }

    private void SetSpawnTime()
    {
        spawnUpdateTime = UnityEngine.Random.Range(0.0f, spawnTime);
    }
}
