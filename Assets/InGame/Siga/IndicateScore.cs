using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class IndicateScore : MonoBehaviour
{
    int _score = 0;
    public Sprite[] numimage;
    public List<int> number = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        

        _score = GameManager.score;
        View(_score);
    }

    // Update is called once per frame
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
