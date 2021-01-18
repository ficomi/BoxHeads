using UnityEngine;
using System.Collections;

public class hpBar : MonoBehaviour
{
    
    public GUIStyle progress_empty;
    public GUIStyle progress_full;

    //current progress
    public static float barDisplay = 1;

    Vector2 pos = new Vector2(20,20); // odsazeni  10 pixelu zleva a 10 pixelu zezhora
  

    public Texture2D emptyTex; // okraje hp baru
    public Texture2D fullTex; // vypln hp baru
    //void Update() {
    //    hpBarSize();

    //}
    void OnGUI()
    {

        if (!health.mrtev && !Pause_menu.pauza) { 
              
                GUI.BeginGroup(new Rect(pos.x, pos.y,Screen.width/4, Screen.height/ 6), emptyTex, progress_empty); // vykreslim okraje hp baru

        //GUI.Box(new Rect(pos.x, pos.y, Screen.width / 6, Screen.height / 6), fullTex, progress_full);

       
        GUI.BeginGroup(new Rect(0, 0, Screen.width / 4 * barDisplay, Screen.height / 6)); // vytvori neviditelny okraj ktery bude vypln baru * zdravi
        GUI.Box(new Rect(0, 0, Screen.width / 4, Screen.height / 6), fullTex, progress_full); // vykresleni vyplně

        GUI.EndGroup();
        GUI.EndGroup();
    }
    }

   public static void hpBarSize()
    {
        barDisplay = health.zdravi/ health.zdravi_max; // vydelime skutecne / hp max abychom dostal % vypln
    }

}