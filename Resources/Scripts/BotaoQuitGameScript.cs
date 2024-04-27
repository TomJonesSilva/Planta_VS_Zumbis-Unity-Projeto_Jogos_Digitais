using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoQuitGameScript : MonoBehaviour
{
  public GameObject quitGame;

    void OnMouseOver()
    {
        // Muda a cor do GameObject para a cor ciano quando o mouse passa por cima
        quitGame.GetComponent<Renderer>().material.color = Color.gray;
        
    }

    void OnMouseExit()
    {
        // Retorna às cores originais dos GameObjects quando o mouse sai de cima deles
        quitGame.GetComponent<Renderer>().material.color = Color.white;
        
    }
    void OnMouseDown()
    {
        
       // Application.Quit();
       //UnityEditor.EditorApplication.isPlaying = false;
       Time.timeScale = 0;
       
     

        
    }
}
