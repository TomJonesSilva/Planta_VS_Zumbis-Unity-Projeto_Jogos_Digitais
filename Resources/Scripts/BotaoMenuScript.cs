using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoMenuScript : MonoBehaviour
{

  public GameObject menu;

    void OnMouseOver()
    {
        // Muda a cor do GameObject para a cor ciano quando o mouse passa por cima
        menu.GetComponent<Renderer>().material.color = Color.gray;
        
    }

    void OnMouseExit()
    {
        // Retorna às cores originais dos GameObjects quando o mouse sai de cima deles
        menu.GetComponent<Renderer>().material.color = Color.white;
        
    }
    void OnMouseDown()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("Menu");
    }
}
