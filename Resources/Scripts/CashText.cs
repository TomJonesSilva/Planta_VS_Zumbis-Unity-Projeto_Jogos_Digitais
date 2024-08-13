using UnityEngine;

public class CashText : MonoBehaviour
{
    public GUIStyle style;
    public GameObject targetObject; // Objeto alvo cujas coordenadas serão usadas para posicionar o texto
    
    void OnGUI()
    {
        if (targetObject != null)
        {
            // Obter a posição do objeto alvo na tela
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(targetObject.transform.position);

            // Renderizar o texto na mesma posição do objeto alvo
            float textWidth = 50; // Largura fixa do texto
            float textHeight = 100; // Altura fixa do texto

            // Calcular a posição do texto para coincidir com a posição do objeto alvo na tela
            float posX = targetPosition.x - (textWidth / 2); // Centralizar horizontalmente o texto em relação ao objeto alvo
            float posY = Screen.height - targetPosition.y - (textHeight / 2); // Centralizar verticalmente o texto em relação ao objeto alvo

            // Renderizar o texto na tela usando GUI.Label
            GUI.Label(new Rect(posX, posY, textWidth, textHeight), GameManage.cash.ToString(), style);
        }
    }
}
