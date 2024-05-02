using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField]private GameObject spawnerPrefab;
   private float spwanerInterval = 5.5f; 
    private IEnumerator spawnEnemy(float interval,GameObject enemy){
        while (true){
        yield return new WaitForSeconds(interval);
        Vector3 spawnPosition = transform.position;
        GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    void OnTrigger(Collider2D col){
        if(col.gameObject.tag == "Player"){
             StartCoroutine(spawnEnemy(spwanerInterval, spawnerPrefab));
        }
    }
}
