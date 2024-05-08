using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float damage;
    public int dir;
    public GameObject target;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Boss");
        target = GameObject.FindWithTag("Center");
        dir = enemy.GetComponent<EnemyScript>().dir;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), Vector3.up);
        transform.RotateAround(target.transform.position, Vector3.up, (dir * speed) * Time.deltaTime);
        Destroy(this.gameObject, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
