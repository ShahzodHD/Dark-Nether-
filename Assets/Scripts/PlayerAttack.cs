using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour 
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;

    public bool thisIsArena;


    void Start()
    {
    }
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //if (Input.GetButtonDown("Jump"))
            //{
            //    print("123");
            //    anim.SetTrigger("attack");
            //    timeBtwAttack = startTimeBtwAttack;
            //}
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void OnAttackAnim()
    {
        if (timeBtwAttack <= 0)
        {
            anim.SetTrigger("attack2");
            timeBtwAttack = startTimeBtwAttack;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == "level3 (boss)")
            {
                enemies[i].GetComponent<BossAI>().TakeDamage(damage); // Boss
            }
            else if (SceneManager.GetActiveScene().name != "level4 Arena") 
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(damage); // мобы из —южетки
            }
            else
            {
                enemies[i].GetComponent<EnemyAI>().TakeDamage(damage); // мобы из јрены
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
