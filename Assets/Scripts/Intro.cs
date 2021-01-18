using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
    //AudioClip IntroClip;
	// Use this for initialization
	void Start () {
        XMLload_save.loadXML();
        //XMLload_save.newXML();
    }
	
	// Update is called once per frame
	void Update () {
      
	}
    void loadIntro() {
        if (Resources.Load("Video/Intro/tp", typeof(AudioClip)) as AudioClip != null)
        {
            //IntroClip = Resources.Load("Video/Intro/tp", typeof(AudioClip)) as AudioClip;
        }
        else {
            print("Nemuzu nacist Klip");
        }

    }
}
