using UnityEngine;
using System.Collections;


public class Load_custom_player : MonoBehaviour
{
    Material Custom_player;
    GameObject Default_player;

    static string ColourOfPlayerString;
    // Use this for initialization
    void Start() {

        lookForPlayer();

    }

    void loadMaterial()
    {

        if (Resources.Load("custom_player_color_" + ColourOfPlayerString, typeof(Material)) != null)
        {
            Custom_player = (Material)Resources.Load("custom_player_color_" + ColourOfPlayerString, typeof(Material)); 
            Default_player.GetComponent<SkinnedMeshRenderer>().material = Custom_player;

        }
        else
        {
            // print("nenacten ´Material");


        }
    }
    void lookForPlayer()
    {
        if (GameObject.FindWithTag("custom_player") != null)
        {
            Default_player = GameObject.FindWithTag("custom_player");
            loadMaterial();
        }
        else
        {
            print("player nenalezen");
        }

        

    }
    static public void ColourOfPlayer(string colourString)
    {
        ColourOfPlayerString = colourString;
        

    }


}
