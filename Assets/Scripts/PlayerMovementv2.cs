using UnityEngine;
using System;


public class PlayerMovementv2 : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody rb;

    public float addedforce = 30000f;
    private int forwy = 1;  
    private int sidewy = 1;
    public float [] silly = {0,0}; //tablica si³ zadanych x i y 
    public float eps1 = 0.0001f;
    public float vert;
    public float hort;
    Vector3 movementVert;
    Vector3 movementHort;
    // Update is called once per frame


    void FixedUpdate()
    {
        forwy = 1;
        silly[0] = rb.linearVelocity.x;
        silly[1] = rb.linearVelocity.z;
        vert = Input.GetAxis("Vertical");
        hort = Input.GetAxis("Horizontal");

        movementHort.x = hort;
        movementVert.z = vert;
        movementHort.Normalize();
        movementVert.Normalize();

        if (Math.Abs(rb.linearVelocity.x) < 8f)
        {
            rb.AddForce(movementHort * addedforce * Time.deltaTime);
        }

        if(Math.Abs(rb.linearVelocity.z) < 8f)
        {
            rb.AddForce(movementVert * addedforce * Time.deltaTime);
        }

        if (Math.Abs(vert) != 0 || Math.Abs(hort) != 0)
        {/*
            if (Math.Abs(silly[0]) < eps1) {
                //rb.AddForce(vert * addedforce * Time.deltaTime, 0, vert*addedforce * Time.deltaTime);
                rb.AddForce(movement*addedforce * Time.deltaTime);
            }
            if (Math.Abs(silly[1]) < eps1)
            {
                //rb.AddForce(hort * addedforce * Time.deltaTime, 0, vert * addedforce * Time.deltaTime);
                rb.AddForce(movement*addedforce * Time.deltaTime);
            }*/
            forwy = 0;
        }

        if (forwy == 1)
        {
            rb.linearVelocity = Vector3.zero;
            silly[0] = 0;
            silly[1] = 0;
            movementHort = Vector3.zero;
            movementVert = Vector3.zero;
        }
    }
}


