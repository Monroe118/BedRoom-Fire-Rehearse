
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BedRoom_Quilt : MonoBehaviour {

    // The main object
    public BedRoom_Events enventManager;

    // Water's game object script
    public BedRoom_Water water;

    public Transform waterBasic;
    public Transform quilt;
    public Transform quiltOnDoor;
    public Transform quiltFold;

    private int count = 0;

    private bool isWater;

    // The game object collisions begin
    void OnCollisionEnter(Collision other)
    {
        
        quilt.gameObject.SetActive(false);
        Debug.Log("1");
        quiltFold.gameObject.SetActive(true);

        if (isWater) {

            // Collider with the Door game object
            if (other.transform.name == "IsQuilt")
            {

                quiltFold.gameObject.SetActive(false);
                quiltOnDoor.gameObject.SetActive(true);
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

    // When the object closes the tap
    void OnCollisionExit(Collision other)
    {

        // Collision with the IsWater game object
        if (other.transform.name == "IsWater") {

            // Shut the water
            water.ShutWater();
            waterBasic.gameObject.SetActive(false);

            isWater = true;
            count = count + 1;
            if (count == 1) {
                // The next step
                enventManager.ToPutQuilt();
            }
            
        }
    }
}
