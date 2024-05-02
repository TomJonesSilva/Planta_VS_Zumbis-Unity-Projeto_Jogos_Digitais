using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwZumbies : MonoBehaviour
{
    public GameObject[] zombieTypes;
    public AudioClip clip;
    private int numberOfZombies = 4;
    private float minX = 11.5f;
    private float maxX = 15.5f;
    private float[] positionY = {3.5f, 1.87f, 0.3f, -1.3f, -2.9f};
    private float waveCooldown = 60.0f; 
    public float timeSinceLastWave;
    private float delay = 0.5f;
    private int contadorChefe=0;

    




    // Start is called before the firsot frame update
    void Start()
    {
        StartWave();

    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastWave >=waveCooldown)
            StartWave();
    }

    void StartWave(){
        timeSinceLastWave = 0.0f;
       
        StartCoroutine(SpawnZombiesWithDelay(delay)); 
         if(numberOfZombies % 10 == 0){ 
            SpawnChefe();
        }
        if(numberOfZombies < 31)      
            numberOfZombies += 2;
        else numberOfZombies +=1;

       
    }

    void Spawnzombies(){

        
            int randomZumbieIndex = Random.Range(0,2);
            float randomX = Random.Range(minX, maxX);
            float randomY = positionY[Random.Range(0, positionY.Length)];

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        
        GameObject zombie =   Instantiate(zombieTypes[randomZumbieIndex],spawnPosition, Quaternion.identity);

        //aumento de força dos zumbi
        
        if (numberOfZombies >= 10 && numberOfZombies < 20)
        {
            zombie.GetComponent<ZombiesScript>().vel += 1;
            zombie.GetComponent<ZombiesScript>().life += 1;
        }
        else if (numberOfZombies >= 20 && numberOfZombies < 31)
        {
            zombie.GetComponent<ZombiesScript>().vel += 2;
            zombie.GetComponent<ZombiesScript>().life += 2;
        }
        else if (numberOfZombies >= 32)
        {
            zombie.GetComponent<ZombiesScript>().vel += (numberOfZombies - 30) + 1;
            zombie.GetComponent<ZombiesScript>().life += (numberOfZombies - 30) + 1;
        }

    }
        
    void SpawnChefe(){
        AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position);
        float randomY = positionY[Random.Range(0, positionY.Length)];

        Vector3 spawnPosition = new Vector3(13f, randomY, 0f);
        
        GameObject zombie =   Instantiate(zombieTypes[2],spawnPosition, Quaternion.identity);
        zombie.GetComponent<ZombiesScript>().QtdzombiesWave(numberOfZombies);

        /*
        if (numberOfZombies % 5 == 0 || (numberOfZombies -1) % 5==0)
        {
            zombie.GetComponent<ZombiesScript>().vel += contadorChefe;
            zombie.GetComponent<ZombiesScript>().life += numberOfZombies;
            contadorChefe +=2;
        }
        */
       
    }

    void FixedUpdate(){
        timeSinceLastWave += Time.deltaTime;
    }

    IEnumerator SpawnZombiesWithDelay(float delay){
        for(int i=2; i<numberOfZombies; i++){
            yield return new WaitForSeconds(delay);
            Spawnzombies();
        }
    }

}
