using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Space]
    [Header("Cooldown attack")]
    [Space]
    public float timeBtnAttack;
    public float StartTimeBtnAttack;
    [Space]
    [Header("Parameters")]
    [Space]
    public int health;
    public float speed;
    public float damage;
    public float stopTime;
    public float startStopTime;
    public float normalSpeed;

    private ScoreManager sm;
    private SpriteRenderer spriteEnemy;
    private PlayerController player;
    private Animator anim;
    private Material matBlink;
    private Material matDefault;
    private UnityEngine.Object explosion;
    private Deathratle deathratle;
    [Space]
    [Header("Components")]
    [Space]
    public Rigidbody2D rb;

    void Awake()
    {
        spriteEnemy = GetComponent<SpriteRenderer>();
        deathratle = FindObjectOfType<Deathratle>();
        sm = FindObjectOfType<ScoreManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        normalSpeed = speed;

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteEnemy.material;

        explosion = Resources.Load("Explosion");
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage) // когда получается урон от меча игрока
    {
        stopTime = startStopTime;
        health -= damage;

        spriteEnemy.material = matBlink;

        if (health <= 0) // смэрть
        {
            sm.Kill();
            anim.Play("Enemy3Dead");
            normalSpeed = 0;
            spriteEnemy.material = matDefault;
            Invoke("EnemyBodyDestroy", 0.5f);
        }
        else
        {
            Invoke("ResetMaterial", 0.15f);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (timeBtnAttack <= 0)
            {
                anim.SetTrigger("attack");
            }
            else
            {
                timeBtnAttack -= Time.deltaTime;
            }
        }
    }


    public void OnEnemyAttack()
    {
        player.health -= damage;
        timeBtnAttack = startStopTime;
    }

    void EnemyBodyDestroy() // когда враг умирает
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);

        Destroy(gameObject);
    }

    void ResetMaterial()
    {
        spriteEnemy.material = matDefault;
    }

    void DeathRatleDemon()
    {
        deathratle.Demon();
    }
    public void AttackDemon()
    {
        deathratle.AttackDemon();
    }
}
