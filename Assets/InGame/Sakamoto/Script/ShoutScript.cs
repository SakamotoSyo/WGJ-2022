using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutScript : MonoBehaviour
{
    [SerializeField] GameObject _shoutObj;
    [SerializeField] GameObject _shoutObj2;

    /// <summary>
    /// AnimationEventÇ≈åƒÇ—èoÇ∑
    /// </summary>
    public void Shout1() 
    {
        Instantiate(_shoutObj, transform.position, _shoutObj.transform.rotation);
        AudioManager.Instance.PlaySound(SoundPlayType.shout1);
    }

    /// <summary>
    /// AnimationEventÇ≈åƒÇ—èoÇ∑
    /// </summary>
    public void Shout2()
    {
        Instantiate(_shoutObj2, transform.position, _shoutObj.transform.rotation);
        AudioManager.Instance.PlaySound(SoundPlayType.shout2);
    }
}
