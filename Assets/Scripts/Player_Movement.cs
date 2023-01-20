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
    public AudioSource GameOverSound;
    public GameObject gameOverPanel;
    public GameObject startPanel;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    bool fired = false;
    

    
    void Start()
    {
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
        Time.timeScale = 0 ;
    }


    void Update()
    {
        Movment();
        Clamp();

        if(Input.GetAxis("Fire1")==1){
            if(fired == false){
                fired = true;
                GameObject BulletInstance = Instantiate(BulletPrefab);
                BulletInstance.transform.SetParent(transform.parent);
                BulletInstance.transform.position = transform.position;
                BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(0,BulletSpeed,transform.position.z);
                Destroy(BulletInstance.gameObject,5);
            }
        }
        else{
            fired = false;
        }
        
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
               gameOverPanel.SetActive(true);
               GameOverSound.Play();
        }

        
        if (collision.gameObject.tag == "coin"){
               CoinSound.Play();
               score_Value.score += 10;
               Destroy(collision.gameObject);
        }
        
    }


        public void GameStart(){
            startPanel.SetActive(false);
            Time.timeScale = 1;
            
         }


         





         

}
