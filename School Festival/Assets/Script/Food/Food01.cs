using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fork"))
        {
            this.gameObject.transform.parent = other.gameObject.transform;
            Eat();
        }
    }

    void Eat()
    {
        Invoke("Destroy", 1);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
