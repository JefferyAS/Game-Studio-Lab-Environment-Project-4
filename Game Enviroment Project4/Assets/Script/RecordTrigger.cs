using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTrigger : MonoBehaviour
{
    public bool isStartTrigger;
    public bool isEndTrigger;
    public PlayerRecorder playerRecorder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            if (isStartTrigger) {
                playerRecorder.StartRecord();
            }
            if (isEndTrigger) {
                playerRecorder.EndRecord();
            }
        }
    }
}
