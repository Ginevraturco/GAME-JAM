using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : VectorCreature {


    public GameObject[] ages;

    public override bool IsAdult() { return agent.lifetime>MotherNature.self.year*0.75f; }

    public override void RandomAge(float portio) {
        //int eta = Random.Range(0, 3);
        int eta = Mathf.FloorToInt(portio * 3);
        SetStage(eta);
        agent.lifetime = eta * MotherNature.self.year+phase;
    }
    
    public static int NextGeneration(int pop) {
        Dictionary<string, CensusEntry> census = Censor.self.Census();

        Debug.Log("W " + census["Walker"].adults + " F " + census["Fruit"].adults);
        return census["Walker"].adults * census["Fruit"].adults/40;
    }

    void Start() {
        //IdleInSpace("TreeCanopy");
        SetStage(0);
        transform.Rotate(0, Random.value * 360, 0);
    }

    int fruits = 2;    

      
    override protected void UpdateCreature() {
        
        if (agent.lifetime > 60)
            SetStage(1);
        if (agent.lifetime > 120)
            SetStage(2);
        if (agent.lifetime > 270) Kill();

        if ((agent.lifetime > 60)) { 
            if (MotherNature.self.GetSeason() < 3) fruits = 2;
            if (MotherNature.self.GetSeason() > 3 && fruits ==2) { GenerateFruit(); fruits = 1; }
            if (MotherNature.self.GetSeason() > 3.2 && fruits ==1) { GenerateFruit(); fruits = 0; }
        }

    }

    private void GenerateFruit() {
        GameObject g = Instantiate(MotherNature.Creatures["Fruit"], GetComponent<Idlespace>().PickPoint(), Quaternion.identity);
        g.SetActive(true);
        g.GetComponent<VectorCreature>().agent = SymAgent.Create("Fruit",g.GetComponent<VectorCreature>(), Random.Range(0, 2.0f));
    }

    void SetStage(int age) {
        for (int i = 0; i < ages.Length; i++)
            ages[i].SetActive(age == i);
    }


}
