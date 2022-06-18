using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float speed = 0.01f;
        Transform myTransform = gameObject.GetComponent<Transform>();
        myTransform.position += new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
