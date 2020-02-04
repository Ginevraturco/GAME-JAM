using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : VectorCreature {


    SphereCollider colli;
    void Start() {
        colli = GetComponent<SphereCollider>();
        IdleInSpace("AnemonesGround");
        agent.lifetime = Random.Range(0, 2) * MotherNature.self.year + phase;
//        Debug.Log(agent.lifetime);
    }

       
      
    override protected void UpdateCreature() {
        //transform.localScale=Vector3.one*(0.1f+Mathf.Clamp(agent.lifetime,80,90)*0.1)
        transform.localScale = Vector3.one * (Mathf.Lerp(0.1f, 1, (agent.lifetime - 100) / 10));
        colli.enabled = agent.lifetime > 100 && agent.lifetime<155;
        if (agent.lifetime > 155) innerPrefab.transform.Translate(0, -1 * Time.deltaTime, 0);

        if (currentIdlespace.name == "AnemonesGround" && MotherNature.self.GetSeason() > 3 )
            if (MotherNature.self.elaspedTime % 30 > phase) IdleInSpace("TreeGround");

        if (currentIdlespace.name == "TreeGround" && MotherNature.self.GetSeason() < 1 )
            if (MotherNature.self.elaspedTime % 30 > phase) IdleInSpace("AnemonesGround");

        //animazione sprofondamento pre morte a 155

       if (agent.lifetime > 160) Kill();
    }

    

}
