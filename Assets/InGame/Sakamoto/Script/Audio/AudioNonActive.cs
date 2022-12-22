using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNonActive : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource _audio;
    void Start()
    {
       
    }

    void Update()
    {
        StartCoroutine(AudioObserver());
    }

    IEnumerator AudioObserver() 
    {
        yield return null;
        if (!_audio.isPlaying) 
        {
            gameObject.SetActive(false);
        }
    }
}
