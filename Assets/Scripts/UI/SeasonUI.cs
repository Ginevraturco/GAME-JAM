using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonUI : MonoBehaviour
{
   
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, (MotherNature.self.elapsedTime % MotherNature.self.year) / MotherNature.self.year * 360);
    }
}
