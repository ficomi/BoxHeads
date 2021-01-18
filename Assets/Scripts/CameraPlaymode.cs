using UnityEngine;
using System.Collections;

public class CameraPlaymode : MonoBehaviour
{
    public Camera MainCamera;
    public Camera CameraInBuilding;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "F1")
        {
            Building.invisibleRoof();
            
        }

        if (collision.gameObject.tag == "F2")
        {
            Building.invisibleRoof2();
            

        }
        if (collision.gameObject.tag == "BuildCamera")
        {
          
            enableCameraInBuilding();
            Building.houseLightsEnable(collision.name);
        }
        if (collision.gameObject.tag == "StreetLights")
        {

          
            Building.houseLightsEnable(collision.name);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "F1")
        {
            Building.visibleRoof();
         
        }
        if (collision.gameObject.tag == "F2")
        {
            Building.visibleRoof2();
           

        }
        if (collision.gameObject.tag == "BuildCamera")
        {
            enableMainCamera();
            Building.houseLightsDisable(collision.name);
        }
        if (collision.gameObject.tag == "StreetLights")
        {
           
            Building.houseLightsDisable(collision.name);
        }
    }



    void enableCameraInBuilding()
    {
        MainCamera.enabled = false;
        CameraInBuilding.enabled = true;

    }

    void enableMainCamera()
    {

        MainCamera.enabled = true;
        CameraInBuilding.enabled = false;

    }


}

