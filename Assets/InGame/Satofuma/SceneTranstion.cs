using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTranstion : MonoBehaviour
{
    public void Loadscene(int index)//ƒV[ƒ““Ç‚İ‚İ
    {
        SceneManager.LoadScene(index);
    }
    public static void LoadScene(string l)
    {
        SceneManager.LoadScene(l);
    }

    public void MainScene()
    {
        GameManager.ResetScore();
        AudioManager.Instance.Reset();
        SceneManager.LoadScene("MainScene");
    }
}
