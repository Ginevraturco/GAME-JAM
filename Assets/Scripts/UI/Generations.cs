using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generations : MonoBehaviour
{

    public GameObject campione;

    int gens = 0;
    
    void Update() {
        float onelife = MotherNature.self.characterlife * MotherNature.self.year;
        if (Mathf.FloorToInt(MotherNature.self.elapsedTime / onelife) != gens)
            CreateGen();
    }

    public void CreateGen() {
        float onelife = MotherNature.self.characterlife * MotherNature.self.year;
        gens = Mathf.FloorToInt(MotherNature.self.elapsedTime / onelife);
        GameObject o = Instantiate(campione, this.transform);
        o.SetActive(true);
        
    }

}
