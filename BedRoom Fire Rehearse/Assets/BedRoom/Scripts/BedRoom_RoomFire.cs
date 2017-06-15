using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_RoomFire : MonoBehaviour {

    public ParticleSystem roomFire;

    // The bedroom on fire
    public void OpenRoomFire() {

        roomFire.Play();

    }
}
