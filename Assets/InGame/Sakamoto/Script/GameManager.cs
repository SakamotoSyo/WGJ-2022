using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static int Score => score;
    private static int score;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
}

    public static void Addscore(int scorepoint)//�X�R�A�ǉ�
    {
        score += scorepoint;
    }

    public static void ResetScore() 
    {
        score = 0;
    }
    
}
