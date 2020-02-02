using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Cinemachine;
using UnityEditor.Animations;
using UnityEngine.AI;
using UnityEngineInternal.Input;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    CharacterController _controller;
    public float speed = 4;
    public float rotationSpeed = 4;
    public Animator anim;
    //public GameObject canvas;
    
    private NavMeshAgent _agent;
    private Rigidbody rb;
    private bool swim;
    private float swimSpeed = 1;
    
    
    
    private float thrust = 100.0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
      
    }

    private Vector3 move = Vector3.zero;
    
    void Update()
    {
        
      //  if (Input.GetButtonDown("Fire2"))
        //{
          //  canvas.gameObject.SetActive(true);
        //}
        //else
        //{
         //   canvas.gameObject.SetActive(false);
       // }
        
        var hMove = Input.GetAxis("Horizontal");
        var rotation = rotationSpeed * hMove;
        var rotVector = new Vector3(0, rotation, 0);
        transform.Rotate(rotVector);

       // var forward = transform.TransformDirection(Vector3.forward);
        var vMove = Input.GetAxis("Vertical");
        vMove = Mathf.Clamp(vMove, 0, 1);
      //  var currentSpeed = speed * vMove;
      //  var move = currentSpeed * forward;
        //_controller.SimpleMove(move);
        move.z=speed * vMove;

       // if (Input.GetKeyDown(KeyCode.K))
       //     if (_controller.isGrounded)
         //       move.y += 10;
        
        //if (!_controller.isGrounded)
         //   move.y -= 5 * Time.deltaTime;
        //else
          //  move.y = 0;
        
        //Debug.Log(_controller.isGrounded);
        
        transform.Rotate(0,rotation*Time.deltaTime,0);
        
        transform.Translate(move*Time.deltaTime);
        
       
       
        
        
        anim.SetFloat("Walk", vMove);
    }

    public int score = 0;

    private void OnCollisionEnter(Collision collision) {
        Collectable collo = collision.gameObject.GetComponent<Collectable>();
        if (collo == null) return;
        score+=collo.Collect();

    } 

    private void OnTriggerStay(Collider coll)
    {
        
        switch (coll.gameObject.name) 
        { 
            case "Geyser" :
                rb.AddForce(transform.up * thrust);
                anim.SetBool("Fly", true);

                break;
            
           

            
            case "TriggerWater" :
                swim = true;
                anim.SetBool("Swim", true);
               rb.useGravity = false;
                rb.velocity = Vector3.zero;
                
                
                
                var swimY = Input.GetAxis("Fire1");
                //move.y += 
                
                
                
              
                if (Input.GetAxis("Fire1") > 0 )
                {
                   
                    gameObject.transform.position += new Vector3(0, (swimSpeed * Time.deltaTime), 0);
                    // swimY = Mathf.Clamp(swimY, 0, 1);
                }
                else gameObject.transform.position += new Vector3(0, -(swimSpeed * Time.deltaTime), 0);


                break;
            
            case "TriggerBeach":
                //transform.Translate(transform.forward *3  + Vector3.up);
                transform.Translate(transform.localRotation*Vector3.right + Vector3.up);
               
                break;
         
            
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        switch (coll.gameObject.name)
        {
            case "TriggerWater":
                rb.useGravity = true;
                anim.SetBool("Swim", false);
                swim = false;
                break;

            case "Geyser":
            {
                anim.SetBool("Fly", false);

                break;
            }
        }
    }
}
