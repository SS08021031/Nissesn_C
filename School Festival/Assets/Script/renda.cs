using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renda : MonoBehaviour
{
    [SerializeField] Image gauge; // �Q�[�W
    float gaugeAmount; // �Q�[�W�̗�

    // �A�Œ��̃N���b�N�Ԋu
    [SerializeField] float interval = 0.3f;

    // ���N���b�N�ڂ���A�Œ��ɐ؂�ւ��邩 
    [SerializeField] int startCount = 3;
    int clickCount; // �N���b�N��
    int clickCountRecord; // �N���b�N���̋L�^
    bool isCounting; // �N���b�N�𐔂��Ă��邩�ǂ���
    bool isMashing; // �A�ł��Ă��邩�ǂ���
    float second; // �N���b�N�Ԃ̕b��

    [SerializeField] Text[] texts;

    

    public Sprite Max;
    public Sprite Harf;
    public Sprite Min;

    SpriteRenderer sprite_change;

    // Start is called before the first frame update
    void Start()
    {
        // Image�R���|�[�l���g�̐ݒ�
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

        // �G���^�[�L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.Return))
        {
            // �����Ă����Ԃɂ���
            isCounting = true;

            // �b�������Z�b�g
            second = 0f;

            // �N���b�N����1����
            clickCount++;
        }

        // �����Ă���Ƃ�
        if (isCounting)
        {
            texts[5].text = "�����Ă���";

            // �b�����J�E���g
            second += Time.deltaTime;

            // ���Ԑ؂�̂Ƃ�
            if (second > interval)
            {
                // �����Ă��Ȃ���Ԃɂ���
                isCounting = false;

                // �A�ł��Ă��Ȃ���Ԃɂ���
                isMashing = false;

                // �N���b�N�����L�^
                clickCountRecord = clickCount;

                // �N���b�N�������Z�b�g
                clickCount = 0;
            }
            // �����Ă��ĘA�Œ��łȂ��Ƃ�
            else if (!isMashing)
            {


                // �N���b�N�����w��̐��ȏ�ɂȂ����Ƃ�
                if (clickCount >= startCount)
                {
                    // �A�ŏ�Ԃɂ���
                    isMashing = true;
                }
            }
            // �����Ă��ĘA�ł��Ă���Ƃ�
            else
            {
                texts[5].text = "�A�ł��Ă���";

                // �Q�[�W�𑝂₷
                gaugeAmount += 0.2f * Time.deltaTime;
                if (gaugeAmount >= 1f) gaugeAmount = 1f;

                gauge.fillAmount = gaugeAmount;

               

            }
        }
        // �����Ă��Ȃ��Ƃ�
        else
        {
            texts[5].text = "�����Ă��Ȃ�";

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

    

