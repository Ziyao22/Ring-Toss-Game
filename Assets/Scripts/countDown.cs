using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countDown : MonoBehaviour
{
    public GameObject ready_obj;
    public GameObject countDownWindow;

    private TextMeshProUGUI count_text;
    private float timer = 0f;

    private void Awake()
    {
        timer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        count_text = ready_obj.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            Destroy(ready_obj);
            Destroy(countDownWindow);
        }
        else if (timer > 4f)
        {
            count_text.text = "Go!";
        }
        else if (timer > 3f)
        {
            count_text.text = "1";
        }
        else if (timer > 2f)
        {
            count_text.text = "2";
        }
        else if (timer > 1f)
        {
            count_text.text = "3";
        }
    }
}
