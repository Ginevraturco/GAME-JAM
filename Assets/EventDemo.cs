using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDemo : MonoBehaviour
{
    
    void Start() { //Start viene eseguito dopo l'awake di PlayerController
        PlayerController.self.OnCatch.AddListener(FaiCose); //Aggiungo un ascoltatore all'evento di player controller; posso farlo a patto che abbia la stessa forma: int e string
    }

    
    void FaiCose(int i, string s){ //Ogni volta che il giocatore prende un animale scrive punteggio e nome
        Debug.Log("Il giocatore ha preso un " + s + " e ha guadagnato " + i + " punti");
    }
}
