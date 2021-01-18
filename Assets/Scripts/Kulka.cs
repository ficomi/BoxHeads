using UnityEngine;
using System.Collections;

public class Kulka : MonoBehaviour
{
    public float zivotkulky;

    static public int dmg_kulka = 30;

    void Update()
    {
        zivotkulky -= Time.deltaTime;
        if (zivotkulky <= 0)
        {
            destroyBullet();
        }
    }

    void OnCollisionEnter(Collision kolize)
    {
        if ((kolize.gameObject.tag == Nepritel_ai.zjistiObtiznost()))
        {
            Nepritel_ai.Hit(kolize.gameObject.name /*, kolize.gameObject*/);
            destroyBullet();
        }
    }

    void destroyBullet()
    {
        Destroy(gameObject);
    }



}
