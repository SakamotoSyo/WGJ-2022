using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class RankingManager : MonoBehaviour
{
    [SerializeField] Text[] rankingtext = new Text[3];
    private string[] rankingstring = new string[3] { "���", "���", "�O��" };
    private int[] rankingpoint = new int[3];
    private int[] rankingValue = new int[3];

    private void Start()
    {
        SetRanking();
        GetRanking();
        for(int i = 0; i < rankingtext.Length; i++)//�����L���O�̓ǂݍ���
        {
            rankingtext[i].text = rankingValue[i].ToString();
        }
    }

    private void Update()
    {
       
    }
   
    private void GetRanking()//�����L���O�Ăяo��
    {
        for (int i = 0; i < rankingpoint[i]; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(rankingstring[i]);
        }
    }
    private void SetRanking()
    {
        for(int i = 0;i < rankingpoint.Length; i++)//�����L���O�̏㏑��
        {
            if(GameManager.Score > rankingValue[i])
            {
                rankingValue[i + 1] = rankingValue[i];
                rankingValue[i] = GameManager.Score;
                return;
            }
        }
        for(int i = 0; i < rankingpoint.Length; i++)//�����L���O�̕ۑ�
        {
            PlayerPrefs.SetInt(rankingstring[i], rankingValue[i]);
        }
    }
    
}
