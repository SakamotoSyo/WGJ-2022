
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IndicateScore : MonoBehaviour
{
    //[SerializeField]int _score = 100; //動作テスト時はこの行のコメント化を解除
    [SerializeField] SpriteRenderer[] _spRender;
    public Sprite[] numimage;
   // public List<int> number = new List<int>();
    void Update()
    {
        ScoreView();
    }
  
    public void ScoreView() 
    {
        var score = GameManager.Score;
        if (score % 50 == 0) 
        {
            //AudioManager.Instance.PlaySound(SoundPlayType);
        }

        for(int i = 0; i < score.ToString().Length; i++) 
        {
            _spRender[i].sprite = numimage[int.Parse(score.ToString()[score.ToString().Length - i - 1].ToString())];
        }
    }
}
//public void View (int a)
//{
//    var digit = a;

//    List<int> number = new List<int>();
//    while(digit != 0)
//    {
//           a  = digit % 10;
//        digit = digit / 10;
//        number.Add(a);
//    }
//    GameObject.Find("Canvas Prot/ScoreImage").GetComponent<Image>().sprite = numimage[number[0]];
//    for (int i = 1; i < number.Count ; i++)
//    {
//        RectTransform scoreimage = (RectTransform)Instantiate(GameObject.Find("ScoreImage")).transform;
//        scoreimage.SetParent(this.transform, false);
//        scoreimage.localPosition = new Vector2(scoreimage.localPosition.x - scoreimage.sizeDelta.x * i, scoreimage.localPosition.y);
//        scoreimage.GetComponent<Image>().sprite = numimage[number[i]];

//    }
//}

