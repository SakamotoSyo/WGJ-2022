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
    public void MainScene()
    {
        GameManager.ResetScore();
        SceneManager.LoadScene("MainScene");
    }
}
