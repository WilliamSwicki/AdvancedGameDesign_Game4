using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    public LayerMask mask;
    public bool isTouchingWall = false;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isTouchingWall = true;
        }
        if(isPlayer && other.gameObject.CompareTag("Enemy"))
        {
            isTouchingWall = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isTouchingWall = false;
        }
        if (isPlayer && other.gameObject.CompareTag("Enemy"))
        {
            isTouchingWall = false;
        }
    }
}
