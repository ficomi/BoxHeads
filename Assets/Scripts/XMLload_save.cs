using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

public class XMLload_save : MonoBehaviour
{
 
    

    static string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/BoxHeads/save/"+Input_name.getNameOfPlayer()+".xml";
    // Update is called once per frame

    static public void WriteToXml(int score, string diff)
    {
        if (File.Exists(path))
        {
            XmlDocument root = new XmlDocument();
            root.Load(path);
            // StreamWriter writer = new StreamWriter(path);
            XmlElement elmRoot = root.DocumentElement;

            XmlElement elmNew = root.CreateElement("Player_score"); // vytvori node s nazvem <<

            XmlElement difficultyE = root.CreateElement("difficulty");
            difficultyE.InnerText = diff;


            XmlElement scoreE = root.CreateElement("score"); // create the x node. 
            scoreE.InnerText = score.ToString(); // apply to the node text the values of the variable. 


            elmNew.AppendChild(difficultyE);
            elmNew.AppendChild(scoreE);
            elmRoot.AppendChild(elmNew);

            root.Save(path);
        }
        else
        {
            print("nelze ulozit do XML souboru:" + path + " pokud neexistuje");
        }
    }

    public static void newXML(string name)
    {

        if (!File.Exists(path))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/BoxHeads/save");
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            doc.Add(new XElement("game"));
            doc.Save(path);
        }

    }
   
    public static string[,] loadXML()
    {
   
        XmlDocument root = new XmlDocument();
        using (StreamReader reader = new StreamReader(path))
        {
            root.LoadXml(reader.ReadToEnd());
            root.Load(path);
            var PlayerNode = root.LastChild;
           
                var cnodeCount = PlayerNode.ChildNodes.Count;
                
                string[,] scoreField = new string[cnodeCount, 2];
                for (int i = 0; i < cnodeCount; i++)
                {
                    var dataNode = PlayerNode.ChildNodes.Item(i);
                    var childrenCount = dataNode.ChildNodes.Count;
                    for (int j = 0; j < childrenCount; j++)
                    {
                        if (dataNode.ChildNodes.Item(j).Name == "difficulty")
                        {
                           scoreField[i,0] = dataNode.ChildNodes.Item(j).InnerText;
                        }

                        else if (dataNode.ChildNodes.Item(j).Name == "score")
                        {
                            scoreField[i,1] = dataNode.ChildNodes.Item(j).InnerText;
                        }

                    }
                   
                }
            if (scoreField != null || scoreField.GetLength(0)>0)
            {
               
                return scoreField;
            }
            else {
              
                return null;
                
                }   
            }
        
    }
}
