using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compositespace : Idlespace {

    public List<Idlespace> spaces = new List<Idlespace>();

    public override float GetVolume() {
        float volume = 0;
        foreach (Idlespace s in spaces)
            volume += s.GetVolume();
        return volume;
    }

    public override Vector3 PickPoint() {
        if (spaces.Count == 0) return Vector3.zero;

        return spaces[Random.Range(0,spaces.Count)].PickPoint(); //bisogna fare la media pesata in base al volume
    }


}
