using UnityEngine;
using System.Collections;

public class player_animation : MonoBehaviour {
    static GameObject player;
    static GameObject playerAK;
    public Animation anim;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("custom_player");
        anim = player.GetComponent<Animation>();
        foreach (AnimationState state in anim)
        {
            state.speed = 3F;
        }
    }
  
	// Update is called once per frame
	
    public static void walking()
    {
        if (!health.mrtev)
        {   
            player.GetComponent<Animation>().Play("walking_P");
        }
    }
    public static void stay()
    {
        if (!health.mrtev)
        {
            player.GetComponent<Animation>().Play("stay_P");
           
        }
    }
}
