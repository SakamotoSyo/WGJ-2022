using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTranstion : MonoBehaviour
{
    public void Loadscene(int index)//�V�[���ǂݍ���
    {
        SceneManager.LoadScene(index);
    }
    public void MainScene()
    {
        GameManager.ResetScore();
        SceneManager.LoadScene("MainScene");
    }
}
