using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message2 : MonoBehaviour
{
    public static bool displayText = false;
    public float textX;
    public float textY;
    public float textWidth;
    public float textHeight;
    public GUIStyle style;

    public static int messageCount = 0;
    public string message;


    void OnGUI()
    {
        if (displayText)
        {
            GUI.Box(new Rect(textX, textY, textWidth, textHeight), message, style);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        displayText = true;
    }

    private void OnTriggerExit(Collider other)
    {
        displayText = false;
    }
}
