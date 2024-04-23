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
    }
}
