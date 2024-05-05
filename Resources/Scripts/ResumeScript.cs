using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
{
    public GameObject resume;
    private PausarGameScript pausarGame;

    void Start(){
         GameObject gameManagerObject = GameObject.Find("GameManage");
        pausarGame = gameManagerObject.GetComponent<PausarGameScript>();
        
    }
   void OnMouseOver()
    {
        // Muda a cor do GameObject para a cor ciano quando o mouse passa por cima
        resume.GetComponent<Renderer>().material.color = Color.gray;
        
    }

    void OnMouseExit()
    {
        // Retorna às cores originais dos GameObjects quando o mouse sai de cima deles
        resume.GetComponent<Renderer>().material.color = Color.white;
        
    }
    void OnMouseDown()
    {
        // Carrega a cena do jogo
        pausarGame.ResumeGame();
        
    }
}
