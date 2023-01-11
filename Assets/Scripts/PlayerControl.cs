using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public float InteractRange;
    public bool CanMove = true;
    public GameObject talkingNPC;



    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Time.deltaTime * speed);

            if (Input.GetButtonDown("Submit"))
            {
                foreach (GameObject NPC in GameObject.FindGameObjectsWithTag("NPC"))
                {
                    if (Vector2.Distance(NPC.transform.position, gameObject.transform.position) <= InteractRange)
                    {
                        CanMove = false;
                        NPC.GetComponent<NPCScripts>().startConvo();
                        talkingNPC = NPC;
                    }
                }
            }
        }
        else
        {
            if(talkingNPC.GetComponent<NPCScripts>().currentDialogue >= talkingNPC.GetComponent<NPCScripts>().conversation.Length)
            {
                CanMove = true;
            }
        }

        

    }





}
