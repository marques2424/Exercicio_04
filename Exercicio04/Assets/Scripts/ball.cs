using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider Agent)
    {
        Destroy(gameObject);
    }
}

