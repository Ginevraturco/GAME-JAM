using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Simulo : MonoBehaviour
{

    Dictionary<string, Simuspecie> dictio = new Dictionary<string, Simuspecie>();

      List<Simuspecie> simus = new List<Simuspecie>() {
            new Simuspecie("Tree", 9, "Bird",         0.09f, 3, 3),
            new Simuspecie("Bird", 9, "Algae",        0.07f, 3, 1),
            new Simuspecie("Algae", 9, "Dragonfly",   0.09f, 3, 0),
            new Simuspecie("Dragonfly", 12, "Anemone", 0.18f, 2, 2),
            new Simuspecie("Anemone", 9, "Walker",    0.22f, 3, 3),
            new Simuspecie("Walker", 12, "Tree",       0.11f, 2, 0)
        };

    void Start() {

        foreach (Simuspecie s in simus)
            dictio.Add(s.name, s);


        for (int i = 0; i < 40; i++)
            for (int j = 0; j < 4; j++) { 
                Process(j);
                Collect();
            }
        
        System.IO.File.WriteAllText("Popolazioni_"+System.DateTime.Now.ToString("HH_mm_ss")+".txt", stri);
    }

    public void Process(int season) {

        foreach (Simuspecie s in simus)
            if (s.season == season)
                dictio[s.controls].PushChildren(Mathf.Max(0,Mathf.RoundToInt(s.factor * s.Adults() * dictio[s.controls].Adults())));

    }

    string stri = "";

    public void Collect() {
        foreach (Simuspecie s in simus)
            stri += s.gens.Sum().ToString()+"\t"+"\t"+"\t";
        stri += "\r\n";  
    }

}

public class Simuspecie {
    public string name;
    public int pop0;
    public string controls;
    public float factor;
    public int lifespan;
    public int season;

    public int[] gens;

    public Simuspecie(string name, int pop0, string controls, float factor, int lifespan, int season) {
        this.name=name;
        this.pop0 = pop0;
        this.controls = controls;
        this.factor = factor;
        this.lifespan = lifespan;
        this.season = season;

        gens = new int[lifespan];
        for (int i = 0; i < lifespan; i++)
            gens[i] = pop0 / lifespan;
    }


    public int Adults() {
        int sum = 0;
        for (int i = 1; i < gens.Length; i++)
            sum += gens[i];
        return sum;
    }

    public void PushChildren(int children) {
        for (int i = gens.Length - 1; i > 0; i--)
            gens[i] = gens[i - 1];
        gens[0] = children;
    }

}