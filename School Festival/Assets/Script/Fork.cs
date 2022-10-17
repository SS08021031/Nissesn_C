using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    public bool isClick;
    public float startSpeed = 6;
    public Vector2 startPosition;
    public double returnSpeed = 0.1;
    
    void Start()
    {
        isClick = false;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            isClick = true;
        }

        if(Input.GetKeyUp(KeyCode.Return))
        {
            isClick = false;
        }

        if (isClick == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * startSpeed );
        }
        if(isClick == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, (float)returnSpeed);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Food"))
        {
            //this.gameObject.transform.parent = other.gameObject.transform;
        }
        
    }
}
