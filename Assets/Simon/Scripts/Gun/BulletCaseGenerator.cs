using UnityEngine;
using System.Collections;

public class BulletCaseGenerator : MonoBehaviour
{

    public GameObject bulletCasePrefab;
    public float rate = 8.0f;
    public Vector3 velocity;
    public bool on = true;

    private float nextbulletCaseTime;

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (Time.time > nextbulletCaseTime)
            {
                nextbulletCaseTime = Time.time + (1.0f / rate);
                GameObject newBulletCase = (GameObject)Instantiate(bulletCasePrefab, transform.position, transform.rotation);
                newBulletCase.GetComponent<BulletCase>().velocity = transform.TransformDirection(velocity) + Random.insideUnitSphere * 0.3f;
            }
        }
    }
}
