using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timing : MonoBehaviour
{
    public Slider slider;
    private bool maxValue;
    private bool isClicked;
    private bool clearValue;

    public Sprite Max;
    public Sprite Harf;
    public Sprite Min;

    SpriteRenderer sprite_change;

    void Start()
    {
        slider.value = 0;
        maxValue = false;
        isClicked = false;

        sprite_change = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            isClicked = true;
        }

        //クリックされていなければ実行
        if (!isClicked)
        {
            //5に達した場合と、0に戻った場合のフラグ切替え
            if (slider.value == 5)
            {
                maxValue = true;
            }

            if (slider.value == 0)
            {
                maxValue = false;
            }

            //フラグによるスライダー値の増減
            if (maxValue)
            {
                slider.value -= 0.01f;
            }
            else
            {
                slider.value += 0.01f;
            }
        }
        //スライダーの止まった位置によって
        if (isClicked == true)
        {
            
            if (slider.value > 1.9)
            {
                if(slider.value < 3)
                {
                    //Invoke("HARF", 0);
                    Invoke("MIN", 0);
                }
            }

            if(slider.value > 1.01)
            {
                if(slider.value < 1.89)
                {
                    HARF();
                    
                    Invoke("ReStart", 1);
                }
            }
            if(slider.value >3.01)
            {
                if (slider.value < 3.9)
                {
                    HARF();
                    Invoke("ReStart", 1);
                }
            }
        }

    }

    void HARF()
    {
        sprite_change.sprite = Harf;
    }
    void MIN()
    {
        sprite_change.sprite = Min;
        Invoke("Destroy", 2);
    }
    
    void ReStart()
    {
        slider.value = 0;
        isClicked = false;
    }
    
    void Destroy()
    {
        Destroy(gameObject);
    }
}
