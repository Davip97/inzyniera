using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
public float maxSpeed =5;
public float speed = 50f;
public float jump =300f;
public bool ground;

private Rigidbody2D rb2d;
private Animator anim;

public int curHealth;
public int maxHealth = 5;

public gameMaster gm;
public GameObject Win;
private bool won= false;

public bool canDoubleJump;
public AudioSource[] sounds;
public AudioSource coinsnd;
public AudioSource jumpsnd;
public AudioSource dmgsnd;




    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHealth = maxHealth;
        sounds = GetComponents<AudioSource>();
        coinsnd = sounds[0];
        jumpsnd= sounds[1];
        dmgsnd= sounds[2];

        gm=GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();

        
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("Ground",ground);
        anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));

        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1,1,1);
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(ground)
            {
                jumpsnd.Play();
                rb2d.AddForce(Vector2.up * jump);
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    jumpsnd.Play();
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jump);
                }
            }
        }


        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth <= 0)
        {
            Die(); //depresyjne troche :(
        }
        if(won)
        {
            Win.SetActive(true);
            Time.timeScale=0;
        }


        
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity; //przyczepnosc
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        if(ground)
        {
            rb2d.velocity = easeVelocity;
        }



        float a = Input.GetAxis("Horizontal"); //poruszanie sie 
        rb2d.AddForce((Vector2.right*speed)*a);//ograniczenie predkosci

        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed,rb2d.velocity.y);
        }
        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed,rb2d.velocity.y);
        }
    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel); //restart po smierci
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        dmgsnd.Play();
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        while( knockDur > timer)
        {
            timer+=Time.deltaTime;
            rb2d.AddForce(new Vector3(-knockbackDir.x , -knockbackDir.y + knockbackPwr, transform.position.z));
        }

        yield return 0;

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Coin"))
        {
            coinsnd.Play();

            Destroy(col.gameObject);
            gm.points += 1;



        }

    
    }
}
