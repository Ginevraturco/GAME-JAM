using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populator : MonoBehaviour
{

    public int pop = 3;

    public string creature = "Fish";

    int gen = 3;

    void Start() {
        if (creature == "Fish" || creature == "Walker") gen = 2;

        Populate(pop);
    }

    public void Populate(int pula) {
        for (int i=0; i<pula; i++) {
            GameObject g = Instantiate(MotherNature.Creatures[creature], /*transform.position + Random.insideUnitSphere * 2*/ GetComponent<Idlespace>().PickPoint(), Quaternion.identity);
            g.SetActive(true);
            g.GetComponent<VectorCreature>().agent = SymAgent.Create(creature, Random.Range(0, 2.0f));
            g.GetComponent<VectorCreature>().RandomAge();
          //  g.GetComponent<Fish>().IdleInSpace(GetComponent<Idlespace>());
        }

    }

    public void PopulateWisely() {
        Populate(pop / gen);
    }


    void Update() {
        
    }
}
