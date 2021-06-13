using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Space]
    [Header("ИИ")]
    [Space]
    public int positionOfPatrol;
    public float stoppingDistance;
    public Transform point;
    bool moveingRight;
    Transform player1;

    bool chill = false;
    bool angry = false;
    bool wellcomeHomeSon = false;

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

    private bool facingLeft; // для отзеркаливание
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
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        player1 = GameObject.FindGameObjectWithTag("Player").transform;
        normalSpeed = speed;

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteEnemy.material;

        explosion = Resources.Load("Explosion");
    }

    void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false && health > 0) // патруль
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player1.position) < stoppingDistance) // режим гопника
        {
            angry = true;
            chill = false;
            wellcomeHomeSon = false;
        }

        if (Vector2.Distance(transform.position, player1.position) > stoppingDistance) // Вэл ком ту хоум, Son
        {
            wellcomeHomeSon = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true) 
        {
            Angry();
        }
        else if (wellcomeHomeSon == true)
        {
            WellcomeHomeSon();
        }
    }

    public void TakeDamage(int damage) // когда получается урон от меча игрока
    {
        stopTime = startStopTime;
        health -= damage;

        spriteEnemy.material = matBlink;

        if (health <= 0) // смэрть
        {
            //GetComponent<AudioSource>().Play();
            anim.Play("Enemy3Dead");
            normalSpeed = 0;
            spriteEnemy.material = matDefault;
            Invoke("EnemyBodyDestroy", 0.5f);
        }
        else
        {
            Invoke("ResetMaterial",0.15f);
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

    void Chill() // режим патруля
    {
        normalSpeed = 2; // обычная скорость
        if (transform.position.x > point.position.x + positionOfPatrol) // когда идет направо
        {
            moveingRight = false;
            spriteEnemy.flipX = false;
            facingLeft = false;

        }
        else if (transform.position.x < point.position.x - positionOfPatrol) // когда идет налево
        {
            moveingRight = true;
            spriteEnemy.flipX = true;
        }
        else
        {
            facingLeft = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y); // национализм
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); // марксизм
        }
    }

    void Angry() // режим гопника
    {
        transform.position = Vector2.MoveTowards(transform.position, player1.position, speed * Time.deltaTime);
        normalSpeed = 3;
        if (facingLeft == false)
        {
            spriteEnemy.flipX = true;
        }
        else
        {
            spriteEnemy.flipX = false;
        }
    }

    void WellcomeHomeSon()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        normalSpeed = 2;
        if (facingLeft == true)
        {
            spriteEnemy.flipX = true;
        }
    }

    void ResetMaterial()
    {
        spriteEnemy.material = matDefault;
    }
    /// <summary>
    /// Звук предсмертный хрип мобов
    /// </summary>
    void DeathRatleDemon()
    {
        deathratle.Demon();
    }
    void DeathRatleSpider()
    {
        deathratle.Spider();
    }
    void DeathRatleGirl()
    {
        deathratle.Girl();
    }
    void DeathRatleTrent()
    {
        deathratle.Trent();
    }
    void DeathRatleChel()
    {
        deathratle.Chel();
    }
    void DeathRatleDog()
    {
        deathratle.Dog();
    }
    /// <summary>
    /// Ниже звук аттаки мобов
    /// </summary>
    public void AttackDemon()
    {
        deathratle.AttackDemon();
    }
    public void AttackSpider()
    {
        deathratle.AttackSpider();
    }
    public void AttackGirl()
    {
        deathratle.AttackGirl();
    }
    public void SoundAttackTrent()
    {
        deathratle.SoundAttackTrent();
    }
    public void SoundAttackChel()
    {
        deathratle.SoundAttackChel();
    }
    public void SoundAttackDog()
    {
        deathratle.SoundAttackDog();
    }
}
