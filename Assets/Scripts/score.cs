using UnityEngine;
using System;
using System.Collections;

public class score : MonoBehaviour
{
    static public int points = 0 ;
    static public int pointsperkill = 10;
    public Texture2D backScore;
    public GUIStyle backScoreS;
    Vector2 pos = new Vector2(Screen.width - Screen.width / 4 - 20, 20); // zacatecni bod
                                                                         // Use this for initialization
void Start()
    {
        setDefaultValues();
         }
    public static void addScore()
    {
        points += pointsperkill;
    }

    void OnGUI()
    {
        backScoreS.fontSize = Screen.width / 60;
        if (!health.mrtev && !Pause_menu.pauza)
        {
            //draw the background:
            GUI.BeginGroup(new Rect(pos.x, pos.y, Screen.width / 4, Screen.height / 6), backScore); // Pozadi

            GUI.BeginGroup(new Rect(0, 0, Screen.width / 4, Screen.height / 9), points.ToString(), backScoreS); //text score



            GUI.EndGroup();
            GUI.EndGroup();

        }

    }
    public static void setDefaultValues()
    {
        points = 0;
    }
}