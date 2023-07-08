using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour
{
    public GameObject pauseWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame()
    {
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseWindow.SetActive(false);
        Time.timeScale = 1;
    }

}
