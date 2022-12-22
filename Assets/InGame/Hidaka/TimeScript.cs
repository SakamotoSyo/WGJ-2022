using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    /// <summary>
    /// タイマー用変数
    /// </summary>
    TimeSpan minutes, seconds, timer;

    [Tooltip("文字に使用する画像格納用"), SerializeField]
    Sprite[] sprites = new Sprite[10];

    /// <summary>タイマー用テキスト</summary>
    [Tooltip("ゲームの制限時間を表示"), SerializeField] Text countDown;

    private void Start()
    {
        NumberImage();
    }
    /// <summary>
    /// 時間減少
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
        Debug.Log("しゅ～りょ～");
    }
}
