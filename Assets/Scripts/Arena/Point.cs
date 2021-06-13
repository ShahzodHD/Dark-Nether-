using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public EnemyAI enemy;
    private Spawner spawner;

    void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
    }
    void Start()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
