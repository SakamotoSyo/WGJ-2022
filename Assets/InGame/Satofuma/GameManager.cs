using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip voiceSE;
    [SerializeField] Text[] rankingtext = new Text[3];
    private AudioSource source;
    private string[] rankingstring = new string[3] { "一位", "二位", "三位" };
    private int[] rankingpoint = new int[3];
    private int[] rankingValue = new int[3];
    public static int score;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        score = 0;
        SetRanking();
        GetRanking();
        for(int i = 0; i < rankingtext.Length; i++)//ランキングの読み込み
        {
            rankingtext[i].text = rankingValue[i].ToString();
        }
    }
    private void Update()
    {
        
        bool onece = true;
        if(score % 50 == 0 && onece == true)
        {
            source.PlayOneShot(voiceSE);
            onece = false;
        }
        else
        {
            onece = true;
        }
    }
    public static void Addscore(int scorepoint)//スコア追加
    {
        score += scorepoint;
    }
    private void GetRanking()//ランキング呼び出し
    {
        for (int i = 0; i < rankingpoint[i]; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(rankingstring[i]);
        }
    }
    private void SetRanking()
    {
        for(int i = 0;i < rankingpoint.Length; i++)//ランキングの上書き
        {
            if(score > rankingValue[i])
            {
                rankingValue[i + 1] = rankingValue[i];
                rankingValue[i] = score;
                return;
            }
        }
        for(int i = 0; i < rankingpoint.Length; i++)//ランキングの保存
        {
            PlayerPrefs.SetInt(rankingstring[i], rankingValue[i]);
        }
    }
    
}
