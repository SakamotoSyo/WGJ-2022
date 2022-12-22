
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IndicateScore : MonoBehaviour
{
    //[SerializeField]int _score = 100; //動作テスト時はこの行のコメント化を解除
    int _score = 0;
    public Sprite[] numimage;
    public List<int> number = new List<int>();

    
    void Start()
    {
        

       //_score = GameManager.score;  //ゲームのフローの中で使うときはこの行のコメント化を解除
        View(_score);
    }

    
    void Update()
    {
        
    }
    public void GetScore(int a)
    {
        _score = a;
    }
    public void View (int a)
    {
        var digit = a;

        List<int> number = new List<int>();
        while(digit != 0)
        {
               a  = digit % 10;
            digit = digit / 10;
            number.Add(a);
        }
        GameObject.Find("ScoreImage").GetComponent<Image>().sprite = numimage[number[0]];
        for (int i = 1; i < number.Count ; i++)
        {
            RectTransform scoreimage = (RectTransform)Instantiate(GameObject.Find("ScoreImage")).transform;
            scoreimage.SetParent(this.transform, false);
            scoreimage.localPosition = new Vector2(scoreimage.localPosition.x - scoreimage.sizeDelta.x * i, scoreimage.localPosition.y);
            scoreimage.GetComponent<Image>().sprite = numimage[number[i]];
        
        }
    }
}
