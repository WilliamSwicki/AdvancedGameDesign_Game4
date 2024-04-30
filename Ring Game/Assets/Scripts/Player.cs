using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float h, v;
    Vector3 dir;
    public float speed;
    public float jumpPower;
    public float health;
    public float healthAmt;
    public float maxHealth;
    public Image healthBar;

    public bool isFaceingRight;

    //public bool isJumping=false;
    public int jumpCount = 1;
    public int maxJumpCount = 1;

    Ray rayDown;
    public float rayLength;
    RaycastHit hit;
    public LayerMask hitLayer;

    public bool isExecuting;
    public bool isAttacking;
    public GameObject attackLocation;
    public GameObject bullet;
    public GameObject target;
    public GameObject cameraTarget;
    public GameObject playerSprite;
    public GameObject leftWallCheck;
    public GameObject rightWallCheck;
    public GameObject menuScreen;

    public float maxClipSize = 5;
    public float currentClip = 5;
    public float clipAmt = 1;
    public Image clipBar;
    public float fireCooldown;
    public float fireRate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        rb = GetComponent<Rigidbody>();
        fireCooldown = fireRate;
        isFaceingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //health and ammo bars
        healthAmt = health / maxHealth;
        healthBar.fillAmount = healthAmt;

        if(health<=0)
        {
            SceneManager.LoadScene(0);
        }

        clipAmt = currentClip / maxClipSize;
        clipBar.fillAmount = clipAmt;

        //firerate
        fireCooldown -= Time.deltaTime;

        //raycast and jumping logic
        rayDown = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * rayLength, Color.yellow);

        if(Physics.Raycast(rayDown, out hit, rayLength, hitLayer))
        {
            jumpCount = maxJumpCount;
        }
        
    }

    //movement
    private void FixedUpdate()
    {
        if (rightWallCheck.GetComponent<WallCollider>().isTouchingWall&& h>0)
        {
            
        }
        else if(leftWallCheck.GetComponent<WallCollider>().isTouchingWall && h<0)
        {
            
        }
        else
        {
            transform.RotateAround(target.transform.position, Vector3.up, (-h * speed) * Time.deltaTime);
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
        h = dir.x;
        v = dir.y;
        //rotate player based on movment
        if (h < 0)
        {
            isFaceingRight = false;
            playerSprite.transform.LookAt(new Vector3(cameraTarget.transform.position.x,this.transform.position.y, cameraTarget.transform.position.z),Vector3.up);
        }
        if (h > 0)
        {
            isFaceingRight = true;
            playerSprite.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), Vector3.up);
        }

    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (jumpCount >0)
            {
                StartCoroutine(jumpTimer());
                rb.AddForce((Vector3.up*jumpPower), ForceMode.Impulse);
                jumpCount--;
            }
        }
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(!isAttacking)
            {
                StartCoroutine(Attacking());
            }
        }
    }
    public void Execute(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            StartCoroutine(Executing());
        }
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentClip > 0 && fireCooldown<=0)
            {
                Instantiate(bullet, attackLocation.transform.position, Quaternion.identity);
                currentClip--;
                fireCooldown = fireRate;
            }
        }
    }
    public void Menu(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(menuScreen.gameObject.activeSelf)
            {
                menuScreen.gameObject.SetActive(false);
            }
            else
            {
                menuScreen.gameObject.SetActive(true);
            }
        }
    }
    public IEnumerator jumpTimer()
    {
        rayLength = 0;
        yield return new WaitForSeconds(0.25f);
        rayLength = 0.5f;
    }
    public IEnumerator Executing()
    {
        isExecuting = true;
        attackLocation.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        attackLocation.GetComponent<Collider>().enabled = false;
        isExecuting = false;
    }
    public IEnumerator Attacking()
    {
        isAttacking = true;
        attackLocation.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        attackLocation.GetComponent<Collider>().enabled = false;
        isAttacking = false;
    }
}
