using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalgmiteScript : MonoBehaviour
{
    public int damage;
    public GameObject particles;
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
        Instantiate(particles,this.transform.position,Quaternion.Euler(0,180,0));
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().health -= damage;
        }
        Destroy(this.gameObject);
    }
}
