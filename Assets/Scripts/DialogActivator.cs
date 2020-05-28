﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour {

    public string[] lines;
    //the player is in the area, check to see if they have pressed a button (bool)
    private bool canActivate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)//uso o Collider 2D pra disparar
    {
        if(other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)//uso o Collider 2D pra disparar
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
