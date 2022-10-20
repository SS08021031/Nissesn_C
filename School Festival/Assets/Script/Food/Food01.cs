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
        if(transform.position.y >= 0.7f)
        {
            Eat();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fork"))
        {
            Audio_Manager.instance.PlaySE(7);
            this.gameObject.transform.parent = other.gameObject.transform;
        }
           
    }
    
    void Eat()
    {
        Invoke("Destroy", 1);
        
    }
    void Destroy()
    {
        Destroy(gameObject);
        Audio_Manager.instance.PlaySE(1);
        Timer.score += FoodScore;
    }
}
