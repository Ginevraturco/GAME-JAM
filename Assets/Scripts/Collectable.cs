using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public static List<Collected> collecteds=new List<Collected>(); //serve ricordarli per ripercorrere la simulazione del secondo ciclo
    public int score;

    public int Collect() {
        collecteds.Add(new Collected(gameObject.name, MotherNature.self.elaspedTime));
        if (GetComponent<VectorCreature>() != null)
            GetComponent<VectorCreature>().Kill();
        else
            Destroy(this.gameObject);
        return score;
    }

}
 
public class Collected {
    public string name;
    public float time;

    public Collected(string name, float time) {
        this.name = name; this.time = time;
    }

}