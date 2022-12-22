using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveHits : MonoBehaviour
{
    [SerializeField] ConsecutiveHitsSetting[] _setting = new ConsecutiveHitsSetting[4];

    [SerializeField] Animator _anim;
    [Tooltip("�O��{�^��������������")]
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
    /// �A�Ŕ��������
    /// </summary>
    private void ConsecutiveHitsJudge()
    {
        if (_anim == null)
        {
            Debug.LogError("Animation��Null�ł�");
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _anim.SetBool("Push", true);
            //�X�R�A�̒ǉ�
            GameManager.Addscore(1);
            //�O��{�^�����������X�s�[�h��Animation�̑��x��ς���
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
    [Header("Animation���؂�ւ�鎞�Ԃ̐ݒ�")]
    [SerializeField] float _hitTimeArray;
    public float AnimSpeed => _animSpeed;
    [Header("Animation�̃X�s�[�h")]
    [SerializeField] float _animSpeed;
}
