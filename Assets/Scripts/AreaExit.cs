using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {
    //generic Script we're gonna use to exit every scene

    public string areaToLoad;

    // Use this for initialization
    void Start()
    {

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
        }
    }
}
