using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public int playCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().health <= 0)
        {
            player.GetComponent<Player>().cameraTarget.GetComponent<AudioSource>().enabled = false;
            
            if (playCount == 0)
            {
                player.GetComponent<Player>().audioSource.clip = player.GetComponent<Player>().clip[4];
                player.GetComponent<Player>().audioSource.time = 0.7f;
                player.GetComponent<Player>().audioSource.Play();
                playCount++;
            }
            StartCoroutine(Fade());
        }

    }
    public IEnumerator Fade()
    {
 
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
    public IEnumerator sound()
    {
        int playCount = 0;
        if(playCount == 0)
        {
            player.GetComponent<Player>().audioSource.clip = player.GetComponent<Player>().clip[4];
            player.GetComponent<Player>().audioSource.Play();
            playCount++;
        }
        
        yield return null;
    }
}
