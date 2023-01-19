using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 1.5f;
    public float rotationSpeed = 5f;
    public Score_Manager score_Value;
    public AudioSource CoinSound;

    
    void Start()
    {
        
    }


    void Update()
    {
        Movment();
        Clamp();
    }


    void Movment(){
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += new Vector3(speed * Time.deltaTime ,0,0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-30), rotationSpeed * Time.deltaTime);
            }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= new Vector3(speed * Time.deltaTime ,0,0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,30), rotationSpeed * Time.deltaTime);
            }
        if (transform.rotation.z != 90) {
             transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,0), rotationSpeed * Time.deltaTime);
            }
        }


        void Clamp(){
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x,-1.72f,1.72f);
            transform.position = pos;
        }


        private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemies"){
               Time.timeScale = 0 ;
            //    gameOverPanel.SetActive(true);
        }

        
        if (collision.gameObject.tag == "coin"){
               CoinSound.Play();
               score_Value.score += 10;
               Destroy(collision.gameObject);
        }
        
    }

}
