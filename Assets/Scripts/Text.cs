using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;


public class Text 
{
    [XmlAttribute("name")]
    public string name;
    [XmlAttribute("response")]
    public string response;
    [XmlAttribute("finished")]
    public bool finished;
    [XmlArray("contents")]
    [XmlArrayItem("content")]
    public Content[] content;
}
