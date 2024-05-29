using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    public GameObject enemy;
    
    Ray rayDown;
    public float rayLength;
    RaycastHit hit;
    public LayerMask hitLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rayDown = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * rayLength, Color.yellow);

        if (!Physics.Raycast(rayDown, out hit, rayLength, hitLayer))
        {
            enemy.GetComponent<EnemyScript>().dir *= -1;
        }
    }
}
