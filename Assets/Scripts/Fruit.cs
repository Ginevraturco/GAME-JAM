using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : VectorCreature {
    
    void Start() {
        
    }

    
    override protected void UpdateCreature() {

        if (agent.lifetime > 34) Kill();
        
    }

}
