using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    public float speed; // скорость
    public float helthBoss; // хп босса
    public float dmgHands; // урон с руки
    public float dmgLeg; // урон с ноги
    public float dmgHead; // урон головой

    private float coolDownAttack; 
    public float stopCoolDownAttack; // 1.5 

    private bool YaVamZapreshayHidit = false;
    private PlayerController player;
    private Deathratle deathratle;
    private Animator anim;

    public Image bar;
    public float fill;
    public Rigidbody2D bossRB;
    public Rigidbody2D playerRB;
    public ForcePlayer forcePlayer;
    public CameraController cameraController;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRB = FindObjectOfType<Rigidbody2D>();
        bossRB = FindObjectOfType<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        deathratle = FindObjectOfType<Deathratle>();
        cameraController = FindObjectOfType<CameraController>();
    }
    void Start()
    {
        fill = 1f;
    }

    void Update()
    {
        bar.fillAmount = fill;
        fill = helthBoss / 10;
        if (YaVamZapreshayHidit != true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (coolDownAttack <= 0)
            {
                coolDownAttack = stopCoolDownAttack;
                int rand = Random.Range(1, 4);
                if (rand == 1)
                {
                    anim.Play("attack");
                }
                if (rand == 2)
                {
                    anim.Play("attackLeg");
                }
                if (rand == 3)
                {
                    anim.Play("attackHead");
                }
            }
            else
            {
                coolDownAttack -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage) // когда получается урон от меча игрока
    {
        helthBoss -= damage;

        if (helthBoss <= 0) // смэрть босса
        {
            coolDownAttack = 99;
            anim.Play("death");
            deathratle.SoundDeathDevil();
            cameraController.MuteMusic(); // замутить музыку на фон
            Invoke("ToBeContinued", 3f);
            bossRB.simulated = false;
            YaVamZapreshayHidit = true; 
        }
    }
    public void BossAttack()
    {
        player.health -= dmgHands;
        deathratle.SoundAttackDevil();
    }

    public void BossAttackLeg()
    {
        player.health -= dmgLeg;
        deathratle.SoundAttackLegDevil();
        forcePlayer.ForceHero();
    }

    public void BossAttackHead()
    {
        player.health -= dmgHead;
        deathratle.SoundAttackHeadDevil();
    }
    public void ToBeContinued()
    {
        deathratle.SoundDeathDevil1();
        Invoke("Titri", 2f);

    }
    public void Titri()
    {
        SceneManager.LoadScene("Titri");
    }
}
