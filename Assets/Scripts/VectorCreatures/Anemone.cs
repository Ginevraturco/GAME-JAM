using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anemone : VectorCreature {


    public override void RandomAge() {
        int eta = Random.Range(0, 3);
        agent.lifetime = eta * MotherNature.self.year+phase;
    }
    
    void Start() {
        //IdleInSpace("TreeCanopy");
        
        transform.Rotate(0, Random.value * 360, 0);
    }

        
      
    override protected void UpdateCreature() {

        transform.localScale = Mathf.Clamp(agent.lifetime*0.01f, 0.001f, 1)*Vector3.one;
        if (agent.lifetime > 270) Kill();

    }



}
