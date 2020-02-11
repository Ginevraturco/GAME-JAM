using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Linq;
using UnityEngine.UI;

public class Pergamena : MonoBehaviour {

    public TMP_Text testo;
    public Image perga;
    public TextAsset source;
    Dictionary<string, string> testi = new Dictionary<string, string>();

    void Start()
    {
        XDocument doc = XDocument.Parse(source.text);
        foreach (XElement xele in doc.Root.Descendants())
            testi[xele.Attribute("name").Value] = xele.Value;
        perga.enabled = true;
        gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    public void Show(string name) {
        gameObject.SetActive(true);
        testo.text = testi[name];
    }


}
