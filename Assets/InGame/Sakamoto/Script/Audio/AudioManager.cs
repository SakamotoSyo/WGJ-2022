using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class AudioManager
{

    [Tooltip("Audio�̏����i�[���Ă���ϐ�")] private AudioDataBase _params = default;
    [Tooltip("Count����ϐ�")] private int _poolCount = 0;
    [Tooltip("��������Obj��ۑ�����Poll�N���X��List")] private List<Pool> pool = new List<Pool>();
    private static AudioManager _instance = new AudioManager();

    static public AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AudioManager();
            }
            return _instance;
        }
    }

    /// <summary>Prefab�̐���������</summary>
    AudioManager()
    {
        // string data = "Assets/InGame/Sakamoto/Data/AudioDataBase/AudioDataBase.asset";
        // var path = AssetDatabase.GUIDToAssetPath(data);
#if UNITY_EDITOR
        // _params = AssetDatabase.LoadAssetAtPath<AudioDataBase>(data);
#endif
        //resources�t�H���_����ǂݍ��ޏ����������ɋL�q����B
        _params = Resources.Load<AudioDataBase>("AudioDataBase");

        if (_params == null)
        {
            Debug.LogError("AudioDataBase��������܂���");
        }
        CreatePool();
    }

    /// <summary>�e��Prefab�𐶐�����</summary>
    public void CreatePool()
    {
        //�S�Ă̐������I�������return
        if (_poolCount >= _params.paramsList.Count)
        {
            return;
        }

        //�ݒ肵�Ă���Prefab�̐���������
        for (int i = 0; i < _params.paramsList[_poolCount].MaxCount; i++)
        {
            var obj = Object.Instantiate(_params.paramsList[_poolCount].SoundPrefab);
            obj.SetActive(false);
            SavePool(obj, _params.paramsList[_poolCount].Type);
        }

        _poolCount++;
        CreatePool();
    }

    /// <summary>
    /// ���𗬂��Ƃ��ɌĂяo���֐�
    /// </summary>
    /// <param name="type">���������T�E���h�̎��</param>
    /// <returns>���𗬂�GameObject</returns>
    public GameObject PlaySound(SoundPlayType type)
    {

        foreach (var pool in pool)
        {
            if (pool.Obj.activeSelf == false && pool.Type == type)
            {
                pool.Obj.SetActive(true);
                return pool.Obj;
            }
        }
        Debug.Log("�Đ�");
        //�����������Ă��镪�ő���Ȃ��Ȃ�����A�V������������
        var newObj = Object.Instantiate(_params.paramsList.Find(x => x.Type == type).SoundPrefab);
        SavePool(newObj, type);
        return newObj;
    }

    public void Reset()
    {
        pool.Clear();
    }

    /// <summary>
    /// ���������I�u�W�F�N�g��List�ɒǉ����ĕۑ�����֐�
    /// </summary>
    /// <param name="obj">���������I�u�W�F�N�g</param>
    /// <param name="type">���������I�u�W�F�N�g��Type</param>
    private void SavePool(GameObject obj, SoundPlayType type)
    {
        pool.Add(new Pool { Obj = obj, Type = type });
    }

    /// <summary>������������ۑ����Ă������߂̃N���X</summary>
    private struct Pool
    {
        public GameObject Obj { get; set; }
        public SoundPlayType Type { get; set; }
    }
}

/// <summary>
/// �炵�������̎��
/// </summary>
public enum SoundPlayType
{
    shout1,
    shout2,
}
