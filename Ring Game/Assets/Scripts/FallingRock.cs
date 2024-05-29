using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FallingRock : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public Rigidbody rb;
    public bool isFalling = false;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        endPos = new Vector3(this.transform.position.x, 17.61f, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFalling)
        {
            rb.useGravity = true;
        }
        if(this.transform.position.y <= endPos.y) 
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            isFalling = false;
        }
        if(!isFalling)
        {
            rb.useGravity = false;
            if (this.transform.position.y <= startPos.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed*Time.deltaTime);
                //transform.Translate(0, (speed * Time.deltaTime), 0);
            }
        }
    }
}
