using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueProvider : MonoBehaviour
{
    public static DialogueProvider Instance;
    public static Dialogue dialogue;
    public Text[] texts;

    private void Start()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadDialogues();
        //Dialogue.WriteDialogue(dialogue);
       
    }

    public static DialogueObject LoadDialogues()
    {
        dialogue = Dialogue.LoadDialogue(Resources.Load<TextAsset>("Dialogues/Dialogue").text);
        DialogueObject dialoguesList = new DialogueObject(dialogue);
       
        dialoguesList.dialogue.name = dialogue.name ;
        dialoguesList.dialogue.texts = dialogue.texts;
        return dialoguesList;
    }
}
