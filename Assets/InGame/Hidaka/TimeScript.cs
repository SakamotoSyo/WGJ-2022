using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class TimeScript : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] _spArray = new SpriteRenderer[5];
    [Header("��������")]
    [SerializeField] float _time;

    bool _isPlaying = false;

    /// <summary>
    /// �^�C�}�[�p�ϐ�
    /// </summary>
    TimeSpan minutes, seconds, timer;
    int minTime = 0;

    [Tooltip("�����Ɏg�p����摜�i�[�p"), SerializeField]
    Sprite[] sprites = new Sprite[10];

    /// <summary>�^�C�}�[�p�e�L�X�g</summary>
    //[Tooltip("�Q�[���̐������Ԃ�\��"), SerializeField] Text countDown;

    //Dictionary<char, Sprite> num = new Dictionary<char, Sprite>()
    //{
    //    {'0', sprites[0] },
    //    {'1', sprites[1] },
    //    {'2', sprites[2] },
    //    {'3', sprites[3] },
    //    {'4', sprites[4] },
    //    {'5', sprites[5] },
    //    {'6', sprites[6] },
    //    {'7', sprites[7] },
    //    {'8', sprites[8] },
    //    {'9', sprites[9] },
    //};

    /// <summary>
    /// ���Ԍ���
    /// </summary>
    void Update()
    {
        _time -= Time.deltaTime;
        //minutes = TimeSpan.FromSeconds(1);
        //seconds = TimeSpan.FromSeconds(Time.time) ;
        if (!_isPlaying)
        {
           // timer = minutes - seconds;
        }
        //var a =  timer.Seconds.ToString();

        if (_time >= 10)
        {
            _spArray[0].sprite = sprites[int.Parse(_time.ToString()[0].ToString())];
            _spArray[1].sprite = sprites[int.Parse(_time.ToString()[1].ToString())];
        }
        else if(_time > 0)
        {
            _spArray[0].sprite = sprites[0];
            _spArray[1].sprite = sprites[int.Parse(_time.ToString()[0].ToString())];
        }
        //_spArray[0].sprite = sprites[]

        //countDown.text = $"{sprites[]:00}:{timer.Seconds:00}";
        if (_time <= 0)
        {
            _isPlaying = true;
            StartCoroutine(TimeOver());
        }
    }


    IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(2);
        SceneTranstion.LoadScene("ResultScene");
        Debug.Log("����`���`");
    }
}
