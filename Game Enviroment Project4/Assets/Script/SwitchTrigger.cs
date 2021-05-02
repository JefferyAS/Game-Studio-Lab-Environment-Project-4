using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public PerspectiveSwitcher perspectiveSwitcher;
    public bool trigger3dTo2d;
    public bool trigger2dTo3d;
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
        if (trigger3dTo2d) {
            if (other.tag == "Player" && perspectiveSwitcher.isSwitching == false)
            {
                perspectiveSwitcher.StartSwitch();
            }
        }
        if (trigger2dTo3d) {
            if (other.tag == "Player" && perspectiveSwitcher.isBack == false)
            {
                perspectiveSwitcher.StartBack();
            }
        }
    }
}
