using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;//aralýk
    private float spawnPosZ = 20;//pozisyon
    private float startDelay = 2;//gecikme
    private float spawnInterval = 1.5f;//yumurlama aralýðý
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
        // S tuþuna basýlmadan belli aralýklarla otomatik random hayvan yumurtluyor.
    }

   
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);//rastgele bir sayý üretetir,hangi hayvanýn spawn edileceðini belirler.
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
