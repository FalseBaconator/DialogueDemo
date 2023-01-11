using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCScripts : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text text;
    public Image image;
    public Dialogue[] conversation;
    public int currentDialogue = 0;
    public bool inConvo = false;
    //public bool inChoice = false;

    public void startConvo()
    {
        inConvo = true;
        currentDialogue = 0;
        panel.SetActive(true);
        text.text = conversation[currentDialogue].text;
        image.sprite = conversation[currentDialogue].pic;
    }

    private void Update()
    {
        if (inConvo && Input.GetButtonDown("Submit"))
        {
            if(currentDialogue+1 < conversation.Length)
            {
                currentDialogue += 1;
                text.text = conversation[currentDialogue].text;
                image.sprite = conversation[currentDialogue].pic;
            }
            else
            {
                currentDialogue += 1;
                inConvo = false;
                panel.SetActive(false);
            }
        }
    }

}
