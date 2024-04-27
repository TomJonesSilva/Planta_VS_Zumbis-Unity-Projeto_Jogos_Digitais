using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SanFlowerScript : MonoBehaviour
{
    public GameObject prefabSun;
    
    void Start()
    {
        InvokeRepeating("InstantiateSun", 5, 20);
    }

  void  InstantiateSun(){
       var temp =  Instantiate(prefabSun, transform.position, Quaternion.identity);
        temp.GetComponent<SunScript> ().newInstance = true;
        
    }
   
}
