using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesScript : MonoBehaviour
{
  public GameObject newGame;

    void OnMouseOver()
    {
        // Muda a cor do GameObject para a cor ciano quando o mouse passa por cima
        newGame.GetComponent<Renderer>().material.color = Color.gray;
        
    }

    void OnMouseExit()
    {
        // Retorna às cores originais dos GameObjects quando o mouse sai de cima deles
        newGame.GetComponent<Renderer>().material.color = Color.white;
        
    }
    void OnMouseDown()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("Jogo");
    }
}

