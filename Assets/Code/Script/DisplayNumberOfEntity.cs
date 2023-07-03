using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MouseEvent))]
public class DisplayNumberOfEntity : MonoBehaviour
{
    private MouseEvent mouseEvent;
    private GUIStyle style = new GUIStyle();
    void Start()
    {
        mouseEvent = GetComponent<MouseEvent>();
        style.fontSize = 30;
        style.normal.textColor = Color.black;
        style.fontStyle = FontStyle.Bold;
    }

    // Update is called once per frame
    void OnGUI()
    {
        string text = "Number of entities: " + mouseEvent.GetEntities().Count;
        GUI.Label(new Rect(10, 35, 100, 20), text, style);
    }
}
