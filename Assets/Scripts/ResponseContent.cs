using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
public class ResponseContent
{

	[XmlAttribute("title")]
	public string title;

	[XmlAttribute("next")]
	public string next;

	[XmlAttribute("finished")]
	public bool finished;

	[XmlAttribute("quit")]
	public bool quit;

	[XmlArray("contents")]
	[XmlArrayItem("content")]
	public Content[] contents;
}
