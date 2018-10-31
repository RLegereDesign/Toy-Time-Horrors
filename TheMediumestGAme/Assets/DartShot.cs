using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShot : MonoBehaviour {
    public GameObject Dart;
    public GameObject Spawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Dart, Spawner.transform.position, gameObject.transform.rotation);


        }
		
	}
}
