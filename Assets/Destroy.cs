using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy: MonoBehaviour {
    
    public GameObject Mycamera;

   
    // Use this for initialization
    void Start () {

        Mycamera = Camera.main.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        

        if (gameObject.transform.position.z <= Mycamera.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
