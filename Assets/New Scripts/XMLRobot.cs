using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot("Robo")]
public class XMLRobot
{   
    public string name0, name1;

    public float rotationGrab0, rotationGrab1;

    public float rotationDrop0, rotationDrop1;

}
