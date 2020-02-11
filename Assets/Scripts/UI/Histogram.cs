using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Histogram : MonoBehaviour
{
    public float unit = 10;

    public List<Istobarr> istobars = new List<Istobarr>();
    Dictionary<string, Istobarr> distobar = new Dictionary<string, Istobarr>();

    void Awake() {
        foreach (Istobarr i in istobars)
            distobar[i.name] = i;

    }

    // Update is called once per frame
    void Update()
    {
        Dictionary<string,CensusEntry> censimento=Censor.self.Census();
        foreach (KeyValuePair<string, Istobarr> kvp in distobar)
            kvp.Value.Setup(censimento[kvp.Key]);
    }
}
