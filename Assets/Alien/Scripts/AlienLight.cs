using UnityEngine;
using System.Collections;

public class AlienLight : MonoBehaviour {

    public bool switchedOn = true;
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
    
	// Update is called once per frame
	void Update () {
        light1.SetActive(switchedOn);
        light2.SetActive(switchedOn);
        light3.SetActive(switchedOn);
    }
}
