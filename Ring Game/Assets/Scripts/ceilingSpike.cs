using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ceilingSpike : MonoBehaviour
{
    public BossEnemyScript boss;
    private bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
transform.RotateAround(boss.target.transform.position, Vector3.up, (boss.dir * (boss.speed * 1.25f)) * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Colaspe"))
        {
            Instantiate(boss.stalamite, other.gameObject.transform.position, Quaternion.Euler(180, 0, 0));
        }
    }
    public void activate()
    {
        canMove = true;
    }
    public void deactivate()
    {   
        canMove= false;
        this.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.position.y, this.transform.parent.transform.position.z);
       
    }
}
