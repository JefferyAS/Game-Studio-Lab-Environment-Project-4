using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public Vector3 direction;
    public float speed;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            player.transform.position += speed * direction * Time.deltaTime;
            camera.transform.position += speed * direction * Time.deltaTime;
        }
    }
}
