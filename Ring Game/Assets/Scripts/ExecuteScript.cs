using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class ExecuteScript : MonoBehaviour
{
    public GameObject player;
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
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(other.gameObject.GetComponent<EnemyScript>().canExecute && player.GetComponent<Player>().isExecuting)
            {
                player.GetComponent<Player>().audioSource.clip = player.GetComponent<Player>().clip[1];
                player.GetComponent<Player>().audioSource.Play();
                player.GetComponent<Player>().health += 10;
                player.GetComponent<Player>().currentClip += 1;
                other.gameObject.GetComponent<EnemyScript>().health -= 9999;
                player.GetComponent<Player>().sprite.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
