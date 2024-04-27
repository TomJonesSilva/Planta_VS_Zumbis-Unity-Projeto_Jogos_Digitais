using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour
{
    public AudioSource[] sound;
   void OnMouseDown(){
    if(GameManage.currentPlant == null && !GameManage.shovelEnabled){
        GameManage.shovelEnabled = true;
        sound[0].Play();
        Instantiate(Resources.Load("Prefabs/Sprite", typeof(GameObject)) as GameObject,
        transform.position, Quaternion.identity);
    }
   }
}
