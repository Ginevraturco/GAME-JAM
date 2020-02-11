using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : VectorCreature {


    void Start() {
        IdleInSpace("TreeCanopy");
    }
          
    public override bool IsAdult() { return agent.lifetime>MotherNature.self.year*0.5f; }

    public override void RandomAge(float portio) {

        //int eta = Random.Range(0, 3);
        int eta = Mathf.FloorToInt(portio * 3);
        agent.lifetime = eta * MotherNature.self.year+phase;
        //Debug.Log(agent.lifetime);
    }

    public static int NextGeneration(int pop) {
        
        Dictionary<string, CensusEntry> census = Censor.self.Census();
        Debug.Log("B " + census["Bird"].adults + " F " + census["Tree"].adults);
        return census["Bird"].adults * census["Tree"].adults/20;
    }

    override protected void UpdateCreature() {

        transform.localScale = Vector3.one * (IsAdult() ? 0.3f : 0.12f);

        float season = MotherNature.self.GetSeason();

        if (currentIdlespace.name == "TreeCanopy" &&  season > 1 && season < 2)
            if (MotherNature.self.elapsedTime % 30 > phase) IdleInSpace("LakeSky");
          
        if (currentIdlespace.name == "LakeSky" && season > 2 && season <3 )
            if (MotherNature.self.elapsedTime % 30 > phase) IdleInSpace("GeyserSky");

        if (currentIdlespace.name == "GeyserSky" && season > 3  )
            if (MotherNature.self.elapsedTime % 30 > phase) IdleInSpace("TreeCanopy");
      

        


       if (agent.lifetime > 270) Kill();
    }

    

}
