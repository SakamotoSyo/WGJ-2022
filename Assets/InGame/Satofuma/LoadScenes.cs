using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour
{
    public void Loadscene(int index)//シーン読み込み
    {
        SceneManager.LoadScene(index);
    }
}
