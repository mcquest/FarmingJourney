// Charles Farris
// Follow.cs
// Attach to object and set target to follow

// Built in classes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define object class
public class Follow : MonoBehaviour
{
    // Variable to set follow target
    [SerializeField] Transform target; 
    // Follow smoothness variable
    [SerializeField] float smooth = 2f; 
    // Distance away from target in the Z direction
    [SerializeField] int zDist = 0;
    // Distance away from target in the Y direction
    [SerializeField] int yDist = 0;
    // Distance away form target in the X direction
    [SerializeField] int xDist = 5; 
	
	// Update is called once per frame
	void Update ()
    {
        // Create endTarget position variable to update every frame
        Vector3 endLocation = new Vector3(target.position.x + xDist, target.position.y + yDist , target.position.z + zDist);
        // Set object position equal to end target position
        transform.position = Vector3.Lerp (transform.position, endLocation, Time.deltaTime * smooth);
	}
}
