using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // ��� ������������
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

    public Rigidbody2D rb; // ������ �����

    private bool facingRight = true; // ��� ��������������
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

    void FixedUpdate() //�������� ������ 
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        health += Time.deltaTime * heal; // ������������ �������������� ��
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
            if (health < 1 && perek == true)  // ����� ����� �������
            {
                anim.SetTrigger("IsDead"); // �������� ������
                gameOverObj.SetActive(true); // ������� YOU DEAD
                deathratle.DeathPlayer(); // ���� ������
                rb.mass = 100; // ��������� ����� ���� ������ ����� �� ������� ����
                perek = false; // ���� 1 ��� ���������
                perek1 = false; // ���� ��������� ���������� ����� ������
                Destroy(transform.GetChild(0).gameObject); // ������� ������ ����

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

    void OnTriggerEnter2D(Collider2D collision) // ����� ������ � ���� ������
    {
        if (collision.CompareTag("Deathzone") && perek == true) 
        {
            anim.SetTrigger("IsDead"); //�������� ������
            gameOverObj.SetActive(true); // ������� YOU DEAD
            deathratle.DeathPlayer(); // ���� ������
            perek = false; // ���� 1 ��� ���������
            perek1 = false; // ���� ��������� ���������� ����� ������
            Destroy(transform.GetChild(0).gameObject); // ������� ������ ����
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

    void Flip() // �������������� 
    {
        facingRight = !facingRight;
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
