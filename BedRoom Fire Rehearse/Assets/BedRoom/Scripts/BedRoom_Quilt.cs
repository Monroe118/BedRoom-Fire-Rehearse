
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_Quilt : MonoBehaviour {

    // The main object
    public BedRoom_Events enventManager;

    // Water's game object script
    public BedRoom_Water water;

    // The game object collisions begin
    private void OnCollisionEnter(Collision other)
    {

        // Collider with the Door game object
        if (other.transform.name == "door")
        {

            GameObject.Find("quilt").transform.position = other.transform.position;

            // The last step
            enventManager.win = true;
            enventManager.GameOver();
        }

        // Collider with the IsWater game object
        if (other.transform.name == "IsWater")
        {

            // Open the water
            water.OpenWater();

        }
    }

    // The game object collides
    void OnCollisionStay(Collision other)
    {
        GameObject.Find("quilt").transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        
    }

    // When the object closes the tap
    void OnCollisionExit(Collision other)
    {
        // Collision with the IsWater game object
        if (other.transform.name == "IsWater") {

            // Shut the water
            water.ShutWater();

            // The next step
            enventManager.ToPutQuilt();

        }
    }
}
