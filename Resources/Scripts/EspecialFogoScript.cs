using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspecialFogoScript : MonoBehaviour
{
     public GameObject prefabFogo;
     public AudioSource[] sounds;
     
     
    // Start is called before the first frame update

    void OnMouseDown(){

        if(!GameManage.shovelEnabled && GameManage.currentPlant == null 
        && GameManage.cash >= prefabFogo.GetComponent <EspecialScript>().price){
            sounds[0].Play();
            GameManage.cash -= prefabFogo.GetComponent<EspecialScript>().price;
            StartCoroutine(InstanciarFogo());
        }else if(GameManage.cash < prefabFogo.GetComponent<EspecialScript>().price){
            sounds[1].Play();
        }
    }
    IEnumerator  InstanciarFogo()
    {
        // Definir as coordenadas iniciais onde os fogos serão instanciados
        float startX = -9.3f;
        float startY = 3.15f;

        // Número de linhas e colunas desejadas
        int numColumns = 10;
        int numRowsPerColumn = 5;

        // Espaçamento entre as colunas e linhas
        float columnSpacing = 2.4f;
        float rowSpacing = 1.5f;

        // Loop para instanciar os fogos em cada coluna
        for (int col = 0; col < numColumns; col++)
        {
            float x = startX + col * columnSpacing; // Posição X da coluna atual
            sounds[2].Play();
            yield return new WaitForSeconds(0.2f);
            
            // Loop para instanciar os fogos em cada linha da coluna
            for (int row = 0; row < numRowsPerColumn; row++)
            {
                float y = startY - row * rowSpacing; // Posição Y da linha atual
            
                // Instanciar o prefab do fogo na posição calculada
                Instantiate(prefabFogo, new Vector3(x, y, 0), Quaternion.identity);
                 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManage.cash < prefabFogo.GetComponent<EspecialScript> ().price )
            GetComponent<SpriteRenderer> ().material.color = Color.gray;
        else
            GetComponent<SpriteRenderer> ().material.color = Color.white;
        
    }
}
