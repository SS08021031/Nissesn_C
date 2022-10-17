using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nagaosi : MonoBehaviour
{

    public Slider slider;
    

    // 連打中のクリック間隔
    [SerializeField] float interval = 0.3f;

    public Sprite Max;
    public Sprite Harf;
    public Sprite Min;

    SpriteRenderer sprite_change;

    [SerializeField] Text[] texts;

    private bool isClicked;

    float time = 6f;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        
        slider.value = 0;
        isClicked = false;
        text = GetComponent<Text>();
        sprite_change = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = "Time:" + time;
        

        if (Input.GetKey(KeyCode.Return))
        {
            isClicked = true;
            
            slider.value += 0.01f;
        }

        if (slider.value > 2.5)
        {
            if(slider.value < 3.7)
            {
                
                time -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            isClicked = false;
        }

        //クリックされていなければ実行
        if (!isClicked)
        {
            DecreaseGauge();
        }

        if(time < 4)
        {
            if (time > 3.1)
            {
                HARF();
            }
        }
        
            if (time < 0)
            {
                MIN();
            }
        }
    

    void HARF()
    {
        sprite_change.sprite = Harf;
    }
    void MIN()
    {
        sprite_change.sprite = Min;
        Invoke("Destroy", 1);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    // ゲージを減らす
    void DecreaseGauge()
    {
        slider.value -= 0.01f;
    }
}
//2.5~3.7