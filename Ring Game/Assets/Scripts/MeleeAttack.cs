using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int damage;
    public bool isPlayer;
    GameObject player;
    public GameObject bloodSprey;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && isPlayer && player.GetComponent<Player>().isAttacking)
        {
            other.gameObject.GetComponent<EnemyScript>().health -= damage;
            Instantiate(bloodSprey,other.transform.position, Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Player") && !isPlayer)
        {
            other.gameObject.GetComponent<Player>().health -= damage;
            
        }
    }
}
