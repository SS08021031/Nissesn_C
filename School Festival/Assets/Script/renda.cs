using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renda : MonoBehaviour
{
    [SerializeField] Image gauge; // ゲージ
    float gaugeAmount; // ゲージの量

    // 連打中のクリック間隔
    [SerializeField] float interval = 0.3f;

    // 何クリック目から連打中に切り替えるか 
    [SerializeField] int startCount = 3;
    int clickCount; // クリック数
    int clickCountRecord; // クリック数の記録
    bool isCounting; // クリックを数えているかどうか
    bool isMashing; // 連打しているかどうか
    float second; // クリック間の秒数

    [SerializeField] Text[] texts;

    

    public Sprite Max;
    public Sprite Harf;
    public Sprite Min;

    SpriteRenderer sprite_change;

    // Start is called before the first frame update
    void Start()
    {
        // Imageコンポーネントの設定
        gauge.type = Image.Type.Filled;
        gauge.fillMethod = Image.FillMethod.Horizontal;
        gauge.fillOrigin = 0;
        gauge.fillAmount = 0f;

        sprite_change = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = "clickCount: " + clickCount;
        texts[1].text = "clickCountRecord: " + clickCountRecord;
        texts[2].text = "isCounting: " + isCounting;
        texts[3].text = "isMashing: " + isMashing;
        texts[4].text = "second: " + second;

        // エンターキーが押されたとき
        if (Input.GetKey(KeyCode.Return))
        {
            // 数えている状態にする
            isCounting = true;

            // 秒数をリセット
            second = 0f;

            // クリック数を1増加
            clickCount++;
        }

        // 数えているとき
        if (isCounting)
        {
            texts[5].text = "数えている";

            // 秒数をカウント
            second += Time.deltaTime;

            // 時間切れのとき
            if (second > interval)
            {
                // 数えていない状態にする
                isCounting = false;

                // 連打していない状態にする
                isMashing = false;

                // クリック数を記録
                clickCountRecord = clickCount;

                // クリック数をリセット
                clickCount = 0;
            }
            // 数えていて連打中でないとき
            else if (!isMashing)
            {


                // クリック数が指定の数以上になったとき
                if (clickCount >= startCount)
                {
                    // 連打状態にする
                    isMashing = true;
                }
            }
            // 数えていて連打しているとき
            else
            {
                texts[5].text = "連打している";

                // ゲージを増やす
                gaugeAmount += 0.2f * Time.deltaTime;
                if (gaugeAmount >= 1f) gaugeAmount = 1f;

                gauge.fillAmount = gaugeAmount;

               

            }
        }
        // 数えていないとき
        else
        {
            texts[5].text = "数えていない";

        }

        if (gauge.fillAmount >= 0.4f)
        {
            sprite_change.sprite = Harf;
        }
        if(gauge.fillAmount >= 1f)
        {
            sprite_change.sprite = Min;
            
            Invoke("Destroy", 1);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}

    

