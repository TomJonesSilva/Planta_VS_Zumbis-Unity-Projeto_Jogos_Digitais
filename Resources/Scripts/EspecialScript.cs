using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspecialScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public int price = 2000;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,1f);
        
    }

   void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("Zombie")){
            
            col.gameObject.GetComponent<ZombiesScript>().life -= 40f;
            
        }else if(col.CompareTag("Plants")){
            Destroy(gameObject);
        }
    }
}
