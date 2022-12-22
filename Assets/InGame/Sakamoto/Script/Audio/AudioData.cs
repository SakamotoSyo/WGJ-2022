using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "AudioData", menuName = "SakamotoScriptable/AudioData")]
public class AudioData : ScriptableObject
{
    public SoundPlayType Type;
    [Header("Sound��Prefab")]
    public GameObject SoundPrefab;
    [Header("Prefab�̐�����")]
    public int MaxCount;
}
