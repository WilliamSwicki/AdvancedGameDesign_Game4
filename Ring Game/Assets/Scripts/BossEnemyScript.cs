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
        if (collision.gameObject.CompareTag("Player"))
        {

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
        yield return new WaitForSeconds(0.5f);
        attackLocation.GetComponent<Collider>().enabled = false;
        canAttack = true;
    }
    public IEnumerator Dead()
    {

        player.GetComponent<Player>().leftWallCheck.GetComponent<WallCollider>().isTouchingWall = false;
        player.GetComponent<Player>().rightWallCheck.GetComponent<WallCollider>().isTouchingWall = false;
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }
    void choseAttack()
    {
        if (timeBetween <= 0)
        {
            randomNumber = Random.Range(1,4);
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
}
