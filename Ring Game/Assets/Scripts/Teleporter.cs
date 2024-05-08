using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float teleportHight;
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
        if(other.gameObject.CompareTag("Player"))
        {

            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, teleportHight, other.gameObject.transform.position.z);
        }
    }
}
