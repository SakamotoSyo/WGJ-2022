using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score => score;
    private static int score;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void Addscore(int scorepoint)//�X�R�A�ǉ�
    {
        score += scorepoint;
    }
    
}
