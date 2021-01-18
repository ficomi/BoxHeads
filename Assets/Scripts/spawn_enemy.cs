using UnityEngine;
using System.Collections;


public class spawn_enemy : MonoBehaviour
{

    public GameObject prefab;
    public GameObject[] Spawn;
    public GameObject[] Enemy;
    static public int Pocet;
    static public float floatPocet;
    int offset;

    int randSpawn;

    void Update() {
        areTheyAllDead();
    }


    void spawnEnemy()
    {
        for (int i = 0; i < Pocet; i++)
        {
            offset = Random.Range(0, 8);// jak daleko se spawnou od spawnu
            randSpawn = (int)Random.Range(0, Spawn.Length);
            prefab.name = "Nepritel." + i+".";
            Spawn = GameObject.FindGameObjectsWithTag("spawn_enemy");
           // print(randSpawn + " " + Spawn.Length);
            Vector3 pos = new Vector3(Spawn[randSpawn].transform.position.x + offset, Spawn[randSpawn].transform.position.y, Spawn[randSpawn].transform.position.z + offset); // urcuje pozici
            Instantiate(prefab, pos, Quaternion.identity); // vytvori objekt "nepritel" na pozici pos 
        }
    }

    void areTheyAllDead() {
        Enemy = GameObject.FindGameObjectsWithTag(Nepritel_ai.zjistiObtiznost());
       
        if (Enemy.Length == 0) {
           floatPocet = Pocet * Nepritel_ai.multiplier;
            round();
            Nepritel_ai.fillEnemyField();
            Nepritel_ai.reviveEnemy();
            spawnEnemy();
           
        }
    }
    public static void round() {
       Pocet = (int)System.Math.Round(floatPocet, 0);

    }
    public static void setDefaultValues()
    {
        Pocet = 5;
    }
    }
