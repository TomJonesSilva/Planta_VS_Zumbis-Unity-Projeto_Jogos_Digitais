using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
   public int life, price, timeRecharge;
   private AudioClip sound,sound1;

   void Start(){
    sound = Resources.Load("Audios/Plant", typeof(AudioClip)) as AudioClip;
   }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        CheckMouse();
    }
 
    void CheckDeath(){
        if(life <=0)
            Destroy (gameObject);
    }

       void CheckMouse (){
       if (GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            OnMouseDown();
       }
       void OnMouseDown(){
        if(GameManage.shovelEnabled && Input.GetMouseButtonDown (0)){
            GameManage.shovelEnabled = false;
            AudioSource.PlayClipAtPoint (sound, Camera.main.transform.position);
            int refundAmount = price / 2;
            GameManage.cash += refundAmount;
            Destroy(gameObject);
         }
        }
       
}
