using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);

    }
    public void Game()
    {
        SceneManager.LoadScene(3);

    }
}
