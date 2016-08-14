using UnityEngine;
using System.Collections;

public class BulletHole : MonoBehaviour
{

    public Material[] materials;
    public float life = 4.0f;
    public float size = 1.0f;

    private float destroyTime;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        destroyTime = Time.time + life;
        int chooseId = Mathf.RoundToInt(Random.Range(0, materials.Length));
        GetComponent<Renderer>().material = materials[chooseId];
        Transform parent = transform.parent;
        transform.parent = null;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Random.value * 360);
        transform.localScale = Vector3.one * (0.5f + Random.value * 0.5f) * size;
        transform.parent = parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
        //var age = Time.time - startTime;
        if (Time.time > destroyTime - 1.0f)
        {
            float fadeProgress = destroyTime - Time.time;
            Color temp = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color(temp.r, temp.g, temp.b, fadeProgress);
        }
    }
}
