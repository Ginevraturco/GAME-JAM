using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : VectorCreature {

    SphereCollider colli;
    void Start() {
         colli = GetComponent<SphereCollider>();
        IdleInSpace(MotherNature.Environments["Lake"]);
    }

    
    override protected void UpdateCreature()
    {
        //if (agent.lifetime > 60)
          //GoDragonfly();  
        colli.enabled = agent.lifetime > 35 ;

        transform.localScale = Vector3.one * Mathf.Lerp(0.1f, 1, (agent.lifetime - 30) / 10);

        if (MotherNature.self.GetSeason() > 2 )
            if (MotherNature.self.elaspedTime % 30 > phase) GoDragonfly();
    }

    public void GoDragonfly() {
        GameObject dragon=Instantiate(MotherNature.Creatures["Dragonfly"], transform.position, transform.rotation);
        dragon.SetActive(true);
        dragon.GetComponent<Dragonfly>().agent = this.agent;
        Destroy(this.gameObject);
    }

}
