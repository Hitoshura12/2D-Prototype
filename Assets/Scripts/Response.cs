using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
public class Response
{
    [XmlAttribute]
    public string name;

    [XmlArray("responseContents")]
    [XmlArrayItem("responseContent")]
    public ResponseContent[] responseContent;
}
