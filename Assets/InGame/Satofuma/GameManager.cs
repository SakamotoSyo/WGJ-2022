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
    private string[] rankingstring = new string[3] { "���", "���", "�O��" };
    private int[] rankingpoint = new int[3];
    private int[] rankingValue = new int[3];
    public static int score;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        score = 0;
        SetRanking();
        GetRanking();
        for(int i = 0; i < rankingtext.Length; i++)//�����L���O�̓ǂݍ���
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
    public static void Addscore(int scorepoint)//�X�R�A�ǉ�
    {
        score += scorepoint;
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
            if(score > rankingValue[i])
            {
                rankingValue[i + 1] = rankingValue[i];
                rankingValue[i] = score;
                return;
            }
        }
        for(int i = 0; i < rankingpoint.Length; i++)//�����L���O�̕ۑ�
        {
            PlayerPrefs.SetInt(rankingstring[i], rankingValue[i]);
        }
    }
    
}
