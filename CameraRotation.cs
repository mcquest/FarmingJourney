using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Vector3 rotationPoint;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.RotateAround(rotationPoint, Vector3.forward, 30*Time.deltaTime);
        this.transform.Rotate(0, 30, 5 * Time.deltaTime);
    }
}
