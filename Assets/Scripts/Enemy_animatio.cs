using UnityEngine;
using System.Collections;

public class Enemy_animatio : MonoBehaviour
{
    void Update()
    {
        enemyWalking();
    }

    void enemyWalking()
    {

        if (!health.mrtev)
        {
            GetComponent<Animation>().Play("chozeni");
        }
        else
        {
            GetComponent<Animation>().Stop("chozeni");
        }

    }



}

