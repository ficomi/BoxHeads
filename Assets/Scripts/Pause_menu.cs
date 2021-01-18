using UnityEngine;
using System.Collections;

public class Pause_menu : MonoBehaviour
{
    public GUIStyle button_pause;

    static public bool pauza = false;  // ze zacatku neni pauza
    Rect rect = new Rect((Screen.width / 2) - 80, (Screen.height / 2) - 50, 400, 400); // udela GUI obdelnik ktery se vycentruje do stredu obrazovky

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pauza") && Application.loadedLevel != 0)
        { // pokud se zmackne tkacitko pauza a zaroven neni nacten level 0 (Menu) tak se spusti funkce pauza
            pauza = zapnutiPauzy();

        }
    }
    
    void OnGUI()
    {

        GUILayout.BeginArea(rect);

        // vlozi se vytvoreny obdelnik
        if (pauza == true) // pokud je pauza true
        {



            Cursor.visible = true; // je videt cursor
            Cursor.lockState= CursorLockMode.None;
            if (GUILayout.Button("Continue", button_pause)) // vytvori se tlacitko "Unpause"
            {
                pauza = zapnutiPauzy();

            }

            if (GUILayout.Button("Menu", button_pause)) // vytvori se tlaciko "Menu"
            {
                Application.LoadLevel("Menu"); // nacte se level "Menu"
                Time.timeScale = 1f; // Musi se zmenit timeScale z dovodu toho ze pokud zustane 0 tak je i menu pausnuty
            }
            if (GUILayout.Button("Restart", button_pause))
            {
               
                restartScene();
               
            }

        }
        else
        {

            if (Application.loadedLevel != 0)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            Cursor.visible = false; // neni videt cursor
        }

        GUILayout.EndArea(); // konec vnitrniho obdelniku

    }

    void restartScene()
    {

        Strileni.setDefaultValues();
        health.setDefaultValues();
        score.setDefaultValues();
        Nepritel_ai.fillEnemyField();
        spawn_enemy.Pocet = 5;
        Application.LoadLevel(Application.loadedLevel);
        hpBar.hpBarSize();
        Time.timeScale = 1f;
        pauza = false;

    }

    bool zapnutiPauzy()
    {

        if (Time.timeScale == 1 && !health.mrtev) // Jestli je timeScale 1 (nepausnuto) a hrac musi byt na zivu tak se pauzne
        {
            Time.timeScale = 0f;
            return true;
        }
        else if (Time.timeScale == 0 && !health.mrtev) // opak toho nahore
        {  // opak toho nahore
            Time.timeScale = 1f;
            return false;
        }
        else
        {
            Time.timeScale = 0;
            return true;
        }
    }




}
