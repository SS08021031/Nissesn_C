using UnityEngine;

public class Door : MonoBehaviour
{
    public int counter;
    SpriteRenderer sr;
    public bool DoorCheck;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        DoorCheck = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            DoorCheck = true;
        }

        if (DoorCheck == true)
        {
            counter++;

            transform.Rotate(new Vector3(0f, 0.1f, 0f));

            if (counter >= 1000)
            {
                //sr.enabled = false;
            }
        }
        
    }
}
