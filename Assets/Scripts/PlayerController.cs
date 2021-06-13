using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // для передвижение
    public float speed;
    public float moveInput;

    public float health;
    public int numOfHearts;
    public float heal;
    public bool maxHP = true;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float jumpForce;
    public Joystick joystick;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Rigidbody2D rb; // основа основ

    private bool facingRight = true; // для отзеркаливание
    private Deathratle deathratle;

    public Animator anim;
    public GameObject gameOverObj;

    public GameObject BtnJump;
    public GameObject BtnAttack;

    public bool perek = true;
    public bool perek1 = true;
    void Awake()
    {
        deathratle = FindObjectOfType<Deathratle>();
    }

    void Start()
    { 
        rb.GetComponent<Rigidbody2D>();
        anim.GetComponent<Animator>();
    }

    void FixedUpdate() //Движение игрока 
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        health += Time.deltaTime * heal; // ежесекундное восстановление хп
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if (health < 1 && perek == true)  // когда игрок умирает
            {
                anim.SetTrigger("IsDead"); // анимация смерти
                gameOverObj.SetActive(true); // надпись YOU DEAD
                deathratle.DeathPlayer(); // звук смерти
                rb.mass = 100; // увеличить массу тела игроку чтобы не двигали труп
                perek = false; // чтоб 1 раз сработало
                perek1 = false; // чтоб отключить управление после смерти
                Destroy(transform.GetChild(0).gameObject); // удалить обьект меча

            }
        }

        if (perek1 == true)
        {
            moveInput = joystick.Horizontal;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y * Time.deltaTime);
        }

        if (moveInput != 0)
        {
            anim.SetBool("IsRuning", true);
        }
        if (moveInput == 0)
        {
            anim.SetBool("IsRuning", false);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision) // когда падает в зону смерти
    {
        if (collision.CompareTag("Deathzone") && perek == true) 
        {
            anim.SetTrigger("IsDead"); //анимация смерти
            gameOverObj.SetActive(true); // надпись YOU DEAD
            deathratle.DeathPlayer(); // звук смерти
            perek = false; // чтоб 1 раз сработало
            perek1 = false; // чтоб отключить управление после смерти
            Destroy(transform.GetChild(0).gameObject); // удалить обьект меча
        }
    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.Play("jump");
        }
    }

    void Flip() // отзеркаливание 
    {
        facingRight = !facingRight;
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
