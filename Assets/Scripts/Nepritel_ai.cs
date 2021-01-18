using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Text.RegularExpressions;

public class Nepritel_ai : MonoBehaviour
{

    CharacterController nepritel;

    
    static public float difficulty { get; set; }
    public float chanceMedkit;
    public float chanceAmmoBox;
    int ChanceAmmo;
    static public string diff;
    static public string stringDiff;
    static public GameObject Nepritel;
    public NavMeshAgent Agent;
    GameObject Player;
    public static GameObject Enemy;
    public GameObject MedKit;
    public GameObject AmmoBox;
   
    static string num_enemy;
    static public float multiplier { get; set; }
    static int NumOfEnemy;
    static int startZdraviAI;
    static public int[,] enemy = new int[spawn_enemy.Pocet, 2]; // vytvoreni 2d pole 1.sloupec HPcka druhy jestli je mrtev
    Vector3 speed;
    Vector3 UCil; // promena ktera se prepocita na souradnice x a z hrace
    Vector3 posEnemy;
    float gravity;
  

    void Start()
    {
        //print(enemy[1][0]);
        nepritel = GetComponent<CharacterController>();
        assignValues();
        testDifff();
       

    }
    static public void fillEnemyField() {
        enemy = new int[spawn_enemy.Pocet, 2];


    }

    

    void Update()
    {
        followTarget();
        isEnemyDead();
        
    }

    void changeTag()
    {
        Nepritel.tag = zjistiObtiznost();
    }

    static public string zjistiObtiznost()
    {


        if (difficulty == 1)
        {
            stringDiff = "EAZY";
            diff = "nepritel_eazy";
            startZdraviAI = 100;
           
            multiplier = 1.2f;

        }
        if (difficulty == 2)
        {
            stringDiff = "MEDIUM";
            diff = "nepritel_medium";
            startZdraviAI = 150;
           
            multiplier = 1.35f;
        }
        if (difficulty == 3)
        {
            stringDiff = "HARD";
            diff = "nepritel_hard";
            startZdraviAI = 200;
         
            multiplier = 1.50f;
        }
        return diff;

    }

    static public void Hit(string nameOfCollision/*,GameObject EnemyHitted*/)
    {
        //Enemy = EnemyHitted;
        
        num_enemy = Regex.Split(nameOfCollision,@"\.")[1]; 
        NumOfEnemy = System.Int32.Parse(num_enemy);
        enemy[NumOfEnemy, 0] -= Kulka.dmg_kulka; // z pole ktere pripada nepritelovy ubere hp


        print(enemy[NumOfEnemy, 0] + "  HP " + nameOfCollision + "  " + enemy[NumOfEnemy, 1]);
    }

    void killEnemy()
    {
        Enemy = GameObject.Find("Nepritel." + num_enemy + ".(Clone)");
        Destroy(Enemy);
        
        dropMedkit();
        dropAmmoBox();

    }

    void assignValues()
    {
        changeTag();
        for (int i = 0; i <= enemy.GetLength(0) - 1; i++)
        {
            enemy[i, 0] = startZdraviAI; // naplneni poli HPckama
        }
        //print(startZdraviAI+" "+enemy[0]+" "+enemy.Length);
    }

    void followTarget()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
       
        Agent.SetDestination(Player.transform.position);

        //UCil = new Vector3(Player[0].transform.position.x, Player[0].transform.position.y, Player[0].transform.position.z); // souradnice hrace jen x,z
        //gravity += Physics.gravity.y * Time.deltaTime;
        //nepritel.transform.LookAt(UCil); // kouka se na cil
        //speed = new Vector3(nepritel.transform.forward.x * Speed_enemy, gravity, nepritel.transform.forward.z * Speed_enemy/*Player[0].transform.transform.eulerAngles.z*/); //vytvoreni vectoru ktery smeruje na cil
        ////speed = nepritel.transform.forward * Speed_enemy;
        //nepritel.Move(speed * Time.deltaTime); // hni se podle vectoru * vterinu

    }

    void isEnemyDead()
    {


        if (enemy[NumOfEnemy, 0] <= 0 && enemy[NumOfEnemy, 1] == 0)
        {
            killEnemy();
            //print("mrtev");
            score.addScore();
            enemy[NumOfEnemy, 1] = 1;
        }

    }

    static public void reviveEnemy() // resetuje vsem enemy[x,1] = 1 (obzivnou)
    {
        for (int i = 0; i <= enemy.GetLength(0) - 1; i++)
        {
            enemy[i, 1] = 0;

        }
    }

    void dropMedkit()
    {

        if (Random.value < chanceMedkit)
        {
            posEnemy = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y, Enemy.transform.position.z);
            Instantiate(MedKit, posEnemy, Quaternion.identity);
        }
    }

    void dropAmmoBox()
    {

        if (Random.value < chanceAmmoBox)
        {
            posEnemy = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y, Enemy.transform.position.z);
            Instantiate(AmmoBox, posEnemy, Quaternion.identity);
        }
    }

    void testDifff() {
        if(difficulty==0)
        difficulty = 1;

    }


    void OnTriggerEnter(Collider enemyZombie)
    {
        if (enemyZombie.gameObject.tag == "water")
        {
            Destroy(Nepritel);
        }
    }
}
