using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveHits : MonoBehaviour
{
    [SerializeField] ConsecutiveHitsSetting[] _setting = new ConsecutiveHitsSetting[4];

    [SerializeField] Animator _anim;
    [Tooltip("前回ボタンを押した時間")]
    private float _hitTime;
    private float _countTime;

    void Start()
    {

    }

    void Update()
    {
        ConsecutiveHitsJudge();
    }

    /// <summary>
    /// 連打判定をする
    /// </summary>
    private void ConsecutiveHitsJudge()
    {
        if (_anim == null)
        {
            Debug.LogError("AnimationがNullです");
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _anim.SetBool("Push", true);
            //スコアの追加
            GameManager.Addscore(1);
            //前回ボタンを押したスピードでAnimationの速度を変える
            if (_hitTime > _setting[0].HitTimeArray)
            {
                _anim.speed = _setting[0].AnimSpeed;
                _hitTime = 0;
            }
            else
            {
                for (int i = 0; i < _setting.Length - 1; i++)
                {
                    if (_hitTime > _setting[i + 1].HitTimeArray && _hitTime < _setting[i].HitTimeArray)
                    {
                        _anim.speed = _setting[i].AnimSpeed;
                        _hitTime = 0;
                        break;
                    }
                }
            }
        }

        _hitTime += Time.deltaTime;
    }
}

[System.Serializable]
class ConsecutiveHitsSetting
{
    public float HitTimeArray => _hitTimeArray;
    [Header("Animationが切り替わる時間の設定")]
    [SerializeField] float _hitTimeArray;
    public float AnimSpeed => _animSpeed;
    [Header("Animationのスピード")]
    [SerializeField] float _animSpeed;
}
