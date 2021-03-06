﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//alterei o Script Execution Order para antes do Default Time, assim ele roda antes do Area Entrance e para de bugar a posição do player nas trnasições de cena
public class AreaExit : MonoBehaviour
{
    //generic Script we're gonna use to exit every scene

    public string areaToLoad;
    public string areaTransitionName;
    //esses objetos que eu crio aqui aparecem no Inspector dentro do Script que adicionei como componente
    public AreaEntrance theEntrance;

    // Use this for initialization
    void Start()
    {//as soon as this object starts, the entrance that we are linking will set the transitionName to be the same as the areaTransitionName 
        theEntrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //test to see if anything enters the trigger collider 
    //Collider 2D is the name of wjhatever collider enters the trigger box (collision)
    private void OnTriggerEnter2D(Collider2D other)
    {

        //making sure it's actually the player entering the area, otherwise an NPC could trigger the transition out of nowhere
        //.tag that I attributed on Unity

        if (other.tag == "Player")
        {

            //load into a new scene(need to import Scene Management)
            SceneManager.LoadScene(areaToLoad);

            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
