using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    /// <summary>
    /// �^�C�}�[�p�ϐ�
    /// </summary>
    TimeSpan minutes, seconds, timer;

    [Tooltip("�����Ɏg�p����摜�i�[�p"), SerializeField]
    Sprite[] sprites = new Sprite[10];

    /// <summary>�^�C�}�[�p�e�L�X�g</summary>
    [Tooltip("�Q�[���̐������Ԃ�\��"), SerializeField] Text countDown;

    private void Start()
    {
        NumberImage();
    }
    /// <summary>
    /// ���Ԍ���
    /// </summary>
    void Update()
    {
        minutes = TimeSpan.FromMinutes(1);
        seconds = TimeSpan.FromSeconds(Time.time);
        timer = minutes - seconds;
        countDown.text = $"{timer.Minutes:00}:{timer.Seconds:00}";
        if (timer.Seconds == 0 && timer.Minutes == 0)
        {
            StartCoroutine(TimeOver());
        }
    }

    void NumberImage()
    {

    }

    IEnumerator TimeOver()
    {
        yield return null;
        Debug.Log("����`���`");
    }
}
