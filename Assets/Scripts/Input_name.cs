using UnityEngine;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

public class Input_name : MonoBehaviour
{
    public static string Name;
    Rect rect = new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 35, 400, 800);
    Rect rect2 = new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 55, 200, 400);
    public GUIStyle Text_input;
    public GUIStyle Button_char;
    public GUIStyle LabelPlayer;
    public GUIStyle RectFill;
    bool visible;
    static public bool enable;
    // Use this for initialization
    void Start()
    {
        Name = "";
        DirExistance();
        getNameOfPlayer();
    }


    void DirExistance()
    {
        if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/BoxHeads/save") /*|| Directory.GetFiles(@System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/BoxHeads/save/", "*.xml") != null*/)
        {
            visible = false;
            enable = true;

        }
        else
        {
            visible = true;
            enable = false;
        }
    }

    public static string getNameOfPlayer()
    {
        if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/BoxHeads/save"))
        {
            string[] Names = Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/BoxHeads/save/", "*.xml");
            Name = Path.GetFileName(Names[0]).Split('.')[0];
            return Name;

        }
        return null;
    }

    void OnGUI()
    {
        if (visible)
        {
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "", RectFill);
            GUILayout.BeginArea(rect);
           
            GUI.Label(new Rect(0, 0, 300, 20), "Player name", LabelPlayer);
            Name = GUI.TextField(new Rect(0, 20, 300, 70), Name, 25, Text_input);
            GUILayout.EndArea();
            GUILayout.BeginArea(rect2);
            if (GUILayout.Button("ok", Button_char))
            {
                if (Name != "")
                {
                    visible = false;
                    enable = true;
                    XMLload_save.newXML(Name);
                }
            }
            GUILayout.EndArea();

        }
    }
}
