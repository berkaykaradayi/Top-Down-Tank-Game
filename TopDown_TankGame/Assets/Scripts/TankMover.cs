using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public TankMovementData movementData;
    private Vector2 movementVector;

    
    public float currentspeed = 0;
    public float currentForewardDirection =1;


    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
            currentForewardDirection = 1;
        
        else if(movementVector.y < 0)
            currentForewardDirection = -1;

    }

    private void CalculateSpeed(Vector2 movementVector)
    {
       if(Mathf.Abs(movementVector.y)>0)
        {
            currentspeed += movementData.acceleration * Time.deltaTime;
        }
       else
        {
            currentspeed -= movementData.deacceleration * Time.deltaTime;
        }
        currentspeed = Mathf.Clamp(currentspeed, 0, movementData.maxSpeed);
    }


    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up *  
            currentspeed *currentForewardDirection* Time.fixedDeltaTime;
       
        rb2d.MoveRotation(transform.rotation * 
            Quaternion.Euler(0, 0, -movementVector.x *
            movementData.rotationSpeed * Time.fixedDeltaTime));

    }
}
