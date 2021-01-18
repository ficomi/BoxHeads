using UnityEngine;
using System.Collections;

public class Strileni : MonoBehaviour
{
    static float nabojeVzasobniku ;
    static float MaxNabojeVZasobniku = 30f;
    public GameObject kulka_prefab;
    public GameObject kulkaSpawn_prefab;
    public static float naboje = 300f;
    public float RychlostKulky;
    public Texture2D ammo_counter;
    public GUIStyle ammo;
    public GUIStyle reload;
    static bool needToReload;
    Vector2 pos = new Vector2(0, Screen.height - Screen.height / 6 - 20);
    string messange;

    void Start()
    {
        setDefaultValues();
    }
    static public void setDefaultValues() {
        naboje = 300f;
        nabojeVzasobniku = MaxNabojeVZasobniku;
        naboje -= MaxNabojeVZasobniku;
        needToReload = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shot") && !health.mrtev && Time.timeScale == 1)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Reload") && !health.mrtev && Time.timeScale == 1)
        {
            Reload();
        }
        if (naboje <= 0)
        {
            outOfAmmo();
        }



    }

    private void Shoot()
    {

        if (nabojeVzasobniku > 0)
        {
            needToReload = false;
            nabojeVzasobniku--;
            // print(nabojeVzasobniku+" ¤¤ "+naboje);


            GameObject bullet = (GameObject)Instantiate(kulka_prefab, kulkaSpawn_prefab.transform.position + kulkaSpawn_prefab.transform.forward, kulkaSpawn_prefab.transform.rotation); //kulka se spawne ve kulkaSpawn_prefab a vysteri to tychlosti kulky
            bullet.GetComponent<Rigidbody>().AddForce(kulkaSpawn_prefab.transform.forward * RychlostKulky, ForceMode.Impulse);


        }

        else
        {
            messange = "RELOAD!";
            needToReload = true;
        }
    }
    void outOfAmmo()
    {
        messange = "OUT OF AMMO!";
    }


    private void Reload()
    {
        needToReload = false;

        if (naboje > 0 )
        {
            if (naboje + nabojeVzasobniku > MaxNabojeVZasobniku)
            {
                naboje = naboje -(MaxNabojeVZasobniku - nabojeVzasobniku);
                nabojeVzasobniku = MaxNabojeVZasobniku;
            }
            else
            {
                nabojeVzasobniku =nabojeVzasobniku+ naboje;
                naboje = 0;
            }


        }
       
    }


    void OnGUI()
    {

        ammo.fontSize = Screen.width / 90;
        if (!health.mrtev && !Pause_menu.pauza)
        {
            //draw the background:
            if (needToReload)
            {
                reload.fontSize = Screen.width / 50;
                GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), messange, reload);
            }


            GUI.BeginGroup(new Rect(pos.x, pos.y, Screen.width / 4, Screen.height / 6), ammo_counter, ammo); // Pozadi

            GUI.BeginGroup(new Rect(0, 0, Screen.width / 4, Screen.height / 6), nabojeVzasobniku.ToString() + " / " + naboje, ammo); //text score



            GUI.EndGroup();
            GUI.EndGroup();

        }


    }
}
