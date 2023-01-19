using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{

    public GameObject coinPrefabs;
    void Start()
    {
        StartCoroutine(CoinSpawner());
    }

    
    void Update()
    {
        
    }


    void CoinSpawn(){
        float rand = Random.Range(-1.72f,1.72f);
        Instantiate(coinPrefabs, new Vector3(rand,transform.position.y,transform.position.z),Quaternion.identity);
    }


    IEnumerator CoinSpawner() {
        while (true) {
            int time = Random.Range(8,20);
            yield return new WaitForSeconds(time);
            CoinSpawn();
        }
    }
}
