using UnityEngine;
using System.Collections;

public class DustCloudGenerator : MonoBehaviour
{

    public GameObject dustCloudPrefab;
    public float rate = 8.0f;
    public Material[] materials;
    public bool on = true;
    public float life = 0.3f;
    public Vector3 velocity;

    private float nextdustCloudTime;
    private float destroyTime;

    // Use this for initialization
    void Start()
    {
        destroyTime = Time.time + life;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
        if (Time.time > nextdustCloudTime)
        {
            nextdustCloudTime = Time.time + (1.0f / rate);
            GameObject newDustCloud = (GameObject)Instantiate(dustCloudPrefab, transform.position, transform.rotation);
            int materialId = Mathf.RoundToInt(Random.Range(0, materials.Length - 1));
            newDustCloud.GetComponent<Renderer>().material = materials[materialId];
            newDustCloud.GetComponent<DustCloud>().velocity = velocity;
        }
    }
}
