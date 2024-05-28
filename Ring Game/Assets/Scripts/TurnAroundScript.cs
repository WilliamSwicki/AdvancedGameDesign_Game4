using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundScript : MonoBehaviour
{
    public GameObject Enemy;
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
            Enemy.GetComponent<EnemyScript>().dir = Enemy.GetComponent<EnemyScript>().dir * -1;
        }
    }
}
