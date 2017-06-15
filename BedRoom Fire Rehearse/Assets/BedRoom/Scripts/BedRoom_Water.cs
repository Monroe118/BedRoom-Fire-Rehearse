using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_Water : MonoBehaviour {

    // Water's particle system
    public ParticleSystem water;

    // Turn on the tap
    public void OpenWater() {

        water.Play();
        
    }

    // Shut the water
    public void ShutWater() {

        water.Stop();

    }
}
