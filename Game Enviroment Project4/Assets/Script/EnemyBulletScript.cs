using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float survivedTime;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > survivedTime)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            GameObject.Find("Hit Audio Player").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.tag == "Player")
        {
            GameObject.Find("Hit Audio Player").GetComponent<AudioSource>().Play();
            other.GetComponent<HPSystem>().LoseHealth(1);
            Destroy(this.gameObject);
        }
    }
}
