﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_Door : MonoBehaviour {

    public BedRoom_Events eventManager;
    private int count = 0;
    public bool isDoorShut;

    void OnTriggerEnter(Collider collider)
    {

        // Closed for the first time
        if (collider.name == "IsDoor") {
            count += 1;

            isDoorShut = true;

            if (count == 1) {

                eventManager.ShutDoor();

            }
        }
    }

    void OnTriggerExit(Collider other)
    {

        // Exit for the first time
        if (other.name == "IsDoor")
        {
            isDoorShut = false;
            eventManager.ShutDoors();

        }

    }

}
