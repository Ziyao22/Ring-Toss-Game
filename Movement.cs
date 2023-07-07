using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform targetObject; // The object to decrement the z scale

    private Vector3 targetPosition = new Vector3(15.0f, 0.0f, -22.0f); // The position to move towards
    private Vector3 originalPosition; // The original position of the object

    private float originalSpeed; // The original speed of the object
    private float speed = 10f; // Speed at which the object moves

    // Flag to track if the object is currently moving
    private bool isMoving = false;
    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        // Check if the object is not already moving and count is less than 10
        if (!isMoving && count < 10)
        {
            // Calculate the distance between the current position and the target position
            float distance = Vector3.Distance(transform.position, targetPosition);

            // Check if the object hasn't reached the target position
            if (distance <= 0.01f)
            {
                // Increment the count
                count++;
                // Reset the object to its original position
                transform.position = originalPosition;
            }

            // Set a new random target position
            targetPosition = GetRandomPosition();

            // Start moving the object towards the target position
            isMoving = true;
            StartCoroutine(MoveToTarget());
        }
    }

    IEnumerator MoveToTarget()
    {
        originalPosition = transform.position; // Store the original position

        float startTime = Time.time; // Time when the movement starts
        float journeyLength = Vector3.Distance(originalPosition, targetPosition); // Total distance to move

        // Loop until the object reaches the target position
        while (transform.position != targetPosition)
        {
            // Calculate the distance covered and the fraction of the journey completed
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            // Move the object smoothly using Lerp
            transform.position = Vector3.Lerp(originalPosition, targetPosition, fractionOfJourney);

            yield return null;
        }

        // Object has reached the target position
        // You can add any additional actions or logic here

        // Reset the flag
        isMoving = false;

        // Decrease the target object's local z scale by 0.1f
        if (targetObject != null)
        {
            Vector3 scale = targetObject.localScale;
            scale += new Vector3(0f, 5f, 0f);
            targetObject.localScale = scale;
        }

        // Increase the speed by 2
        speed += 3f;

        // Check if the movement count reaches 10
        if (count >= 10)
        {
            // Stop the game or add any necessary actions
            Debug.Log("Movement completed 10 times. Game stopped.");
            // You can add additional logic to stop the game here
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-67f, 65f);
        float randomY = Random.Range(0f, 0f);
        float randomZ = Random.Range(-20f, 10f);

        return new Vector3(randomX, randomY, randomZ);
    }
}
