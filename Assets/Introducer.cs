using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introducer : MonoBehaviour
{

    void Start()
    {

    }
    public Vector2 move;
    public Vector2 velocity; 
    public float maxSpeed = 1500.0f; 
    public float acceleration = 150.0f; 
    public float brake = 100.0f; 
    public float turnSpeed = 75.0f; 
    private float speed = 1000.0f;   
                                  
    void Update()
    {
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, turn * turnSpeed * Time.deltaTime);
        float forwards = Input.GetAxis("Vertical");
        if (forwards > 0)
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        else if (forwards < 0)
        {
            speed = speed - acceleration * Time.deltaTime;
        }
        else
        {
            if (speed > 0)
            {
                speed = speed - brake * Time.deltaTime;
            }
            else
            {
                speed = speed + brake * Time.deltaTime;
            }
        }

        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        Vector2 velocity = Vector2.up * speed;
        transform.Translate(velocity * Time.deltaTime, Space.Self);
    }




}
