using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Director : MonoBehaviour {

    public GameObject character;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;

    public AICharacterControl ai;
    private int currentTarget = -1;

    // Use this for initialization
    void Start () {
        ai = character.GetComponent<AICharacterControl>();

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            currentTarget++;
            currentTarget = currentTarget % 4;
            switch (currentTarget)
            {
                case 0:
                    ai.target = target1;
                    break;
                case 1:
                    ai.target = target2;
                    break;
                case 2:
                    ai.target = target3;
                    break;
                case 3:
                    ai.target = target4;
                    break;
            }
        }
    }
}
