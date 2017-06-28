
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoom_Quilt : MonoBehaviour {

    // The main object
    public BedRoom_Events enventManager;

    // Water's game object script
    public BedRoom_Water water;

    public Transform waterBasic;
    public Transform quilt;

    private bool isWater;

    // The game object collisions begin
    void OnCollisionEnter(Collision other)
    {
        if (isWater) {
            // Collider with the Door game object
            if (other.transform.name == "door")
            {

                quilt.transform.localScale = new Vector3(0.01f, 0.01f, 0.005f);
                quilt.transform.position = other.transform.position;

                // The last step
                enventManager.win = true;
                enventManager.GameOver();
            }
        }
        
        // Collider with the IsWater game object
        if (other.transform.name == "IsWater")
        {
            
            // Open the water
            water.OpenWater();
            waterBasic.gameObject.SetActive(true);
        }
    }

    // The game object collides
    void OnCollisionStay(Collision other)
    {
        
            Debug.Log("Quilt...");
            quilt.transform.localScale = new Vector3(0.01f, 0.01f, 0.005f);
            
    }

    // When the object closes the tap
    void OnCollisionExit(Collision other)
    {
        // Collision with the IsWater game object
        if (other.transform.name == "IsWater") {

            // Shut the water
            water.ShutWater();
            waterBasic.gameObject.SetActive(false);

            isWater = true;

            // The next step
            enventManager.ToPutQuilt();

        }
    }
}
