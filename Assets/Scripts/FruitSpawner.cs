using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    //Creamos la referencia al melon prefabricado 
    public GameObject fruitPrefab;
    //Creamos la referencia para la aparicion de los melones 
    public Transform[] spawnPoints;

    //Parametros del retardo 
    public float minDelay = .1f;
    public float maxDelay = 1f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    //Creamos una corutina 
    IEnumerator SpawnFruits()
    {
        //Estará repitiendose indefinidamente
        while (true)
        {
            //Creamos un retrazo entre la creacion de cada una de las creaciones de manera a aleatoria 
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            //Creamos el punto de creacion
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            //Generamos la siguiente fruta con las posiciones aleatorias generadas
            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            //Destruimos el objeto despues despues de 5 segundos
            Destroy(spawnedFruit, 5f);
        }
    }
}
