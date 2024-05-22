using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class BossEnemyScript : EnemyScript
{
    [SerializeField]
    float timeBetween;
    [SerializeField]
    int randomNumber;

    public GameObject bullet;

    public GameObject[] stalgmiteSpwan;
    public GameObject stalamite;
    public GameObject stalamiteSpwaner;

    /*public GameObject[] enemySpwan;
    public GameObject enemy;*/

    bool phase2;

    // Start is called before the first frame update
    void Start()
    {
        setTime();
        enemyCounter = GameObject.FindWithTag("Counter");
        player = GameObject.FindWithTag("Player");
        canAttack = true;
        target = GameObject.FindWithTag("Center");
    }

    // Update is called once per frame
    void Update()
    {
        timeBetween -= Time.deltaTime;
        if (health <= (maxHealth * 0.3f))
        {
            canExecute = true;
        }
        if(tempHealth != health)
        {
            StartCoroutine(DamageFlash());
            tempHealth = health;
        }
        if (health <= 0)
        {
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
        if (dir == -1)
        {
            sprite.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), Vector3.up);
        }
        if (dir == 1)
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
        //
        if(health <= (maxHealth * 0.75f) && !phase2)
        {
            Colaspe();
            phase2 = true;
        }
        choseAttack();
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
        if (collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("Enemy"))
        {
            
        }
        if(collision.gameObject.CompareTag("Enemy"))
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
    
    void choseAttack()
    {
        if (timeBetween <= 0)
        {
            randomNumber = Random.Range(1,5);
            switch (randomNumber)
            {
                case 1:
                    Dash();
                    break;
                    case 2:
                    Shoot();
                    break;
                    case 3:
                    Turn();
                    break;
                    case 4:
                    if(health<=(maxHealth*0.5f))
                        Colaspe();
                    break;
                default:
                    break;
            }
            setTime();
        }
    }
    void setTime()
    {
        timeBetween = Random.Range(1f, 3f);
    }
    void Dash()
    {
        speed = 40;
        StartCoroutine(timer(1f));
        
    }
    void Colaspe()
    {
        player.GetComponent<Animator>().SetTrigger("ScreenShake");
        StartCoroutine(ColaspeTime());
    }
    void Turn()
    {
        dir *= -1;
    }
    void Shoot()
    {
        Instantiate(bullet, attackLocation.transform.position, Quaternion.identity);
    }
    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        speed = 20;
    }
    IEnumerator ColaspeTime()
    {
        stalamiteSpwaner.SetActive(true);
        stalamiteSpwaner.GetComponent<ceilingSpike>().activate();
        yield return new WaitForSeconds(1f);
        stalamiteSpwaner.GetComponent<ceilingSpike>().deactivate();
        stalamiteSpwaner.SetActive(false);
    }    
}
