using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour
{
    public void Loadscene(int index)//�V�[���ǂݍ���
    {
        SceneManager.LoadScene(index);
    }
}
