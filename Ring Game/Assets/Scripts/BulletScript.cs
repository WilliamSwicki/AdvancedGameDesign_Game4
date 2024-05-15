using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float damage;
    public int dir;
    public GameObject target;
    public GameObject player;
    public GameObject collishionParticles;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = GameObject.FindWithTag("Center");
if(player.GetComponent<Player>().isFaceingRight)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), Vector3.up);
        transform.RotateAround(target.transform.position, Vector3.up, (dir * speed) * Time.deltaTime);
        damage -= (damage*0.05f)*Time.deltaTime;
        if(damage<=0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.GetComponent<Player>().currentClip < player.GetComponent<Player>().maxClipSize)
            {
                player.GetComponent<Player>().currentClip++;
            }
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyScript>().health -= damage;
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(PlayParticle());

        }
    }
    public IEnumerator PlayParticle()
    {
        collishionParticles.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(collishionParticles.GetComponent<ParticleSystem>().main.duration);
        Destroy(this.gameObject);
    }
}
