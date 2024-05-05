using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarGameScript : MonoBehaviour
{
  private bool isPaused = false;
  public GameObject huds;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Se pressionar a tecla P
        {
            TogglePause(); // Chama a função para alternar a pausa
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused; // Inverte o estado de pausa

        if (isPaused)
        {
            PauseGame(); // Pausa o jogo
            
        }
        else
        {
            ResumeGame(); // Retoma o jogo
            
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0; // Pausa o jogo
        huds.SetActive(false);

    }

   public void ResumeGame()
    {
        Time.timeScale = 1; // Retoma o jogo
        huds.SetActive(true);
    }
}
