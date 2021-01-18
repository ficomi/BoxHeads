using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public float movementspeed = 2.0f;
    public float vyskaskoku = 20f;
    float verticalrychlost = 0f;
    public float rychlostSprintu = 10f;
    public float skoky = 0f;
    public GameObject model_postavy;
    public bool playerMovment = true;
    CharacterController kontrolaHrace;
    float playerFspeed;
    float playerRLspeed;
    public Transform playergraphic;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // zamkne kurzor mysi
        kontrolaHrace = GetComponent<CharacterController>();// zepta se na CC -> kontrola hrace JEN JEDNOU

    }
    // Update is called once per frame
    void Update()
    {
        if (playerMovment)
        {

            playerFspeed = Input.GetAxis("Vertical") * movementspeed;
            playerRLspeed = Input.GetAxis("Horizontal") * movementspeed;
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                player_animation.walking();
            }
            else { player_animation.stay(); }
        }
        else
        {
            playerFspeed = 0;
            playerRLspeed = 0;
        }
        Vector3 speed = new Vector3();
        Vector3 moveDirection = new Vector3(playerRLspeed, 0, playerFspeed);
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            playergraphic.transform.rotation = Quaternion.Slerp(playergraphic.transform.rotation, newRotation, Time.deltaTime * 8);
        }
        speed = new Vector3(playerRLspeed, verticalrychlost, playerFspeed);
        verticalrychlost += Physics.gravity.y * Time.deltaTime;// normalni gravitace 9.81 za sekundu
        speed = transform.rotation * speed; // gravitace a vektor chuze se daji dohromady
        kontrolaHrace.Move(speed * Time.deltaTime); // chuze se prevede do kontroly hrace ALE POZOR ZA SEKUNDU NE ZA 1 FPS
    }



}
