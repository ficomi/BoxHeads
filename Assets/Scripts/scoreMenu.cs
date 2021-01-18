using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class scoreMenu : MonoBehaviour
{

    
    bool onceField;
    static public bool visibleScore;

    Rect rect = new Rect(Screen.width / 2 - 300, (Screen.height / 2) - 200, 600, 400);
    public GUIStyle Text;
    public GUIStyle background;
    public GUIStyle Button;
    int offset;
    int LenghtScore { get; set; }
    string[] selectedDiff = new string[] { "EAZY", "MEDIUM", "HARD" };
    int[] selectedDiffFiledArray;
    List<int> selectedDiffFiled;
    int diff;

    //void Update()
    //{
    //    
    //}

    private void Start()
    {
        selectedDiffFiled = new List<int>();
        diff = 0;
        diffScoreArray();
        LenghtOfField();
    }

    public void scoreActive() { 
    {
           
            visibleScore = false;
            onceField = true;

           
            if (Input_name.enable)
        {
            Menu_Camera.posunScore();
            visibleScore = true;
                diffScoreArray();
            }
          
        }
    }

    void OnGUI()
    {
        if (visibleScore)
        {
            
            GUI.BeginGroup(rect, background);
            if (XMLload_save.loadXML().GetLength(0) > 0)
            {

                if (onceField)
                {
                    
                    onceField = false;
                }
                GUI.Label(new Rect(150, 20, 300, 20), Input_name.Name, Text);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("<", Button) || Input.GetKeyDown(KeyCode.LeftArrow)) // <- prepinani i pres sipky - funguje to ale hodi to error, tak jsem to radsi zrusil
                {
                    switchDiffMinus();

                }
                GUI.Label(new Rect(150, 60, 300, 20), "GAMES ON " + selectedDiff[diff], Text);
                if (GUILayout.Button(">", Button)|| Input.GetKeyDown(KeyCode.RightArrow))
                {
                    switchDiffPlus();

                }
                if (selectedDiffFiledArray.Length != 0)
                {
                    diffScore();
                }
                else
                {
                    GUI.Label(new Rect(150, 100, 300, 20), "NO GAMES WERE PLAYED ON "+ selectedDiff[diff], Text);
                }

                GUILayout.EndHorizontal();

            }
            else
            {
                GUI.Label(new Rect(150, 20, 300, 20), "NO GAMES PLAYED FOR: "+Input_name.Name, Text);
            }

            GUI.EndGroup();
        }
    }

    private void LenghtOfField()
    {
        
        LenghtScore = XMLload_save.loadXML().GetLength(0);
        onceField = false;
       
    }
    private int getLenghtOfField()
    {

        
        return LenghtScore;
    }
    private void diffScore()
    {
        offset = 100;
        for (int i = selectedDiffFiledArray.Length - 1; i >= 0; i--)
        {

            GUILayout.BeginHorizontal();
            GUI.Label(new Rect(150, offset, 300, 20), selectedDiffFiledArray[i].ToString(), Text);

            GUILayout.EndHorizontal();
            offset += 20;

        }

    }

    private void diffScoreArray()
    {
        
        for (int j = 0; j < getLenghtOfField(); j++)
        {


            if (XMLload_save.loadXML()[j, 0] == selectedDiff[diff])
            {
                Debug.Log(getLenghtOfField());

                selectedDiffFiled.Add(Int32.Parse(XMLload_save.loadXML()[j, 1]));

            }
            else {
                Debug.Log("Nepridalo se do listu");

            }
        }

        selectedDiffFiledArray = selectedDiffFiled.ToArray();
        Array.Sort(selectedDiffFiledArray);
        selectedDiffFiled.Clear();
        //Array.Sort(selectedDiffFiled);


    }

    //void lastGames() {
    //    offset = 80;
    //    GUI.Label(new Rect(150, 20, 300, 20), "LASTGAMES OF PLAYER: " + Input_name.Name, Text);

    //    for (int i = 0; i < LenghtScore; i++)
    //    {

    //        GUILayout.BeginHorizontal();
    //        GUI.Label(new Rect(0, offset, 300, 20), XMLload_save.loadXML()[i, 0], Text);
    //        GUI.Label(new Rect(300, offset, 300, 20), XMLload_save.loadXML()[i, 1], Text);
    //        GUILayout.EndHorizontal();
    //        offset = offset + 20;

    //    }
    //}

    private void switchDiffPlus()
    {
        if (diff < selectedDiff.Length - 1)
        {
            diff++;
            diffScoreArray();

        }
        else
        {
            diff = 0;
            diffScoreArray();
        }
    }
    private void switchDiffMinus()
    {
        if (diff <= 0)
        {
            diff = 2;
            diffScoreArray();
        }
        else
        {
            diff--;
            diffScoreArray();
        }
    }
}
