using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MenuValidator : MonoBehaviour {

    private List<string> commands = new List<string>();

    // Use this for initialization
    void Start ()
    {
        commands.Add("Star");
        commands.Add("Star");
        commands.Add("Star");
        commands.Add("Play");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (SelectionManager.Instance.ValidateSelection(commands))
        {
            Invoke("Click", 1);
            //SceneManager.LoadScene("Level");
            //SelectionManager.Instance.ClearSelection();
        }
    }

    private void Click ()
    {
        SceneManager.LoadScene("Level");
        SelectionManager.Instance.ClearSelection();
    }
}
