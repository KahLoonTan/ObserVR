using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Director : MonoBehaviour {

    public AICharacterControl character;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;

    private int currentTarget = -1;

    // Use this for initialization
    void Start () {
	
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
                    character.target = target1;
                    break;
                case 1:
                    character.target = target2;
                    break;
                case 2:
                    character.target = target3;
                    break;
                case 3:
                    character.target = target4;
                    break;
            }
        }
	}
}
