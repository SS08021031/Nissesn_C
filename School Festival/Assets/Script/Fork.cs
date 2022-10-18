using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    public bool isClick;
    public float startSpeed = 6;
    public Vector3 startPosition;
    public double returnSpeed = 0.1;
    [SerializeField] float MaxAngle;
    public Quaternion rot;
    public Quaternion q;

    void Start()
    {
        isClick = false;
        startPosition = this.transform.localEulerAngles;
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
            transform.Rotate(new Vector3(0, 0, -1));
        }
        if(isClick == false)
        {
            //transform.position = Vector3.MoveTowards(transform.position, startPosition, (float)returnSpeed);
            //transform.rotation = Quaternion.AngleAxis(2, Vector3.forward);
            transform.Rotate(Vector3.forward, 45);
        }

        Vector3 adjustment = transform.eulerAngles;

         //0〜360°を-180〜180°に調整
        if (adjustment.x > 180) adjustment.x -= 360;
        if (adjustment.y > 180) adjustment.y -= 360;
        if (adjustment.z > 180) adjustment.z -= 360;

         //x,y,zそれぞれの角度をMaxAngle以下、-MaxAngle以上に調整
        if (adjustment.x > MaxAngle) adjustment.x = MaxAngle;
        else if (adjustment.x < -MaxAngle) adjustment.x = -MaxAngle;
        if (adjustment.y > MaxAngle) adjustment.y = MaxAngle;
        else if (adjustment.y < -MaxAngle) adjustment.y = -MaxAngle;
        if (adjustment.z > MaxAngle) adjustment.z = MaxAngle;
        else if (adjustment.z < -MaxAngle) adjustment.z = -MaxAngle;

        // -180〜180°を0〜360°に戻す
        if (adjustment.x < 0) adjustment.x += 360;
        if (adjustment.y < 0) adjustment.y += 360;
        if (adjustment.z < 0) adjustment.z += 360;

        // 現在の回転角度を更新
        transform.eulerAngles = adjustment;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Food"))
        {
            //this.gameObject.transform.parent = other.gameObject.transform;
        }
        
    }
}

// 回転角度に制限を掛ける---------------------------------------------------------- -

// 現在の回転を取得
//Vector3 adjustment = transform.eulerAngles;

// 0〜360°を-180〜180°に調整
//if (adjustment.x > 180) adjustment.x -= 360;
//if (adjustment.y > 180) adjustment.y -= 360;
//if (adjustment.z > 180) adjustment.z -= 360;

// x,y,zそれぞれの角度をMaxAngle以下、-MaxAngle以上に調整
//if (adjustment.x > MaxAngle) adjustment.x = MaxAngle;
//else if (adjustment.x < -MaxAngle) adjustment.x = -MaxAngle;
//if (adjustment.y > MaxAngle) adjustment.y = MaxAngle;
//else if (adjustment.y < -MaxAngle) adjustment.y = -MaxAngle;
//if (adjustment.z > MaxAngle) adjustment.z = MaxAngle;
//else if (adjustment.z < -MaxAngle) adjustment.z = -MaxAngle;

// -180〜180°を0〜360°に戻す
//if (adjustment.x < 0) adjustment.x += 360;
//if (adjustment.y < 0) adjustment.y += 360;
//if (adjustment.z < 0) adjustment.z += 360;

// 現在の回転角度を更新
//transform.eulerAngles = adjustment;
       // }
