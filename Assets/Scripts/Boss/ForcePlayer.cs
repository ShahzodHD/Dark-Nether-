using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ForceHero()
    {
        rb.AddForce(Vector2.left * force);
    }
}
