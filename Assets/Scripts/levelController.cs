using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelController : MonoBehaviour
{
    private GameObject[] disabled_levels;
    // Start is called before the first frame update
    void Start()
    {
        disabled_levels = GameObject.FindGameObjectsWithTag("disabled_level");
        for (int i = 0; i < disabled_levels.Length; i++)
        {
            GameObject level_icon = disabled_levels[i];
            level_icon.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
