using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene0 : MonoBehaviour
{
    public Button play;


    private void Start()
    {
        play.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
