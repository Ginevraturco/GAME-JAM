using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreFlash : MonoBehaviour
{
    TMP_Text textscore;
    public GameObject flash;

    void Start() { //Start viene eseguito dopo l'awake di PlayerController
        textscore = GetComponent<TMP_Text>();
        PlayerController.self.OnCatch.AddListener(DisplayScore); //Aggiungo un ascoltatore all'evento di player controller; posso farlo a patto che abbia la stessa forma: int e string
    }

    
    void DisplayScore(int i, string s){ //Ogni volta che il giocatore prende un animale scrive punteggio e nome
        textscore.text = i.ToString();
        flash.SetActive(true);
        CancelInvoke("Offscore");
        Invoke("Offflash", 0.05f);
        Invoke("Offscore", 2.5f);
    }


    void Offflash() { flash.SetActive(false); }

    void Offscore() { textscore.text=""; }

}
