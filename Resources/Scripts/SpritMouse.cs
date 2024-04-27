using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManage.currentPlant == null)
            GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/General/Shovel", typeof(Sprite)) as Sprite;
        else
            GetComponent<SpriteRenderer>().sprite = GameManage.currentPlant.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseP = Input.mousePosition;
        mouseP.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint (mouseP);

        if(GameManage.currentPlant == null && !GameManage.shovelEnabled)
            Destroy (gameObject);
    }



}
