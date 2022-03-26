using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC 
{
    public string name;
    public string defaultSprite;
    public string displayName;

    public Dictionary<string, DialogueObject> dialogueObjects = new Dictionary<string, DialogueObject>();

    public DialogueObject GetDialogueObject(string dialogue)
    {
        if (dialogueObjects.TryGetValue(dialogue,out var value))
        {
            return value;
        }
        return null;
    }

    public void AddDialogue(string dialogue, DialogueObject dialogueObject)
    {
        dialogueObjects.Add(dialogue, dialogueObject);
    }

}
