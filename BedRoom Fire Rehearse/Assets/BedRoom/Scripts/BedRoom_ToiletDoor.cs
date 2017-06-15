using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_ToiletDoor : MonoBehaviour {

    public BedRoom_Events eventManager;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "IsToiletDoor")
        {
            eventManager.ShutToiletDoor();
        }
    }
}
