using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Transform target ;
    public float speed = 1.0f;

    private GameObject o;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey(KeyCode.A))
        {
            target = o.transform;
            target.transform.position = new Vector3(42f, 2f, 25f);
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position= Vector3.MoveTowards(transform.position,target.position,step);
        
    }
}
