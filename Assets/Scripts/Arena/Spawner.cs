using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] varitants;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    public float enemyHealth;
    public float increaseHealth;
    public float enemyDamage;
    public float increaseDamage;
    void Update()
    {
        enemyDamage += Time.deltaTime * increaseDamage;
        enemyHealth += Time.deltaTime * increaseHealth;

        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, varitants.Length);
            Instantiate(varitants[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
