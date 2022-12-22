using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutScript : MonoBehaviour
{

    public void Shout1() 
    {
        AudioManager.Instance.PlaySound(SoundPlayType.shout1);
    }

    public void Shout2()
    {
        AudioManager.Instance.PlaySound(SoundPlayType.shout2);
    }
}
