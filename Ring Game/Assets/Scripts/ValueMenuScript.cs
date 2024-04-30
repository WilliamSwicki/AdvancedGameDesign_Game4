using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ValueMenuScript : MonoBehaviour
{
    public TMP_InputField[] playerStats;
    public GameObject player;
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        playerStats[0].text = playerScript.maxHealth.ToString();
        playerStats[1].text = playerScript.health.ToString();
        playerStats[2].text = playerScript.jumpPower.ToString();
        playerStats[3].text = playerScript.jumpCount.ToString();
        playerStats[4].text = playerScript.maxClipSize.ToString();
        playerStats[5].text = playerScript.currentClip.ToString();
        playerStats[6].text = playerScript.fireRate.ToString();
        playerStats[7].text = playerScript.speed.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void confirmChange()
    {
        playerScript.maxHealth = float.Parse(playerStats[0].text);
        playerScript.health = float.Parse(playerStats[1].text);
        playerScript.jumpPower = float.Parse(playerStats[2].text);
        playerScript.jumpCount = int.Parse(playerStats[3].text);
        playerScript.maxClipSize = float.Parse(playerStats[4].text);
        playerScript.currentClip = float.Parse(playerStats[5].text);
        playerScript.fireRate = float.Parse(playerStats[6].text);
        playerScript.speed = float.Parse(playerStats[7].text);
    }
    
}
