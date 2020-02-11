using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anemone : VectorCreature {


    public override void RandomAge(float portio) {
        
        //int eta = Random.Range(0, 3);
        int eta = Mathf.FloorToInt(portio * 3);
        agent.lifetime = eta * MotherNature.self.year+phase;
    }
    
    public static int NextGeneration(int pop) {

        Dictionary<string, CensusEntry> census = Censor.self.Census();
        Debug.Log("A " + census["Anemone"].adults + " F " + census["Fish"].adults);
        return census["Anemone"].adults * census["Fish"].adults/20;
    }

    public override bool IsAdult() { return agent.lifetime>MotherNature.self.year*0.70f; }

    void Start() {
        //IdleInSpace("TreeCanopy");
        
        transform.Rotate(0, Random.value * 360, 0);
    }

        
      
    override protected void UpdateCreature() {

        transform.localScale = Mathf.Clamp(agent.lifetime*0.01f, 0.001f, 1)*Vector3.one;
        if (agent.lifetime > 325) Kill();

    }



}
