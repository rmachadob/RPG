using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public Transform target;
    //reference to the tilemap size 
    public Tilemap theMap;
    //2 values to store the position of the map
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

	// Use this for initialization
	void Start () {
        
        target = PlayerController.instance.transform;
        //That gets from the tile map the minimum amount (furthest left on the x and furthest down on the y)
        bottomLeftLimit = theMap.localBounds.min;

        //pela lógica contrário uso o max pra pegar o limite de cima e da direita
        topRightLimit = theMap.localBounds.max;
	}
	
	// LateUpdate is called once per frame after Update
    // Com o Update a câmera e o player acontecem ao mesmo tempo, então o movimento da câmera pode engasgar porque a ordem de execução fica bagunçada
	void LateUpdate () {
        //set the positon of the camera
        //the transform.position of the object that this script is attached to       
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);//Vector 3 this time because the transform has the x, y and z positons
        //fot the z axis I get the already existing by transform.position.z

        //keep the camera inside the bounds
        //Mathf = Math function, o Clamp é pra prender entre dois valores (topRightLimit e bottomLeftLimit)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), 
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
            transform.position.z);
        //Como é Vector 3 preciso fazer os 3 eixos o z eu não altero, pego como está 


    }
}
