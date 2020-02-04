using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : VectorCreature {


    public GameObject[] ages;

    public override void RandomAge() {
        int eta = Random.Range(0, 3);
        SetStage(eta);
        agent.lifetime = eta * MotherNature.self.year+phase;
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
        g.GetComponent<VectorCreature>().agent = SymAgent.Create("Fruit", Random.Range(0, 2.0f));
    }

    void SetStage(int age) {
        for (int i = 0; i < ages.Length; i++)
            ages[i].SetActive(age == i);
    }


}
