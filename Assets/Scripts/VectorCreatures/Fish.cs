using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : VectorCreature {

    SphereCollider colli;
    void Start() {
         colli = GetComponent<SphereCollider>();
        IdleInSpace(MotherNature.Environments["Lake"]);
    }

    public static int NextGeneration(int pop) {
        
        Dictionary<string, CensusEntry> census = Censor.self.Census();
        Debug.Log("F " + census["Fish"].adults + " B " + census["Bird"].adults);
        return census["Fish"].adults * census["Bird"].adults/10;
    }

    public override bool IsAdult() { return false; }
    
    override protected void UpdateCreature()
    {
        //if (agent.lifetime > 60)
          //GoDragonfly();  
        colli.enabled = agent.lifetime > 35 ;

        transform.localScale = Vector3.one * Mathf.Lerp(0.1f, 1, (agent.lifetime - 30) / 10);

        if (MotherNature.self.GetSeason() > 2 )
            if (MotherNature.self.elapsedTime % 30 > phase) GoDragonfly();
    }

    public void GoDragonfly() {
        GameObject dragon=Instantiate(MotherNature.Creatures["Dragonfly"], transform.position, transform.rotation);
        dragon.SetActive(true);
        dragon.GetComponent<Dragonfly>().agent = this.agent;
        this.agent.vector = dragon.GetComponent<Dragonfly>();
        Destroy(this.gameObject);
    }

}
