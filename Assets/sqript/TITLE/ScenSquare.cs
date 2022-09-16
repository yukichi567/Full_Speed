using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenSquare : MonoBehaviour
{
    /// <summary>•Ï‚¦‚½‚¢ƒV[ƒ“‚Ì–¼‘O</summary>
    [SerializeField] string _changeScene;

    public void LoadScenes()
    {
        SceneManager.LoadScene(_changeScene);
    }
}
