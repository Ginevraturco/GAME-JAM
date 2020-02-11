using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeepScore : MonoBehaviour
{
    TMP_Text textscore;
    

    void Start() { //Start viene eseguito dopo l'awake di PlayerController
        textscore = GetComponent<TMP_Text>();
        
    }


    private void Update()
    {
        textscore.text = "SCORE: "+PlayerController.self.score.ToString();
        
    }


    

}
