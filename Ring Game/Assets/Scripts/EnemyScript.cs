using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject attackLocation;
    public float tempHealth;
    public float health;
    public float maxHealth;
    public float speed;
    public int dir;
    public bool canExecute;
    public bool canMove;
    public bool canAttack;
    public GameObject target;
    public GameObject reverseTarget;
    public GameObject sprite;

    public GameObject leftWallCheck;
    public GameObject rightWallCheck;
    public GameObject player;

    public GameObject enemyCounter;

    public GameObject healthPickUp;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        enemyCounter = GameObject.FindWithTag("Counter");
        player = GameObject.FindWithTag("Player");
        canAttack = true;
        target = GameObject.FindWithTag("Center");
        tempHealth = health;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //health 
        if (health<=(maxHealth*0.3f))
        {
            //canExecute = true;
        }
        if(tempHealth != health)
        {
            player.GetComponent<Player>().audioSource.clip = player.GetComponent<Player>().clip[6];
            player.GetComponent<Player>().audioSource.Play();
            StartCoroutine(DamageFlash());
        }
        tempHealth = health;
        if(health<=0&&health >= -9999)
        {
            health = -99999;
            StartCoroutine(Dead());
        }
        if (canExecute)
        {
            sprite.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        //moving and turning
        if (canMove)
        {
            transform.RotateAround(target.transform.position, Vector3.up, (dir * speed) * Time.deltaTime);
        }
        if(dir == -1)
        {
            sprite.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), Vector3.up);
        }
        if(dir == 1)
        {
            sprite.transform.LookAt(new Vector3(reverseTarget.transform.position.x, this.transform.position.y, reverseTarget.transform.position.z), Vector3.up);
        }
        if (rightWallCheck.GetComponent<WallCollider>().isTouchingWall)
        {
            dir = 1;
        }
        else if (leftWallCheck.GetComponent<WallCollider>().isTouchingWall)
        {
            dir = -1;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canMove = false;
            if (canAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            dir *= -1;
            canMove = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canMove = true;
        }
    }
    public IEnumerator Attack()
    {
        canAttack = false;
        attackLocation.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(1.5f);
        attackLocation.GetComponent<Collider>().enabled = false;
        canAttack = true;
    }
    public IEnumerator Dead()
    {
        canMove = false;
        int randomNum = 0;
        this.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        randomNum = Random.Range(0, 100);
        
        
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(0.4f);
player.GetComponent<Player>().leftWallCheck.GetComponent <WallCollider>().isTouchingWall = false;
        player.GetComponent<Player>().rightWallCheck.GetComponent<WallCollider>().isTouchingWall = false;
        if (randomNum >= 50)
        {
            Instantiate(healthPickUp, this.transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
    public IEnumerator DamageFlash()
    {
        for (int i = 0; i <= 4; i++)
        {
            sprite.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
