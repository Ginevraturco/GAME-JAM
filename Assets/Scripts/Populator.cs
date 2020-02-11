using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populator : MonoBehaviour
{

    public int pop = 3;

    public string creature = "Fish";

    int gen = 3;

    void Start() {
        if (creature == "Fish" || creature == "Walker") gen = 1;

        Populate(pop);
    }

    public void Populate(int pula, bool spawninfant=false) {
        for (int i=0; i<pula; i++) {
            GameObject g = Instantiate(MotherNature.Creatures[creature], /*transform.position + Random.insideUnitSphere * 2*/ GetComponent<Idlespace>().PickPoint(), Quaternion.identity);
            g.SetActive(true);
            g.GetComponent<VectorCreature>().agent = SymAgent.Create(creature, g.GetComponent<VectorCreature>(),UnityEngine.Random.Range(0, 2.0f));
            if (!spawninfant) g.GetComponent<VectorCreature>().RandomAge(i/(float)pula);
          //  g.GetComponent<Fish>().IdleInSpace(GetComponent<Idlespace>());
        }

    }

    public void PopulateWisely() {

        int howmany = (int) Type.GetType(creature).GetMethod("NextGeneration").Invoke(null,new object[] { pop});
        //Debug.Log(creature + " " + (pop / gen)+" "+howmany);
        int theorical = pop / (gen);
        int maxadj = theorical - howmany;
        if (howmany>0) howmany += Mathf.RoundToInt(maxadj * 0.55f);
        //int adjust = Mathf.RoundToInt((theorical - howmany) / 2 + UnityEngine.Random.Range(-0.5f, 0.5f));
        //adjust = Mathf.Max(0,Mathf.Min(howmany, adjust));
        //howmany += adjust;
        //Populate(pop / (gen), true);
        Populate(howmany, true);
        
    }


    void Update() {
        
    }
}
