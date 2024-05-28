using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int health;
    public int ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, (3 ), 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().health += health;
            other.gameObject.GetComponent<Player>().currentClip += ammo;
            if(other.gameObject.GetComponent<Player>().currentClip > other.gameObject.GetComponent<Player>().maxClipSize)
            {
                other.gameObject.GetComponent<Player>().currentClip = other.gameObject.GetComponent<Player>().maxClipSize;
            }
            Destroy(this.gameObject);
        }
    }
}
