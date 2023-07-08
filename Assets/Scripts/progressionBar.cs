using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progressionBar : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject endPosition;
    public GameObject player;

    public GameObject moving_bar;
    public GameObject cow_icon;
    public GameObject bar_start;
    public GameObject bar_end;
    public GameObject success_window;

    private float bar_length;
    private float total_distance;
    private float player_distance;
    private float ungo_percentage;
    private Vector3 bar_start_position;
    private Vector3 bar_end_position;
    // Start is called before the first frame update
    void Start()
    {
        success_window.SetActive(false);
        bar_start_position = bar_start.GetComponent<RectTransform>().localPosition;
        bar_end_position = bar_end.GetComponent<RectTransform>().localPosition;
        bar_length = Mathf.Abs(bar_end_position.x - bar_start_position.x);
        total_distance = Mathf.Abs(endPosition.transform.position.z - startPosition.transform.position.z);
        player_distance = Mathf.Abs(endPosition.transform.position.z - player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        player_distance = Mathf.Abs(endPosition.transform.position.z - player.transform.position.z);
        ungo_percentage = player_distance / total_distance;
        moving_bar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ungo_percentage * bar_length);
        var icon_move = (1-ungo_percentage) * bar_length + bar_start_position.x;
        cow_icon.GetComponent<RectTransform>().localPosition = new Vector3(icon_move, bar_start_position.y,0);

        if (player_distance < 0.1f)
        {

            // show success window
            success_window.SetActive(true);
            // disable playercontroller

            // update score / stars

            // update level
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
        }
    }
}
