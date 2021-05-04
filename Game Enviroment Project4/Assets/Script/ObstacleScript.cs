using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player") {
            //create particle effect
            ObstacleDestroy();
        }
    }
    public void ObstacleDestroy() {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
