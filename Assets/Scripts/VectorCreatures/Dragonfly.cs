using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonfly : VectorCreature {


    float timebellula = 0;

    void Start() {

        IdleInSpace(MotherNature.Environments["LakeSky"]);
    }

        
      
    override protected void UpdateCreature() {
        timebellula += Time.deltaTime * MotherNature.self.timescale;

        if (timebellula>20 && currentIdlespace.name!="AnemonesSky" & MotherNature.self.GetSeason()>2) 
            IdleInSpace(MotherNature.Environments["AnemonesSky"]);

        if (agent.lifetime>100 && MotherNature.self.GetSeason()<2)
            IdleInSpace(MotherNature.Environments["LakeSky"]);

        if (agent.lifetime > 150) Kill();
        //    GoFish();
    }

    public void GoFish() {
        GameObject dragon=Instantiate(MotherNature.Creatures["Fish"], transform.position, transform.rotation);
        dragon.GetComponent<Fish>().agent = SymAgent.Create("Fish"); //this.agent;
        dragon.SetActive(true);
        Destroy(this.gameObject);
    }

}
