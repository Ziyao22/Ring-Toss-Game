using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayer : MonoBehaviour
{
    public int speed;
    public GameObject energy_bar_controller;
    private Vector3 current_position;
    
    // Start is called before the first frame update
    void Start()
    {
        current_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            current_position = transform.position;
            current_position.z += speed * Time.deltaTime;
            transform.position = current_position;
        }

        if (Input.GetKey(KeyCode.A))
        {
            current_position = transform.position;
            current_position.z -= speed * Time.deltaTime;
            transform.position = current_position;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            var num = energy_bar_controller.GetComponent<energyBarController>().energy_num;
            if (num > 0)
            {
                // dash effect
                energy_bar_controller.GetComponent<energyBarController>().energy_num -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var num = energy_bar_controller.GetComponent<energyBarController>().energy_num;
            if (num < 5)
            {
                // when collide with bottle
                energy_bar_controller.GetComponent<energyBarController>().energy_num += 1;
            }
        }

    }
}
