using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : VectorCreature {

    
    
    void Start() {
        IdleInSpace("TreeCanopy");
    }

        
      
    override protected void UpdateCreature() {
        if (currentIdlespace.name == "TreeCanopy" && MotherNature.self.GetSeason() > 1 )
            if (MotherNature.self.elaspedTime % 30 > phase) IdleInSpace("LakeSky");

        if (currentIdlespace.name == "LakeSky" && MotherNature.self.GetSeason() > 2 )
            if (MotherNature.self.elaspedTime % 30 > phase) IdleInSpace("GeyserSky");

        if (currentIdlespace.name == "GeyserSky" && MotherNature.self.GetSeason() < 1 )
            if (MotherNature.self.elaspedTime % 30 > phase) IdleInSpace("TreeCanopy");



       if (agent.lifetime > 270) Kill();
    }

    

}
