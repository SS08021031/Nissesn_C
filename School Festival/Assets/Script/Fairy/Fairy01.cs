using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy01 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 10f;
    private Vector3 enemypos;
    
    void Start()
    {
        enemypos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        Audio_Manager.instance.PlaySE(9);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.x >= 25.0f)
        {
            Destroy(gameObject);
        }
    }
    
}
