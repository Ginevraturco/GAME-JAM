using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Censor : MonoBehaviour {
    

    void Start() {
        s += SymAgent.Censimento('\t')+"\r\n";
        
    }

    string s = "";
    float last = 0;
    public float step = 1;
    void Update() {
        if (Time.time-last>=step) { //Non tiene conto della velocità del mondo; basta che lo sappiamo noi fissando lo step.
            s += SymAgent.Censimento('\t')+"\r\n";
        }
    }

    void OnDestroy() {
        System.IO.File.WriteAllText("Censimento.txt", s);
    }

}
