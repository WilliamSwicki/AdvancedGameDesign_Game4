using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int enemiesAlive;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemiesAlive = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesAlive = enemies.Length;
        if (enemiesAlive <= 0)
        {
            this.GetComponent<WinScript>().WinScene();
        }
        for(int i = 0; i< enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemiesAlive--;
            }
        }
    }
}