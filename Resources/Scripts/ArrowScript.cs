using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public AudioSource sound;
   void OnMouseDown(){
    if(GameManage.currentPlant != null || GameManage.shovelEnabled){
        sound.Play();
        GameManage.currentPlant = null;
        GameManage.currentSeed = null;
        GameManage.shovelEnabled = false;
    }
   }
}
