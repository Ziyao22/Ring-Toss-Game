using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5f; // Speed of movement along the y-axis

    private void Update()
    {
        float newZPosition = transform.position.z + (speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);
    }
}
