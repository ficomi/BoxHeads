using UnityEngine;
using System.Collections;

public class Char_colour : MonoBehaviour {
    public static int Colour = 1;
    static GameObject character;
    
    // Use this for initialization
    void Start () {
        character = GameObject.FindWithTag("custom_player");
    }
	
	
    public static void changeColour() {
        checkColour();
       
        if (Colour == 1)
        {
            character.GetComponent<Renderer>().material.color = Color.white;
            Load_custom_player.ColourOfPlayer("white");
        }
        else if (Colour == 2) {
            character.GetComponent<Renderer>().material.color = Color.black;
            Load_custom_player.ColourOfPlayer("black");
        }
        else if (Colour == 3)
        {
            character.GetComponent<Renderer>().material.color = Color.yellow;
            Load_custom_player.ColourOfPlayer("yellow");
        }
        else if (Colour == 4)
        {
            character.GetComponent<Renderer>().material.color = Color.red;
            Load_custom_player.ColourOfPlayer("red");
        }
    }
    static void checkColour() {
        if (Colour < 1)
        {
            Colour = 4;
        }
        else if (Colour > 4) {
            Colour = 1;
        }


    }

}
