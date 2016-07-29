using UnityEngine;
using System.Collections;

public class ShowSelected : MonoBehaviour {

    public Material materialIdle;
    public Material materialAlternate;

    private Selectable self;

    // Use this for initialization
    void Start () {
        self = GetComponent<Selectable>();
    }
	
	// Update is called once per frame
	void Update () {
        if (self.selected || self.connected)
        {
            GetComponent<Renderer>().material = materialAlternate;
        }
        else
        {
            GetComponent<Renderer>().material = materialIdle;
        }
    }
}
