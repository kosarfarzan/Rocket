using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_spawner : MonoBehaviour
{
    public GameObject[] Enemy;
    
    
    void Start()
    {
         StartCoroutine(SpawnEnemies());
    }


    void Update()
    {
        
    }


    void Enemies()
    {
            int rand = Random.Range(0,Enemy.Length);
            float randXPos= Random.Range(-1.72f,1.72f);
            Instantiate(Enemy[rand],new Vector3(randXPos, transform.position.y,transform.position.z) ,Quaternion.Euler(0,0,0));
    }


    IEnumerator SpawnEnemies() {
        while(true){
             yield return new WaitForSeconds(4);
               Enemies();
        }
    }
}
