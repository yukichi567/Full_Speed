using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenSquare : MonoBehaviour
{
    /// <summary>�ς������V�[���̖��O</summary>
    [SerializeField] string _changeScene;

    public void LoadScenes()
    {
        SceneManager.LoadScene(_changeScene);
    }
}
