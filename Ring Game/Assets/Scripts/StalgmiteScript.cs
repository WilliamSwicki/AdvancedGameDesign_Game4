using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalgmiteScript : MonoBehaviour
{
    public int damage;
    public GameObject particles;
    public bool decoration;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (decoration)
        {
            rb.useGravity = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(particles,this.transform.position,Quaternion.Euler(0,180,0));
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().health -= damage;
        }
        if(other.gameObject.name == "CeilingSpikes"||other.gameObject.CompareTag("Colaspe"))
        {

        }
        else
        {
Destroy(this.gameObject);
        }
        
    }
}
