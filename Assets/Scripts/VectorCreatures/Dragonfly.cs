using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonfly : VectorCreature {


    float timebellula = 0;

    void Start() {

        IdleInSpace(MotherNature.Environments["LakeSky"]);
    }

    public override bool IsAdult() { return true; }    
      
    override protected void UpdateCreature() {
        timebellula += Time.deltaTime * MotherNature.self.timescale;

        if (agent.lifetime<80 && timebellula>10 && currentIdlespace.name!="AnemonesSky" & MotherNature.self.GetSeason()>2) 
            IdleInSpace(MotherNature.Environments["AnemonesSky"]);

        if (agent.lifetime>100 && currentIdlespace.name!="LakeSky"/* && MotherNature.self.GetSeason()<2*/)
            IdleInSpace(MotherNature.Environments["LakeSky"]);

        if (agent.lifetime > 130) Kill();
        //    GoFish();
    }
    /*
    public void GoFish() {
        GameObject dragon=Instantiate(MotherNature.Creatures["Fish"], transform.position, transform.rotation);
        dragon.GetComponent<Fish>().agent = SymAgent.Create("Fish"); //this.agent;
        dragon.SetActive(true);
        Destroy(this.gameObject);
    }*/

}
