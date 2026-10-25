using UnityEngine;

public class TrackingScript : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public Transform[] targets = new Transform[4]; // Array to hold references to the four target transforms
    private Transform currentActiveTarget; // Variable to hold the currently active target

    void Update()
    {
        float shortestDistance = Mathf.Infinity; // Initialize shortest distance to a very large value
        currentActiveTarget = null;

        for (int i = 0; i < targets.Length; i++) // Loop through each target in the array
        {
            if (targets[i] != null)
            {
                float dist = Vector3.Distance(transform.position, targets[i].position); // Calculate the distance from the current object to the target
                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    currentActiveTarget = targets[i];
                }
            }
        }

        if (currentActiveTarget == null) // If no active target is found, exit the method
        {
            return;
        }

        Vector3 dir = (currentActiveTarget.position - transform.position).normalized; // Calculate the direction vector from the current object to the active target
        dir.y = 0; 

        Quaternion targetRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

        float dot = Vector3.Dot(transform.forward, dir);
    }
}
