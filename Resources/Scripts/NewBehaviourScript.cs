using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   private EscurecerTelaScript gameManager;

    void Start()
    {
        // Encontrar o GameManager na cena
        GameObject gameManagerObject = GameObject.Find("GameManage");

        if (gameManagerObject != null)
        {
            // Obter o componente GameManager do objeto encontrado
            gameManager = gameManagerObject.GetComponent<EscurecerTelaScript>();
            gameManager.IniciarEscurecimento(4f,1f);
        }

        if (gameManager == null)
        {
            Debug.LogError("GameManager não encontrado ou componente GameManager ausente no objeto.");
        }
    }

    void Update()
    {
        if (gameManager != null)
        {
            // Aqui você pode chamar a função do GameManager conforme necessário
            
        }
    }
}
