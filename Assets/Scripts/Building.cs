using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{

    static GameObject[] Roofs;
    static GameObject[] Roofs2;
    static GameObject[] HouseLights;
    static GameObject House;
    static GameObject Light;
  

    // Use this for initialization
    void Start()
    {
      
        Roofs = GameObject.FindGameObjectsWithTag("Roof");
        Roofs2 = GameObject.FindGameObjectsWithTag("Roof2");
        HouseLights = GameObject.FindGameObjectsWithTag("HouseLights");
        dissableAllHouseLights();
    }

    public static void visibleRoof()
    {
        for (int i = 0; i < Roofs.Length; i++)
        {
            Roofs[i].GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }
    public static void invisibleRoof()
    {
        for (int i = 0; i < Roofs.Length; i++)
        {
            Roofs[i].GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }



    public static void visibleRoof2()
    {

        foreach (GameObject i in Roofs2)
        {
            i.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }

    }

    public static void invisibleRoof2()
    {

        foreach (GameObject i in Roofs2)
        {
            i.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }

    }



    public static void houseLightsEnable(string name) {
        House = GameObject.Find(name);
        var children = House.GetComponentInChildren<Transform>();
        foreach (Transform child in children) {
          
            if (child.tag == "HouseLights") {
                child.gameObject.SetActive(true);
             
            }


        }

    }
    public static void houseLightsDisable(string name)
    {
        House = GameObject.Find(name);
        var children = House.GetComponentInChildren<Transform>();
        foreach (Transform child in children)
        {
           
            if (child.tag == "HouseLights")
            {
                child.gameObject.SetActive(false);
              
            }


        }

    }

    void dissableAllHouseLights() {
        foreach (GameObject i in HouseLights)
        {
            i.SetActive(false);
        }
    }
}
