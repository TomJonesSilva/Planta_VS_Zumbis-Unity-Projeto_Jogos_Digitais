using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesScript : MonoBehaviour
{
    public float life, vel,dano;
    private bool conWalk, canEat;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource sound;
    private SpriteRenderer sp;
    public bool chefe = false;
    private EscurecerTelaScript escurecerTela;
    private List<GameObject> plantasEncontradas = new List<GameObject>();
   
    private float velInicial;
    private int numberOfZombies;
    void Start()
    {
        canEat = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        GameObject gameManagerObject = GameObject.Find("GameManage");
        escurecerTela = gameManagerObject.GetComponent<EscurecerTelaScript>();
        
        
        if(chefe){ 
        InvokeRepeating("CheckPlantsInCorridors",60f,60f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        ChecPlant();
        CheckDeath();
    }
    void FixedUpdate(){
        rb.velocity = conWalk ? new Vector2(-vel*Time.deltaTime, 0) : Vector2.zero;

    }

    void CheckDeath(){
        if(life <= 0)
        Destroy(gameObject);
    }

    void ChecPlant(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 0.3f, LayerMask.GetMask("Plants"));

        if(hit.collider != null){
            anim.SetBool("1comendo",true);
            conWalk = false;
            if(canEat)
                StartCoroutine(Eating(hit.collider));
            if(!sound.isPlaying)
                sound.Play();
        }else{
            sound.Stop();
            StopCoroutine("Eating");
            conWalk = true;
            canEat = true;
            anim.SetBool("1comendo", false);
        }
    }

    IEnumerator Eating (Collider2D col){
        canEat = false;
        yield return new WaitForSeconds(2);
        canEat = true;
        if(col != null)
        col.gameObject.GetComponent<Properties>().life -= (int)dano;
    }

    public void WalkSlow(){
        if(sp.material.color != Color.cyan){ 
            sp.material.color = Color.cyan;
            velInicial = vel;
            vel *=0.7f;
            Invoke("WalkFast",5);
        }else{
            CancelInvoke("WalkFast");
            Invoke("WalkFast",5);
        }
        

    }
     void WalkFast(){ 
        sp.material.color = Color.white;
        vel = velInicial; 
        
    }
    void CheckPlantsInCorridors()
{
        // Define os corredores e inicializa o dicionário para armazenar o número de plantas em cada corredor
        float[] corredores = new float[] { 3.5f, 1.87f, 0.3f, -1.3f, -2.9f };
        Dictionary<float, int> plantasPorCorredor = new Dictionary<float, int>();

        // Inicializa o dicionário com zero plantas em cada corredor
        foreach (float yCorredor in corredores)
            plantasPorCorredor[yCorredor] = 0;
        

        foreach (float yCorredor in corredores)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, yCorredor), -Vector2.right, 25.0f, LayerMask.GetMask("Plants"));

            // Atualiza o número de plantas encontradas no corredor atual
            
            plantasPorCorredor[yCorredor] = hits.Length;


            // Adiciona as instâncias das plantas encontradas à lista de plantas encontradas
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    GameObject planta = hit.collider.gameObject;
                    plantasEncontradas.Add(planta);
                }
            }
        }

        // Exibe o número de plantas em cada corredor
        foreach (var kvp in plantasPorCorredor)
        {
            Debug.Log("Número de plantas no corredor " + kvp.Key + ": " + kvp.Value);
        }
        
       
        TransportaZumbi(plantasPorCorredor);
    }

    void TransportaZumbi(Dictionary<float, int> plantasPorCorredor)
{
        
        // Encontra o corredor com a menor quantidade de plantas
        float menorQuantidadePlantas = float.MaxValue;
        float corredorSelecionado = 0f;

        foreach (var kvp in plantasPorCorredor)
        {
            if (kvp.Value < menorQuantidadePlantas)
            {
                menorQuantidadePlantas = kvp.Value;
                corredorSelecionado = kvp.Key;
            }
        }
        
        sp.sortingOrder = -4;
        escurecerTela.IniciarEscurecimento(4f,1f);
        transform.position = new Vector2(transform.position.x, corredorSelecionado);
        Invoke("ReativarZumbi",5f);
        Invoke("EscolherEdestruirPlanta",5f);
        


        
}
    void ReativarZumbi (){
        sp.sortingOrder = 4;     
    }


    // Função para escolher aleatoriamente e potencialmente destruir uma planta
    private void EscolherEdestruirPlanta()
    {
        int chanceDeDestruicaoDesejada = numberOfZombies * 2;
        // Verifica se há plantas na lista
        if (plantasEncontradas.Count == 0)
        {
            Debug.Log("Nenhuma planta disponível para escolha.");
            return;
        }
    
        // Escolhe aleatoriamente uma planta da lista
        int indexPlantaSelecionada = UnityEngine.Random.Range(0,plantasEncontradas.Count);
        GameObject plantaSelecionada = plantasEncontradas[indexPlantaSelecionada];

        // Sorteia um número entre 0 e 100 para determinar se a planta será destruída
        int chanceDeDestruicao =UnityEngine.Random.Range(0, 101);
        


        // Verifica se a chance de destruição é menor ou igual à chance desejada
        if (chanceDeDestruicao <= chanceDeDestruicaoDesejada)
        {
            // Destroi a planta selecionada
            Destroy(plantaSelecionada);
            Debug.Log("Planta destruída com sucesso!");
        }
        else
        {
            Debug.Log("A planta foi poupada desta vez.");
        }
    }
    public void QtdzombiesWave(int numberOfZombies){
        this.numberOfZombies = numberOfZombies;
    }
}
