using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float h, v;
    Vector3 dir;
    public float speed;
    public float jumpPower;
    public float health;

    public bool isFaceingRight;
    public bool isJumping=false;
    Ray rayDown;
    public float rayLength;
    RaycastHit hit;
    public LayerMask hitLayer;

    public bool isExecuting;
    public GameObject attackLocation;
    public GameObject bullet;
    public GameObject knifeAttack;
    public GameObject target;
    public GameObject camera;
    public GameObject playerSprite;
    public GameObject leftWallCheck;
    public GameObject rightWallCheck;

    public int maxClipSize = 5;
    public int currentClip = 5;
    public float fireCooldown;
    public float fireRate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fireCooldown = fireRate;
        isFaceingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //firerate
        fireCooldown -= Time.deltaTime;
        //raycast and jumping logic
        rayDown = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * rayLength, Color.yellow);

        if(Physics.Raycast(rayDown, out hit, rayLength, hitLayer))
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
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
            playerSprite.transform.LookAt(new Vector3(camera.transform.position.x,this.transform.position.y, camera.transform.position.z),Vector3.up);
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
            if (!isJumping)
            {
                rb.AddForce((Vector3.up*jumpPower), ForceMode.Impulse);
            }
        }
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Instantiate(knifeAttack, attackLocation.transform.position, Quaternion.identity);
        }
    }
    public void Execute(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            StartCoroutine("Parring()");
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
    public IEnumerator Executing()
    {
        isExecuting = true;
        yield return new WaitForSeconds(0.25f);
        isExecuting = false;
    }
}
