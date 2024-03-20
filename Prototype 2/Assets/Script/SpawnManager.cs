using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;//aral�k
    private float spawnPosZ = 20;//pozisyon
    private float startDelay = 2;//gecikme
    private float spawnInterval = 1.5f;//yumurlama aral���
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
        // S tu�una bas�lmadan belli aral�klarla otomatik random hayvan yumurtluyor.
    }

   
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);//rastgele bir say� �retetir,hangi hayvan�n spawn edilece�ini belirler.
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
