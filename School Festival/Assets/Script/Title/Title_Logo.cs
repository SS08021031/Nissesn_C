using UnityEngine;

public class Title_Logo : MonoBehaviour
{
    public float speed;
    public Transform target1;
    public Transform target2;

    public bool target1Chekc;
    
   
    void Start()
    {
        target1Chekc = false;
    }

    void Update()
    {

        if (target1Chekc == false)
        {
            
            target1.transform.position = new Vector3(0f, 0f, 0f);

            transform.position = Vector3.MoveTowards(transform.position, target1.position, speed);

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            target1Chekc = true;
        }

        if(target1Chekc == true)
        {
            target2.transform.position = new Vector3(0f, 10f, 0f);

            transform.position = Vector3.MoveTowards(transform.position, target2.position, speed);

        }
    }
}
