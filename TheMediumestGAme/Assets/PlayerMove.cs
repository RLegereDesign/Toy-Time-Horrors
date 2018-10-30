using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	CharacterController charCon; 
    
    Rigidbody rb;

	public float speed;
	public float jumpSpeed;
	public float gravity;
    public float jumpHeight;

	private Vector3 direction;

	// Use this for initialization
	void Start () {

		charCon = GetComponent<CharacterController> ();
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {



        // Rotate around y - axis
        //transform.Rotate(0, Input.GetAxis("Horizontal") , 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        charCon.SimpleMove(forward * curSpeed);


        // Move forward / backward
        Vector3 sideways = transform.TransformDirection(1, 0, 0);
        float curnSpeed = speed * Input.GetAxis("Horizontal");
        charCon.SimpleMove(sideways * curnSpeed);

       


    }

}
