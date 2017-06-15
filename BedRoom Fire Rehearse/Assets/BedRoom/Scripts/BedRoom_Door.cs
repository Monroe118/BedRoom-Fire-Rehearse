using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_Door : MonoBehaviour {

    public BedRoom_Events eventManager;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "IsDoor") {

            eventManager.ShutDoor();
        }
    }

}
