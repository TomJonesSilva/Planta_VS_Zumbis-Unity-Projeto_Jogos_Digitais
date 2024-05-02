using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
   //public AudioClip clip;
   public GameObject prefabSun;
   public Transform pointSun;
   public static int cash;
   public static bool shovelEnabled;
   public static GameObject currentPlant, currentSeed;
    void Start()
    {
        InvokeRepeating("InstantiateSun", 10, 20);
        cash = 2000;
        shovelEnabled = false;
     //   AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position);
    }

   void Update(){
        if(cash >= 9999)
        cash = 9999;
   }     
   void InstantiateSun(){
        Instantiate(prefabSun, pointSun.position, Quaternion.identity);
   }  
}
