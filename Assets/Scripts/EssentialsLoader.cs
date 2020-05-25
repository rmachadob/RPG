﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour {

    public GameObject UIScreen;
    public GameObject player;

    // Use this for initialization
    void Awake()
    {
        if (UIFade.instance == null)
        {
            Instantiate(UIScreen);
        }

        if (PlayerController.instance == null)
        {
            Instantiate(player);
        }
    }

    void Update()
    {


    }
}
