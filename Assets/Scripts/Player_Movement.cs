using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 1.5f;
    public float rotationSpeed = 5f;
    
    
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
            pos.x = Mathf.Clamp(pos.x,-1.73f,1.73f);
            transform.position = pos;
        }

}
