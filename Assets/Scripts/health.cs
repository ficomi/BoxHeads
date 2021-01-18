using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{
    static public PlayerControl PlayerControl;
    static public float zdravi;
    public static float zdravi_max = 100f;
    float poskozeni;
    static public bool mrtev;


    // Use this for initialization
    void Start()
    {
        setDefaultValues();
        PlayerControl = GetComponent<PlayerControl>();
    }


    void ubratZdravi()
    {
     
        zdravi -= poskozeni;
        hpBar.hpBarSize();
        print(zdravi);
        if (zdravi <= 0 && !mrtev)
        {
            Time.timeScale = 0f;
            umrit();
            
        }
    }

   static public void umrit()
    {
        mrtev = true;
        PlayerControl.playerMovment = false;
      
        XMLload_save.WriteToXml(score.points, Nepritel_ai.stringDiff);
    }


    void OnTriggerEnter(Collider player_zona)  // Pokud se hrac dotkne nepritele spusti se UbratZdravi() v 0,5s intervalu
    {

        if (!mrtev)
        {
            if (player_zona.tag == "nepritel_eazy")
            {
                poskozeni = 20f;
                InvokeRepeating("ubratZdravi",0,0.5f);
               

            }
            if (player_zona.tag == "nepritel_medium")
            {
                poskozeni = 50f;
                InvokeRepeating("ubratZdravi", 0, 0.5f);
            }
            if (player_zona.tag == "nepritel_hard")
            {
                poskozeni = 70f;
                InvokeRepeating("ubratZdravi", 0, 0.5f);
            }
            if (player_zona.tag == "boss")
            {
                poskozeni = 50f;
                InvokeRepeating("ubratZdravi", 0, 0.5f);
            }

          

        }
    }

    void OnTriggerExit(Collider player_zona) // Pokud hrac odejde od nepritele vypne se opakovani funce UbratZdravi()
    { 
        
        if (player_zona.tag == "nepritel_eazy")
        {
            CancelInvoke("ubratZdravi");

        }
        if (player_zona.tag == "nepritel_medium")
        {
            CancelInvoke("ubratZdravi");
        }
        if (player_zona.tag == "nepritel_hard")
        {
            CancelInvoke("ubratZdravi");
        }
        if (player_zona.tag == "boss")
        {
            CancelInvoke("ubratZdravi");
        }
    }
    public static void setDefaultValues()
    {
        mrtev = false;
        zdravi = zdravi_max;
    }


}

