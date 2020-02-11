using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Censor : MonoBehaviour {
    
    public static Censor self;
    
    void Awake() {
        self = this;
    }


    /*
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
    }*/

    public Dictionary<string,CensusEntry> Census() {
        Dictionary<string, CensusEntry> returner = new Dictionary<string, CensusEntry>();
        foreach (KeyValuePair<string, List<SymAgent>> kvp in SymAgent.All) {
            CensusEntry entry = new CensusEntry(kvp.Key, 0, 0);
            returner[kvp.Key] = entry;
            foreach (SymAgent a in kvp.Value)
                if (a.IsAdult())
                    entry.adults++;
                else
                    entry.infants++;
        }
        return returner;
    }


}

public class CensusEntry {
    public int infants;
    public int adults;
    public string specie;

    public CensusEntry(string specie, int infants, int adults) {
        this.specie = specie; this.infants = infants; this.adults = adults;
    }

}
