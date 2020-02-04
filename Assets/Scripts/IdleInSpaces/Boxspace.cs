using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxspace : Idlespace {

    public override float GetVolume() {
        return transform.lossyScale.x*transform.lossyScale.y*transform.lossyScale.z;
    }

    public override Vector3 PickPoint() {
        Vector3 randoscale = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        randoscale.Scale(transform.lossyScale);
        return transform.position + randoscale;
    }
}
