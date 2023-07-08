using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonChangeScene : MonoBehaviour
{
    public void MoveToScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
