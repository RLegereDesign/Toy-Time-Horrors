using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartForce : MonoBehaviour {

    private Rigidbody rb;

    public float DartSpeed;



	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.forward * DartSpeed);

        


    }
	
	// Update is called once per frame
	void Update () {
        
		
	}
}
