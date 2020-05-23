using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;


	// Use this for initialization
	void Start () {
        
        target = PlayerController.instance.transform;
	}
	
	// LateUpdate is called once per frame after Update
    // Com o Update a câmera e o player acontecem ao mesmo tempo, então o movimento da câmera pode engasgar porque a ordem de execução fica bagunçada
	void LateUpdate () {
        //set the positon of the camera
        //the transform.position of the object that this script is attached to       
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);//Vector 3 this time because the transform has the x, y and z positons
        //fot the z axis I get the already existing by transform.position.z
    }
}
