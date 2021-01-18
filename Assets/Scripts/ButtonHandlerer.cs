using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
public class ButtonHandlerer : MonoBehaviour
{
    List<Button> buttons = new List<Button>();
    Button classButton;
    public GameObject button;
    public string butName;
    bool active = true;

    scoreMenu scoreMenu = new scoreMenu();


    private void Update()
    {

        //    if (findButtonClassByName("start")) { findButtonClassByName("start").setActive(true); }
        //    if (findButtonClassByName("score")) { findButtonClassByName("score").setActive(true); }
        //    if (findButtonClassByName("exit")) { findButtonClassByName("exit").setActive(true); }
        //Debug.Log(buttons.Count);
    }



    //void Start()
    //{
    //    addButton();
      
    //}

    void OnMouseUpAsButton()
    {
        if (butName == "start")
        {
            Menu_Camera.posunStart();
            //findButtonClassByName("eazy").setActive(true);
            //findButtonClassByName("medium").setActive(true);
            //findButtonClassByName("hard").setActive(true);
        }
        if (butName == "exit") { Application.Quit(); }
        if (butName == "score") { scoreMenu.scoreActive(); }
        if (butName == "eazy")
        {
            Nepritel_ai.difficulty = 1;
            Menu_Camera.posunChar();
            //findButtonClassByName("charNext").setActive(true);
            //findButtonClassByName("charPrevious").setActive(true);
        }
        if (butName == "medium")
        {
            Nepritel_ai.difficulty = 2;
            Menu_Camera.posunChar();
            //findButtonClassByName("charNext").setActive(true);
            //findButtonClassByName("charPrevious").setActive(true);
        }
        if (butName == "hard")
        {
            Nepritel_ai.difficulty = 3;
            Menu_Camera.posunChar();
            //findButtonClassByName("charNext").setActive(true);
            //findButtonClassByName("charPrevious").setActive(true);
        }
        if (butName == "next") { Menu_Camera.posunLevel(); }
        if (butName == "charNext")
        {
            Char_colour.Colour++;
            Char_colour.changeColour();
        }
        if (butName == "charPrevious")
        {
            Char_colour.Colour--;
            Char_colour.changeColour();
        }
        if (butName == "lvl1")
        {
            //Button.loadLevel("testscene1");
        }
        if (butName == "lvl2")
        {
            Button.loadLevel("lvl2");
        }

    }

    void OnMouseEnter()
    {
        changeColour(findChangingButton(button, "buttonChangeColour"));
    }

    void OnMouseExit()
    {
        changeColour(findChangingButton(button, "buttonChangeColour"));
    }

    //void addButton()
    //{
    //    buttons.Add(new Button() { GameObjectButton=button, buttonName=butName, buttonActive=active });
    //}
    //int countButtons()
    //{
    //    return Button.count;
    //}
    //Button findButtonClassByName(String name)
    //{
    //    return buttons.Find(x => x.buttonName == name);
    //}

    GameObject findChangingButton(GameObject parentButton, string tagName)
    {
        foreach (Transform a in parentButton.transform)
        {
            if (a.tag == tagName)
            {
                return a.gameObject;
            }
        }
        return null;
    }
    public void changeColour(GameObject button)
    {
        if (Input_name.enable)
        {
            if (button.GetComponent<Renderer>() == true)
            {
                if (button.GetComponent<Renderer>().material.color == Color.gray)
                {
                    button.GetComponent<Renderer>().material.color = Color.white;

                }
                else
                {
                    button.GetComponent<Renderer>().material.color = Color.gray;

                }
            }

        }
    }
    // void WriteToConsole<T>(this IList<T> collection)
    //{
    //    int count = collection.Count();
    //    for (int i = 0; i < count; ++i)
    //    {
    //        Console.Write("{0}\t", collection[i].ToString(), "/n");
    //    }
    //    Console.WriteLine();
    //}
}

