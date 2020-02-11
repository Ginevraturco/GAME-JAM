using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifetime : MonoBehaviour {

    Image circle;
    public GameObject barretta;

    void Start() {
        circle=GetComponent<Image>();

        for (int i = 0; i < MotherNature.self.characterlife; i++) {
            GameObject barranew= Instantiate(barretta, this.transform);
            (barranew.transform as RectTransform).anchoredPosition = Vector2.zero;
            barranew.transform.Rotate(0, 0, 360 / MotherNature.self.characterlife * i);
        }
    }

    // Update is called once per frame
    void Update() {
        float onelife = MotherNature.self.characterlife * MotherNature.self.year;
        circle.fillAmount = MotherNature.self.elapsedTime % onelife / onelife;
    }
}
