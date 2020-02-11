using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSimulatio : MonoBehaviour {

    int cursor = 0;

    void Update() {
        if (MotherNature.self.elapsedTime < MotherNature.self.windowYears * MotherNature.self.year) return;
        if (Collectable.collecteds.Count == 0) return;
        
        if (MotherNature.self.elapsedTime % (MotherNature.self.windowYears * MotherNature.self.year) > Collectable.collecteds[cursor].time) {
            Simulate(Collectable.collecteds[cursor]);
            cursor=(cursor+1)%Collectable.collecteds.Count;
        }

    }

    void Simulate(Collected colle) {
        
        Dictionary<string, CensusEntry> census = Censor.self.Census();
        string nome = colle.name;
        SymAgent sy = SymAgent.PickAdult(nome);
        if (sy == null) return;
        else {
            PlayerController.self.score+=sy.vector.gameObject.GetComponent<Collectable>().score;
            sy.vector.Kill();
        }
    }

}
