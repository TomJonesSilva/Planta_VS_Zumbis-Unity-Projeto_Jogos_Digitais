using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterScript : MonoBehaviour
{
    public GameObject prefabPea;
    private float distance;
    void Start()
    {
        InvokeRepeating("Shoot",0 , 2);
        distance = 11.0f - transform.position.x;
           
    }

    void Shoot(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance, LayerMask.GetMask("zombies"));
        if(hit.collider != null){
            Instantiate(prefabPea, transform.position, Quaternion.identity);
        }
    }
   
}
