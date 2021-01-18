using UnityEngine;
using System.Collections;

public class Menu_Camera : MonoBehaviour
{
    static GameObject Kamera;
    static Vector3 start;
    static float step;
    static GameObject Target1;
    static GameObject Target2;
    static GameObject Target3;
    static GameObject Target4;
    static bool pohyb1;
    static bool pohyb2;
    static bool pohyb3;
    static bool pohyb4;
    // Use this for initialization
    void Start()
    {
        if (Application.loadedLevel == 0)
        {
            Time.timeScale = 1f;
        }
        Cursor.visible = true;
        //pos_diff = new Vector3((float)13.48448, (float)0.8070219, (float)10.70237);
        pohyb1 = false;
        pohyb2 = false;
        pohyb3 = false;
        pohyb4 = false;
        Kamera = GameObject.FindWithTag("MainCamera");
        Target1 = GameObject.FindWithTag("Target_Camera1");
        Target2 = GameObject.FindWithTag("Target_Camera2");
        Target3 = GameObject.FindWithTag("Target_Camera3");
        Target4 = GameObject.FindWithTag("Target_Camera4");
        start = Kamera.transform.position;
    }


    void Update()
    {
        Posun();
        PosunZpet();
       // print(pohyb1+ " " +pohyb2+ " " + pohyb3+ " " +pohyb4+" "+step);
        //defaultStep();
    }
    public static void posunStart()
    {
        pohyb1 = true;
        defaultStep();
    }

    public static void posunChar()
    {
        pohyb2 = true;
        defaultStep();
    }

    public static void posunLevel()
    {
        pohyb3 = true;
        defaultStep();
    }
    public static void posunScore() {
        pohyb4 = true;
        defaultStep();
    }

    void Posun()
    {
        if (pohyb1)
        {
            step += Time.deltaTime;
            Kamera.transform.position = Vector3.MoveTowards(start, Target1.transform.position, step *20);
            ////Kamera.transform.position = Vector3.MoveTowards(Target1.transform.position, start, step * 20);

        }
        if (pohyb2)
        {
            step += Time.deltaTime;
            Kamera.transform.position = Vector3.MoveTowards(Target1.transform.position, Target2.transform.position, step * 20);

        }
        if (pohyb3)
        {
            step += Time.deltaTime;
            Kamera.transform.position = Vector3.MoveTowards(Target2.transform.position, Target3.transform.position, step * 20);

        }
        if (pohyb4)
        {
            step += Time.deltaTime;
            Kamera.transform.position = Vector3.MoveTowards(start, Target4.transform.position, step * 20);
        }
    }

    void PosunZpet()
    {
        if (Input.GetButtonDown("pauza")/*&& pohyb1*/)
        {


            if (Kamera.transform.position == Target1.transform.position)
            {
                pohyb1 = false;
                step += Time.deltaTime;
                Kamera.transform.position = Vector3.MoveTowards(Target1.transform.position, start, step * 20);
            }
            if (Kamera.transform.position == Target2.transform.position)
            {
                pohyb2 = false;
                step += Time.deltaTime;
                Kamera.transform.position = Vector3.MoveTowards(Target2.transform.position, Target1.transform.position, step * 20);
            }
            if (Kamera.transform.position == Target3.transform.position)
            {
                pohyb3 = false;
                step += Time.deltaTime;
                Kamera.transform.position = Vector3.MoveTowards(Target3.transform.position, Target2.transform.position, step * 20);
            }
            if (Kamera.transform.position == Target4.transform.position)
            {
                pohyb4 = false;
                step += Time.deltaTime;
                Kamera.transform.position = Vector3.MoveTowards(Target4.transform.position, start, step * 20);
                scoreMenu.visibleScore = false;
            }
            
        }
    }
    static void defaultStep()
    {
        //if (Vector3.MoveTowards(start, Target4.transform.position, step * 20) == new Vector3(0, 0, 0) || Vector3.MoveTowards(Target2.transform.position, Target3.transform.position, step * 20) == new Vector3(0, 0, 0) || (Vector3.MoveTowards(Target1.transform.position, Target2.transform.position, step * 20) == new Vector3(0, 0, 0) || Vector3.MoveTowards(Target1.transform.position, start, step * 20) == new Vector3(0, 0, 0)) {
        //    step = 0;
        //}

        if (Kamera.transform.position == Target1.transform.position || Kamera.transform.position == start || Kamera.transform.position == Target2.transform.position || Kamera.transform.position == Target3.transform.position || Kamera.transform.position == Target4.transform.position)
        {
            step = 0;
        }
        //else {
        //    step = 0;
        //}



    }

}


