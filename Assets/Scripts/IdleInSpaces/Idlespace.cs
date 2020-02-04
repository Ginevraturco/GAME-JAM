using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idlespace : MonoBehaviour {

    public virtual Vector3 PickPoint() {
        return Vector3.zero;
    }

    public virtual float GetVolume(){
        return 0;
    }

}
