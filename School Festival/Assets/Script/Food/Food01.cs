using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food01 : MonoBehaviour
{
    private List<GameObject> hitObjects = new List<GameObject>();
    public int FoodScore;
    
    void Start()
    {
        
    }
    void Update()
    {
        if(transform.position.y >= 0.8f)
        {
            Debug.Log("takai");
            Eat();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fork"))
        {
            
            this.gameObject.transform.parent = other.gameObject.transform;
        }
            if (other.CompareTag("kuti"))
            {

                Debug.Log("kuti");
                //Eat();
            }
    }
    


    void Eat()
    {
        Invoke("Destroy", 1);
        
    }
    void Destroy()
    {
        Destroy(gameObject);
        Timer.score += FoodScore;
    }
}
