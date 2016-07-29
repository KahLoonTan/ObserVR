using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SelectionManager : Singleton<SelectionManager>
{
    public List<GameObject> nodes = new List<GameObject>();

    private List<GameObject> lines = new List<GameObject>();

    // Use this for initialization
    protected override void SingletonAwake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nodes.Any() && !nodes.Last().GetComponent<Selectable>().selected)
        {
            ClearSelection();
        }
    }

    public void AddToSelection(GameObject obj)
    {
        obj.GetComponent<Selectable>().connected = true;
        nodes.Add(obj);
        AddConnectionLine();
    }

    public void ClearSelection()
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

    private void AddConnectionLine()
    {
        if (nodes.Count > 1)
        {
            GameObject startNode = nodes[nodes.Count - 2];
            GameObject endNode = nodes[nodes.Count - 1];
            
            GameObject connectionLine = new GameObject();
            connectionLine.name = "Line (" + startNode.name + ") to (" + endNode.name + ")";
            connectionLine.transform.position = startNode.transform.position;
            connectionLine.AddComponent<LineRenderer>();
            LineRenderer lr = connectionLine.GetComponent<LineRenderer>();
            //connectionLine.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
            //connectionLine.SetColors(color, color);
            lr.SetWidth(0.1f, 0.1f);
            lr.SetPosition(0, startNode.transform.position);
            lr.SetPosition(1, endNode.transform.position);
            lines.Add(connectionLine);
        }
    }
}
