using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashText : MonoBehaviour
{
    public GUIStyle style;
    public Vector2 normalizedPosition = new Vector2(0.162f, 0f); // Posição normalizada na tela

    void OnGUI()
    {
        Vector2 position = new Vector2(normalizedPosition.x * Screen.width, normalizedPosition.y * Screen.height);
        GUI.Label(new Rect(position.x, position.y, 50, 100), GameManage.cash.ToString(), style);
    }
}
