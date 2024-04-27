using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScripts : MonoBehaviour
{
 private bool isEmpty;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, LayerMask.GetMask("Plants"));
        isEmpty = hit.collider == null;
    }
    void OnMouseDown(){
        if(isEmpty && GameManage.currentPlant != null){
            Instantiate(GameManage.currentPlant, transform.position, Quaternion.identity);
            GameManage.cash -= GameManage.currentPlant.GetComponent<Properties>().price;
            GameManage.currentPlant = null;
            GameManage.currentSeed.GetComponent<SeedScript>().StartRecharge();
        }
    }
}
