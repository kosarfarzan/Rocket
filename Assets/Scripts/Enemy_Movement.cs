using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 4f;    
    public Score_Manager score_Value;
    
    void Start()
    {
        transform = GetComponent<Transform>();
    }


    void Update()
    {
        transform.position -= new Vector3(0,speed * Time.deltaTime,0);
       
        if (transform.position.y <= -10) {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "PlayerBullet"){
               Destroy(gameObject);
               
               

        }
    }
}
