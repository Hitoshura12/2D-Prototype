using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject 
{
    public Dialogue dialogue;

    public NPC npc;

    public DialogueObject(Dialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    public Text GetText()
    {
        return GetText("Test0");
    }
    public Text GetText(string textName)
    {
        Text[] texts = dialogue.texts;
        foreach (Text text in texts)
        {
            if (text.name.Equals(textName))
            {
                return text;
            }
        }
        return null;
    }
    public Response GetResponse(string responseName)
    {
        Response[] responses = dialogue.responses;
        foreach (Response response in responses)
        {
            if (response.name.Equals(responseName))
            {
                return response;
            }
        }
   
        return null;
    }
}
