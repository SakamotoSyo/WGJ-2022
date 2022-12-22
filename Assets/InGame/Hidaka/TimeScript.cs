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

    bool _isPlaying = false;

    /// <summary>
    /// タイマー用変数
    /// </summary>
    TimeSpan minutes, seconds, timer;
    int minTime = 0;

    [Tooltip("文字に使用する画像格納用"), SerializeField]
    Sprite[] sprites = new Sprite[10];

    /// <summary>タイマー用テキスト</summary>
    //[Tooltip("ゲームの制限時間を表示"), SerializeField] Text countDown;

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
    /// 時間減少
    /// </summary>
    void Update()
    {
        minutes = TimeSpan.FromMinutes(1);
        seconds = TimeSpan.FromSeconds(Time.time);
        if (!_isPlaying)
        {
            timer = minutes - seconds;
        }
        var a =  timer.Seconds.ToString();

        if (timer.Seconds >= 10)
        {
            _spArray[0].sprite = sprites[int.Parse(timer.Seconds.ToString()[0].ToString())];
            _spArray[1].sprite = sprites[int.Parse(timer.Seconds.ToString()[1].ToString())];
        }
        else 
        {
            _spArray[0].sprite = sprites[0];
            _spArray[1].sprite = sprites[int.Parse(timer.Seconds.ToString()[0].ToString())];
        }
        //_spArray[0].sprite = sprites[]

        //countDown.text = $"{sprites[]:00}:{timer.Seconds:00}";
        if (timer.Minutes != 1 && timer.Seconds == minTime)
        {
            _isPlaying = true;
            StartCoroutine(TimeOver());
        }
    }


    IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("しゅ～りょ～");
    }
}
