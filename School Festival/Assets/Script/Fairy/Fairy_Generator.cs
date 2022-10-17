using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy_Generator : MonoBehaviour
{
    public GameObject[] enemyPrefab; //�I�u�W�F�N�g���i�[����z��ϐ�
    private float time; //�o������Ԋu�𐧌䂷�邽�߂̕ϐ�
    private int number; //�����_���������邽�߂̕ϐ�

    void Start()
    {
        time = 1.0f; //���Ԃ�҂����A�ŏ���1����o��
    }

    void Update()
    {
        time -= Time.deltaTime; //time���玞�Ԃ����炷
        if (time <= 0.0f) //0�b�ɂȂ��
        {
            time = 3.0f; //1�b�ɂ���
            number = Random.Range(0, enemyPrefab.Length); //Random.Range (�ŏ��l, �ő�l) �����̏ꍇ�͍ő�l�͏��O
            Instantiate(enemyPrefab[number], new Vector3(-20, -7, 0), Quaternion.identity); //-20,-7,0�Ƀ����_���o���A�����̐ݒ�͖���
        }
    }
}