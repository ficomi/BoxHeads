using UnityEngine;
using System.Collections;

public class HUD_GUI : MonoBehaviour
{


    // private Pause_menu Pause_menu;
    public Texture dead;
    public GUIStyle text;
    static GameObject[] enemy;
    // Use this for initialization
   

    // Update is called once per frame
  void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag(Nepritel_ai.zjistiObtiznost());

    }

    void OnGUI()
    {
        if (!health.mrtev && !Pause_menu.pauza)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2, 50, Screen.width / 4, Screen.height / 6), enemy.Length.ToString(), text);
            text.fontSize = Screen.width / 60;
            GUI.EndGroup();
        }

        if (health.mrtev && !Pause_menu.pauza) // vykresli orazek "you are dead"
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), dead); // vykresli "you are dead"
           
               
            
        }


    }
}
