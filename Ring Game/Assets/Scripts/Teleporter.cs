using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleporter : MonoBehaviour
{
    public Vector3 teleportHight;
    GameObject player;
    bool entered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(entered)
        {
            player.GetComponent<PlayerInput>().enabled = false;
            player.GetComponent<Collider>().enabled = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.magenta;

            player.transform.position = Vector3.MoveTowards((player.transform.position), new Vector3(teleportHight.x, teleportHight.y, teleportHight.z), (3*Time.deltaTime));
            if (player.transform.position.y >= teleportHight.y)
            {
                player.GetComponent<PlayerInput>().enabled = true;
                player.GetComponent<Collider>().enabled = true;
                player.GetComponent<Rigidbody>().useGravity = true;
                player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                entered = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            entered = true;
            
        }
    }
}
