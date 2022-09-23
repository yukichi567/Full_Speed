using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class bottun : MonoBehaviour
{
    [SerializeField] GameObject _open;
    [SerializeField] GameObject _close;
    [SerializeField] string _changeScene;

    // Start is called before the first frame update
    public void click()
    {
        _open.gameObject.SetActive(true);
        _close.gameObject.SetActive(false);
    }

    public void LoadScenes()
    {
        SceneManager.LoadScene(_changeScene);
    }
}
