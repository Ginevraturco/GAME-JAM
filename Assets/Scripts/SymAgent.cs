using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymAgent {

    public float lifetime=0;
    public string species;
    public VectorCreature vector;

    public static Dictionary<string, List<SymAgent>> All = new Dictionary<string, List<SymAgent>>();

    public static SymAgent Create(string specie, VectorCreature vector, float phase = 0) {
        SymAgent sym = new SymAgent(specie, vector, phase);
        if (!All.ContainsKey(specie)) All[specie] = new List<SymAgent>();
        All[specie].Add(sym);
        return sym;
    }

    private SymAgent(string species, VectorCreature vector, float phase = 0) {
        this.vector = vector;
        this.species = species;
        this.lifetime=phase;
    }

    public static string CensimentoHeadlines(char separator) {
        string s = "";
        foreach (KeyValuePair<string, List<SymAgent>> kvp in All) { 
            if (s != "") s += separator;
            s += kvp.Key;
        }
        return s;
    }

    public void Destroy() {
        All[species].Remove(this);
    }
/*
    public static string Censimento( char separator) {
        string s = "";
        foreach (KeyValuePair<string, List<SymAgent>> kvp in All) { 
            if (s != "") s += separator;
            s += kvp.Value.Count;
        }
        return s;

    }*/

    public static SymAgent PickAdult(string specie) {
        foreach (SymAgent sy in All[specie])
            if (sy.IsAdult()) return sy;
        return null;
    }

    public bool IsAdult() {
        return vector.IsAdult();
    }

}
