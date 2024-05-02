using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassInstancia : MonoBehaviour
{
    public GameObject prefabGrass;
    private GameObject grass;
    private float currentX = -9.38f, currentY = 2.95f, distanceX, distanceY;
    private bool newLine = true; // "boll" foi corrigido para "bool"

    void Start()
    {
        distanceX = prefabGrass.GetComponent<SpriteRenderer>().bounds.size.x;
        distanceY = prefabGrass.GetComponent<SpriteRenderer>().bounds.size.y;
        for (int i = 0; i < 45; i++)
        {
            if (i % 9 == 0 && i != 0)
            {
                newLine = true;
                currentY = grass.transform.position.y - distanceY; 
            }
            if (newLine)
            {
                newLine = false;
                grass = Instantiate(prefabGrass, new Vector2(-9.38f, currentY), Quaternion.identity) as GameObject; // "instantiate" foi corrigido para "Instantiate" e adicionado um ponto e vírgula
            }
            else
            {
                grass = Instantiate(prefabGrass, new Vector2(currentX, currentY), Quaternion.identity) as GameObject; // "instantiate" foi corrigido para "Instantiate" e adicionado um ponto e vírgula
            }
            currentX = grass.transform.position.x + distanceX;
            grass.transform.SetParent(transform);
        }
    }

   
}
