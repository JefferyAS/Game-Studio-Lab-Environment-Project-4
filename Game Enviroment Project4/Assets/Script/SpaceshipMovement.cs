using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    public float forwardForce;
    public float rightForce;

    public AudioSource aceAudio;
    public AudioSource deceAudio;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        particle1.Play();
        particle2.Play();
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow)) {
            if (!aceAudio.isPlaying) {
                aceAudio.Play();
            }
            rigidbody.AddForce(new Vector3(0,0, forwardForce) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!deceAudio.isPlaying)
            {
                deceAudio.Play();
            }
            aceAudio.Stop();
            rigidbody.AddForce(new Vector3(0, 0, -forwardForce) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector3(rightForce, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector3(-rightForce, 0, 0) * Time.deltaTime);
        }
    }
    
}
