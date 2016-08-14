using UnityEngine;
using System.Collections;

public class BulletTraceGenerator : MonoBehaviour
{

    public GameObject bulletTracePrefab;
    public float rate = 8.0f;
    public Vector3 velocity;
    public bool on = false;
    public float accuracy = 1.0f; //1.0 to 0.0;

    private float nextbulletTraceTime;

    // Update is called once per frame
    void Update()
    {
        accuracy = Mathf.Clamp01(accuracy);
        if (on)
        {
            if (Time.time > nextbulletTraceTime)
            {
                rate = Mathf.Max(rate, 1.0f);
                nextbulletTraceTime = Time.time + (1.0f / rate);
                GameObject newBulletTrace = (GameObject)Instantiate(bulletTracePrefab, transform.position, transform.rotation);
                Vector3 bulletVelocity = newBulletTrace.GetComponent<BulletTrace>().velocity;
                float badAim = (1 - accuracy);
                badAim *= newBulletTrace.GetComponent<BulletTrace>().bulletSpeed * 0.05f;
                bulletVelocity += newBulletTrace.transform.right * Random.Range(-badAim, badAim);
                bulletVelocity += newBulletTrace.transform.up * Random.Range(-badAim, badAim);
                newBulletTrace.GetComponent<BulletTrace>().velocity = bulletVelocity;
            }
        }
    }
}
