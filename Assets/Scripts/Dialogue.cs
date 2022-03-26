using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue 
{
    [XmlAttribute("name")]
    public string name;

    [XmlArray("texts")]
    [XmlArrayItem("text")]
    public Text[] texts;

    [XmlArray("responses")]
    [XmlArrayItem("response")]
    public Response[] responses;

    [XmlAttribute("portrait")]
    public string portrait;
    [XmlAttribute("portrait2")]
    public string portrait2;
    
    public static Dialogue LoadDialogue(string text)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dialogue));
        using (TextReader textReader = new StringReader(text))
        {
            return xmlSerializer.Deserialize(textReader) as Dialogue;
        }
    }

    public static void WriteDialogue(Dialogue dialogue)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dialogue));
        StreamWriter streamWriter = new StreamWriter("Assets/Resources/Dialogues/Dialogue");
        xmlSerializer.Serialize(streamWriter.BaseStream,dialogue);
        streamWriter.Close();
    }
}
