using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
 
[XmlRoot("dialogue")]
public class Dialog
{
    [XmlElement("node")]
    public Node[] nodes;
 
    public static Dialog Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer (typeof(Dialog));
        StringReader reader = new StringReader (_xml.text);
        Dialog dial = serializer.Deserialize (reader) as Dialog;
        return dial;
    }
}
 
[System.Serializable]
public class Node
{
    [XmlAttribute("delay")]
    public int delay;
    [XmlElement("npctext")]
    public string NpcText;
    [XmlAttribute("numNode")]
    public int numNode;
 
    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}
 
[System.Serializable]
public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlElement("text")]
    public string text;
    [XmlElement("dialend")]
    public string end;
}
