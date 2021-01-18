using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour
{
    public float ammoAdd;

    void OnTriggerEnter(Collider kolizeAmmo)
    {
        if (kolizeAmmo.gameObject.tag == "Player")
        {
            RefillAmmo();

        }


    }

    void RefillAmmo()
    {

        Strileni.naboje += ammoAdd;
        DestroyAmmoBox();

    }

    void DestroyAmmoBox()
    {

        Destroy(gameObject);

    }
}
