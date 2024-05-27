using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveText : MonoBehaviour
{
    public TMP_Text text;
    public EnemyCounter enemyCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyCounter.canFightBoss)
        {
            text.text = "Exorcise demons " + Mathf.Abs((enemyCounter.enemiesAlive-2)- (enemyCounter.enemies.Length - 2)) + "/" + (enemyCounter.enemies.Length - 2);
        }
        else
        {
            text.text = "Defeat the Summoner";
        }
    }
}
