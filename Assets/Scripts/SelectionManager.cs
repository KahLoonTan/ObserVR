using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SelectionManager : Singleton<SelectionManager>
{
    public GameObject lineType;
    public List<GameObject> nodes = new List<GameObject>();

    private List<GameObject> lines = new List<GameObject>();

    // Use this for initialization
    protected override void SingletonAwake ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (nodes.Any() && !nodes.Last().GetComponent<Selectable>().selected)
        {
            ClearSelection();
        }
    }

    public void AddToSelection (GameObject obj)
    {
        obj.GetComponent<Selectable>().connected = true;
        nodes.Add(obj);
        CreateConnectionLine();
    }

    public void ClearSelection ()
    {
        foreach(GameObject sel in nodes)
        {
            sel.GetComponent<Selectable>().connected = false;
        }
        nodes.Clear();

        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
        lines.Clear();
    }

    public bool ValidateSelection (List<string> a)
    {
        if (a.Count > nodes.Count) return false;
        for (int i = 0; i < a.Count; ++i)
        {
            if (nodes[i].name != a[i])
                return false;
        }
        return true;
    }

    private void CreateConnectionLine ()
    {
        if (nodes.Count > 1)
        {
            GameObject startNode = nodes[nodes.Count - 2];
            GameObject endNode = nodes[nodes.Count - 1];
            
            GameObject connectionLine = Instantiate(lineType);
            connectionLine.name = "Line (" + startNode.name + ") to (" + endNode.name + ")";
            connectionLine.transform.parent = gameObject.transform;
            connectionLine.transform.position = startNode.transform.position;

            connectionLine.GetComponent<ConnectionLine>().start = startNode;
            connectionLine.GetComponent<ConnectionLine>().end = endNode;
            lines.Add(connectionLine);
        }
    }
}
