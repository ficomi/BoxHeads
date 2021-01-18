using UnityEngine;
using System.Collections;

public class Medkit : MonoBehaviour
{
    public float HealAmount;
    public GameObject MedKit;
    // Use this for initialization

    // Update is called once per frame
  
    void OnTriggerEnter(Collider kolizeMedkit)
    {
        if (kolizeMedkit.gameObject.tag == "Player")
        {
            Heal();

        }



    }

    void Heal()
    {
        if (health.zdravi_max == health.zdravi) {

        }
        else if (health.zdravi_max - health.zdravi > HealAmount)
        {
            health.zdravi += HealAmount;
            destroyMedkit();
            hpBar.hpBarSize();
        }
        else
        {
            HealAmount = health.zdravi_max - health.zdravi;
            health.zdravi += HealAmount;
            destroyMedkit();
            hpBar.hpBarSize();
        }

    }

    void destroyMedkit()
    {
        Destroy(gameObject);

    }


}

