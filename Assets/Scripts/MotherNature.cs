using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherNature : MonoBehaviour {

    public List<GameObject> creaturlist=new List<GameObject>(); //Si converte questa lista di creature inserite a mano
    public static Dictionary<string, GameObject> Creatures = new Dictionary<string, GameObject>(); //in questo bellissimo dizionario raggiungibile dinamicamente

    public List<Idlespace> environlist=new List<Idlespace>(); //Si converte questa lista di spazi inseriti a mano
    public static Dictionary<string, Idlespace> Environments = new Dictionary<string, Idlespace>(); //in questo bellissimo dizionario raggiungibile dinamicamente
    public static Dictionary<string, Populator> Nursery = new Dictionary<string, Populator>(); //

    public float year = 120; //Un anno in tempo di gioco
    public int characterlife = 5; 
    public float elaspedTime = 0;

    public static MotherNature self;
    public float timescale; //definito dalla scena

    void Awake() {
        self = this;
        foreach (GameObject g in creaturlist) {
            Creatures.Add(g.name, g);
            g.SetActive(false);
        }

        foreach (Idlespace s in environlist) {
            Environments.Add(s.name, s);
            foreach (Populator p in s.gameObject.GetComponents<Populator>())
                Nursery[p.creature] = p;
        }



    }

    List<List<string>> stagiono = new List<List<string>>() { new List<string>() {"Tree", "Fish" } ,
                                                             new List<string>() {"Walker" } ,
                                                             new List<string>() { } ,
                                                             new List<string>() {"Bird", "Anemone" } };

    public void TriggerSeason(int season) {
        foreach (string s in stagiono[season])
            Nursery[s].PopulateWisely();
    }

    public int prev = 0;
    void Update() {
        elaspedTime += timescale * Time.deltaTime;
        int next = Mathf.FloorToInt(GetSeason());
        if (prev != next) TriggerSeason(next);
        prev = next;
    }

    public float GetSeason() {
        return (elaspedTime % 120) / 30;
    }

}