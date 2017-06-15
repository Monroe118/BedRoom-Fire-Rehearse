using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_Fire : MonoBehaviour {

    // The particle system of the flame
    public ParticleSystem fire;

    // The fire begins to burn
    public void FireOn()
    {
        fire.Play();
    }

}
