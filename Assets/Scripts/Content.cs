using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
public class Content 
{
    [XmlAttribute("portrait")]
    public string portrait;
    [XmlAttribute("portrait2")]
    public string portrait2;
    [XmlText]
    public string content;
}
