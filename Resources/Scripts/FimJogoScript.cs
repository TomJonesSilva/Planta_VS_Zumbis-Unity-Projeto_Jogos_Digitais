using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimJogoScript : MonoBehaviour
{
    public AudioClip clip;
  void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("Zombie")){
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position);
            Invoke("FimGame",10f);
        }
    }
    void FimGame(){
        SceneManager.LoadScene("GameOver");
    }
}
