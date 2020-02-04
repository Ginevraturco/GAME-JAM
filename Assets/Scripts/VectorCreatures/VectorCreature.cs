using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCreature : MonoBehaviour {

    public SymAgent agent;
    public float speed;
    protected Idlespace currentIdlespace;
    Vector3 targetpoint;
    protected float phase;
    public GameObject innerPrefab;

    public virtual void RandomAge() { }

    void Awake() {
        phase = Random.Range(0, 7); 
    }

    protected virtual void UpdateCreature() {
    }

    
    void Update() {
        if (agent == null)  Debug.Log(name);

        agent.lifetime += Time.deltaTime * MotherNature.self.timescale;
        if (currentIdlespace!=null) {
            if ((targetpoint - transform.position).magnitude < 0.3f)
                targetpoint = currentIdlespace.PickPoint();
            Vector3 delta = targetpoint - transform.position;
            transform.Translate((targetpoint - transform.position).normalized * speed * MotherNature.self.timescale);
            if (innerPrefab!=null) innerPrefab.transform.rotation = Quaternion.LookRotation(delta, Vector3.up);
        }
        UpdateCreature();
    }

    public void IdleInSpace(Idlespace space) {
        currentIdlespace = space;
        targetpoint = space.PickPoint();
    }

    public void IdleInSpace(string s) {
        IdleInSpace(MotherNature.Environments[s]);
    }

    public void Kill() {
        agent.Destroy();
        Destroy(this.gameObject);
    }

}

