using UnityEngine;
using System.Collections;

public class Starable : MonoBehaviour
{

    public bool stared = false;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void StareEnter()
    {
        stared = true;
    }

    public void StareExit()
    {
        stared = false;
    }
}
