using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    public LayerMask mask;
    public bool isTouchingWall = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == mask)
        {
            isTouchingWall=true;
        }
        else
        {
            isTouchingWall = false;
        }
    }
}
