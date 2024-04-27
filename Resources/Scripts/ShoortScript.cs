using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoortScript : MonoBehaviour
{
    public float vel, dano;
    public bool icePea;
    public AudioClip clip;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     Destroy(gameObject,3.09f);  
    }

   
    void FixedUpdate(){
        rb.velocity = new Vector2(vel * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("Zombie")){
            if(icePea){
                col.gameObject.GetComponent<ZombiesScript>().WalkSlow();
            }
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position);
            col.gameObject.GetComponent<ZombiesScript>().life -= dano;
            Destroy(gameObject);
        }
    }
}
