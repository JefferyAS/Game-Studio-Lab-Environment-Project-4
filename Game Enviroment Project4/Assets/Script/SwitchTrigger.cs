using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public PerspectiveSwitcher perspectiveSwitcher;
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
        if (other.tag == "Player" && perspectiveSwitcher.isSwitching == false) {
            perspectiveSwitcher.StartSwitch();
        }
    }
}
