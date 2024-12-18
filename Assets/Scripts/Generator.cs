using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject prefab; // Prefab a generar
    public float spawnInterval = 4f; // Interval de temps entre generacions
    public float verticalOffset = 10f;
    private bool stop = false;
    
    void Start()
    {
        // Comença la corrutina per generar els objectes
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (stop == false) // Bucle infinit
        {
            // Calcula un desplaçament aleatori en l'eix Y
            float randomYOffset = Random.Range(-verticalOffset, verticalOffset);

            // Crea una nova posició amb el desplaçament
            Vector3 spawnPosition = transform.position + new Vector3(0, randomYOffset, 0);

            // Crea una instància del prefab a la nova posició
            Instantiate(prefab, spawnPosition, Quaternion.identity);

            // Espera el temps definit abans de generar el següent
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    public void stopSpawn() 
    {   
        Debug.Log("Stopping pipes");
        stop = true;
       
    }
}
