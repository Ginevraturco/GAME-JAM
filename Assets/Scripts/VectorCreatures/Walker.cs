using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : VectorCreature {


    SphereCollider colli;
    void Start() {
        colli = GetComponent<SphereCollider>();
        IdleInSpace("AnemonesGround");
        //agent.lifetime = Random.Range(0, 2) * MotherNature.self.year + phase;
//        Debug.Log(agent.lifetime);
    }

    public override bool IsAdult() { return agent.lifetime>80f; }  
      
    public override void RandomAge(float portio) {
        
      //  agent.lifetime = Random.Range(0,2)*MotherNature.self.year+phase;
        agent.lifetime = 90+phase;
    }

    public static int NextGeneration(int pop) {
        Dictionary<string, CensusEntry> census = Censor.self.Census();
        Debug.Log("W " + census["Walker"].adults + " A " + census["Anemone"].adults);
        return census["Walker"].adults * census["Anemone"].adults/10;
    }

    override protected void UpdateCreature() {
        //transform.localScale=Vector3.one*(0.1f+Mathf.Clamp(agent.lifetime,80,90)*0.1)
        transform.localScale = Vector3.one * (Mathf.Lerp(0.1f, 1, (agent.lifetime - 90) / 10));
        colli.enabled = agent.lifetime > 95 && agent.lifetime<125;
        if (agent.lifetime > 125) IdleInSpace("AnemonesUnderground");
        else { 
        
        if (currentIdlespace.name == "AnemonesGround" && MotherNature.self.GetSeason() > 3 )
            if (MotherNature.self.elapsedTime % 30 > phase) IdleInSpace("TreeGround");

        if (currentIdlespace.name == "TreeGround" && MotherNature.self.GetSeason() < 1 )
            if (MotherNature.self.elapsedTime % 30 > phase) IdleInSpace("AnemonesGround");
        }
        //animazione sprofondamento pre morte a 155

       if (agent.lifetime > 127) Kill();
    }

    private void OnCollisionEnter(Collision collision) {
        GetNewDestination();
    }
    private void OnCollisionStay(Collision collision) {
        GetNewDestination();
    }

}
