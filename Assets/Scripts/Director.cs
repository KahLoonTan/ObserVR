using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.Characters.ThirdPerson;

public class Director : MonoBehaviour {

    public GameObject character;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public GameObject orb;
    public GameObject fireball;
    public Material materialAttack;

    //private AICharacterControl ai;
    private AISimonControl ai;
    private int currentTarget = -1;
    private List<string> commands = new List<string>();

    // Use this for initialization
    void Start () {
        //ai = character.GetComponent<AICharacterControl>();
        ai = character.GetComponent<AISimonControl>();
        commands.Add("Inspect");
        commands.Add("Screen");
    }
	
	// Update is called once per frame
	void Update () {
	    if (SelectionManager.Instance.ValidateSelection(commands))
        {
            ai.target = SelectionManager.Instance.nodes.Last().transform;
            //SelectionManager.Instance.ClearSelection();
        }
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
        if (Input.GetMouseButtonDown(1))
        {
            fireball.SetActive(true);
            orb.GetComponent<Renderer>().material = materialAttack;
        }
    }
}
