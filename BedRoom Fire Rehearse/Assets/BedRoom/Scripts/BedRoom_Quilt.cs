
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BedRoom_Quilt : MonoBehaviour {

    // The main object
    public BedRoom_Events enventManager;

    // Water's game object script
    public BedRoom_Water water;

    // Door's game object script
    public BedRoom_Door doorManager;

    public Transform waterBasic;
    public Transform quilt;
    public Transform quiltOnDoor;

    private int count = 0;

    private bool isWater;

    // The game object collisions begin
    void OnCollisionEnter(Collision other)
    {
        if (doorManager.isDoorShut) {

            if (other.transform.name == " floor")
            {

                quilt.transform.localScale = new Vector3(0.02f, 0.02f, 0.005f);

            }

            if (isWater)
            {

                // Collider with the Door game object
                if (other.transform.name == "IsQuilt")
                {

                    quilt.gameObject.SetActive(false);
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
        
    }

    // When the object closes the tap
    void OnCollisionExit(Collision other)
    {
        if (doorManager.isDoorShut)
        {
            // Collision with the IsWater game object
            if (other.transform.name == "IsWater")
            {

                // Shut the water
                water.ShutWater();
                waterBasic.gameObject.SetActive(false);

                isWater = true;
                count = count + 1;
                if (count == 1)
                {
                    // The next step
                    enventManager.ToPutQuilt();
                }
            }
        }
    }
}
