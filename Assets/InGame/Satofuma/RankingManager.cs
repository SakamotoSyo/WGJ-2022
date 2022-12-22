using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class RankingManager : MonoBehaviour
{
    [SerializeField] Text[] rankingtext = new Text[3];
    [SerializeField] Text resulttext;
    private string[] rankingstring = new string[3] { "一位", "二位", "三位" };
    private int[] rankingpoint = new int[3];
    private int[] rankingValue = new int[3];

    private void Start()
    {
        SetRanking();
        GetRanking();
        for(int i = 0; i < rankingtext.Length; i++)//ランキングの読み込み
        {
            rankingtext[i].text = rankingValue[i].ToString();
        }
        resulttext.text = GameManager.Score.ToString();
    }

    private void Update()
    {
       
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
            if(GameManager.Score > rankingValue[i])
            {
                if(i < 3)
                {
                    rankingValue[i + 1] = rankingValue[i];
                }
                rankingValue[i] = GameManager.Score;
                return;
            }
        }
        for(int i = 0; i < rankingpoint.Length; i++)//ランキングの保存
        {
            PlayerPrefs.SetInt(rankingstring[i], rankingValue[i]);
        }
    }
    
}
