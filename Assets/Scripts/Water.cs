using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {


    void OnTriggerEnter(Collider player) {
        if (player.gameObject.tag == "Player") {
        
            health.umrit();
            Time.timeScale = 0f;
        }
       
    }
}


