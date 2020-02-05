using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Cinemachine;
//using UnityEditor.Animations;
using UnityEngine.AI;
using UnityEngineInternal.Input;
using Debug = UnityEngine.Debug;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    CharacterController _controller;
    public float speed = 4;
    public float jumpSpeed = 4;
    public float rotationSpeed = 1;
    public Animator anim;
    public GameObject canvas;
    
    private NavMeshAgent _agent; //la navmesh serve per le AI
    
    public  bool swim;
    private float swimSpeed = 1;//potremmo usarlo in una proprietà; poi vediamo

    public int score = 0; //Tipicamente il punteggio dovrebbe stare su qualcosa di esterno

    public static PlayerController self;

    private void Awake() {
        self = this;
    }

    void Start() {
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>(); //Ho disabilitato il rigidbody e preferito il character controller perchè altrimenti quando picchiava sulle cose impazziva
      
    }

    private Vector3 move = Vector3.zero; //deve stare fuori per simulare inerzia

    float gDefault = 20; //gravità default
    float gWater = 1;  //gravità nell'acqua ossia gravità - spinta idrostatica; le puoi mettere public se vuoi

    float Gravity { get { return swim ? gWater : gDefault; } } //Questa si chiama Proprietà; si usa come una variabile ma è simile a una funzione; si può leggere e scrivere (get, set); questa solo leggere

    void Update() {
        move.z=Input.GetAxis("Vertical")*speed; //Raccolgo la velocità di avanzamento
        anim.SetFloat("Walk", Input.GetAxis("Vertical"));  

        if (!_controller.isGrounded)        //se non è grounded
            move.y -= Gravity * Time.deltaTime; //cadi
        else
            if (Input.GetKeyDown(KeyCode.Space) && !swim) //se no salta; a meno che tu non stia nuotando
                move.y = jumpSpeed;
        
        if (swim && Input.GetKey(KeyCode.Space)) //se stai nuotando e tieni premuta la barra
            move.y = Mathf.Max(2,move.y); //lentamente sali di 2(dovrei rendere 2 parametrico).

        transform.Rotate(0, Input.GetAxis("Horizontal") * 60 * rotationSpeed * Time.deltaTime, 0); //mi ruoto sul mio asse y di 60 gradi al secondo * rotation speed (1.2=> 72° al secondo); prima non c'era time.deltatime era un errore
        _controller.Move(transform.rotation*move*Time.deltaTime); //usa MOVE per avazare nel rispetto degli ostacoli. Nei casi in cui non c'è il controller, si usa transform.translate; non position+=; position+= teletrasporta; translate incontra ostacoli e si ferma. Oggi si usa Move che setta isGrounded a true
        
    }
    /*    
        void Update2()  { //resa obsoleta

           if (Input.GetButton("Fire2"))
            {
                canvas.gameObject.SetActive(true);
            }
            else
            {   canvas.gameObject.SetActive(false);
            }

            var hMove = Input.GetAxis("Horizontal");
            var rotation = rotationSpeed * hMove;
            var rotVector = new Vector3(0, rotation, 0);
            transform.Rotate(rotVector);

           // var forward = transform.TransformDirection(Vector3.forward);
            var vMove = Input.GetAxis("Vertical");
            //vMove = Mathf.Clamp(vMove, 0, 1);
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

      */

    //private void OnCollisionEnter(Collision collision) { //On collision non si può usare col CharacterController

    public class IntString : UnityEvent<int, String> {} //Questo è un evento personalizzato; una funzione a cui altri si possono legare per fare cose
    public IntString OnCatch = new IntString(); //questa è un'istanza di quell'evento personalizzato.

    void OnControllerColliderHit(ControllerColliderHit collision){
        Collectable collo = collision.gameObject.GetComponent<Collectable>();
        if (collo == null) return;
        int hisscore=collo.Collect();
        score += hisscore;
        OnCatch.Invoke(hisscore, collo.gameObject.GetComponent<VectorCreature>().GetType().Name); //Sto chiamando l'evento personalizzato; tutti quelli che si sono registrati ricevono il segnale
    }

    private void OnTriggerEnter(Collider coll)
    {
        switch (coll.gameObject.name)
        {

            case "TriggerWater":
                anim.SetBool("Swim", true);
                Debug.Log("trigger");
                break;
        }
    }

    

    private void OnTriggerStay(Collider coll)
    {
        
        switch (coll.gameObject.name) 
        { 
            case "Geyser" :
                //rb.AddForce(transform.up * thrust);
                move.y = 20;
                anim.SetBool("Fly", true);

                break;
            
            
            case "TriggerWater" :
                swim = true;
                
             //  rb.useGravity = false;
               // rb.velocity = Vector3.zero;
                
                
                
                /*var swimY = Input.GetAxis("Fire1");
                //move.y += 
                
                
                
              
                if (Input.GetAxis("Fire1") > 0 )
                {
                   
                    gameObject.transform.position += new Vector3(0, (swimSpeed * Time.deltaTime), 0);
                    // swimY = Mathf.Clamp(swimY, 0, 1);
                }
                else gameObject.transform.position += new Vector3(0, -(swimSpeed * Time.deltaTime), 0);

    */
                break;
            
            case "TriggerBeach":
                //transform.Translate(transform.forward *3  + Vector3.up);
                //transform.Translate(transform.localRotation*Vector3.right + Vector3.up);

                move.y = 6;
                move.z = 8;

                break;
         
            
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        switch (coll.gameObject.name)
        {
            case "TriggerWater":
              //  rb.useGravity = true;
                anim.SetBool("Swim", false);
                swim = false;
                break;

            case "Geyser":
            {
                anim.SetBool("Fly", false); //no, perchè il contatto col geyser dura un istante; devi triggerarlo quando scende sotto una certa quota, nell'update ;) 

                break;
            }
        }
    }
}
