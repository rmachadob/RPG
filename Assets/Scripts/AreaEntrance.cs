using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour {

    public string transitionName;
    //if the player has the Countryside-1 string on them, move the player to the AreaEntrance 

	// Use this for initialization
	void Start () {
		if(transitionName == PlayerController.instance.areaTransitionName)//if the area transition name ON THE PLAYER equals the areaTransitionName
        {
            //EVERY OBJECT IN UNITY HAS A TRANSFORM ATTACHED TO IT
            //grab the payer's transform position and set it to be equal to the transform position of the Area Entrance
            PlayerController.instance.transform.position = transform.position;
                                         }
        UIFade.instance.FadeFromBlack();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
