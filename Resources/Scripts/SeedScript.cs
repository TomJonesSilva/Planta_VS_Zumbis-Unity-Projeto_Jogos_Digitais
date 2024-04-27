using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour
{
    public GameObject prefabPlant;
    private GameObject preFabSprite;
    public AudioSource[] sounds;
    private bool canPlant = true;
  
    void OnMouseDown(){
        var spr = Resources.Load ("Prefabs/Sprite", typeof(GameObject)) as GameObject;

        if(canPlant && !GameManage.shovelEnabled && GameManage.currentPlant == null 
        && GameManage.cash >= prefabPlant.GetComponent <Properties>().price){

            sounds[0].Play();
            preFabSprite = Instantiate(spr, transform.position, Quaternion.identity) as GameObject;
            GameManage.currentSeed = gameObject;
            GameManage.currentPlant = prefabPlant;

        }else if(!canPlant || GameManage.cash < prefabPlant.GetComponent<Properties>().price){
            sounds[1].Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!canPlant || GameManage.cash < prefabPlant.GetComponent<Properties> ().price )
            GetComponent<SpriteRenderer> ().material.color = Color.gray;
        else
            GetComponent<SpriteRenderer> ().material.color = Color.white;
        
    }

public void StartRecharge (){
    canPlant = false;
    Destroy (preFabSprite);
    GameManage.currentSeed = null;
    StartCoroutine ("WaitTime");
}


    IEnumerator WaitTime(){
        yield return new WaitForSeconds(prefabPlant.GetComponent<Properties>().timeRecharge);
        canPlant = true;
    }
}
