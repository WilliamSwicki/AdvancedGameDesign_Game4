using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpwanObject : MonoBehaviour
{
    public GameObject[] objs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spwanObject(int i)
    {
        objs[i].gameObject.SetActive(true);
    }
    public void spwanAllObjects()
    {
        for(int i = 0; i < objs.Length; i++)
        {
            if (objs[i].gameObject != null)
            {
                objs[i].gameObject.SetActive(true);
            }

        }
    }
}
