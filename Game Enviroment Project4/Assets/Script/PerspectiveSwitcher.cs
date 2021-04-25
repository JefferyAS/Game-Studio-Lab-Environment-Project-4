using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveSwitcher : MonoBehaviour
{
    public GameObject spaceship;
    public GameObject camera3d;
    public GameObject camera2d;
    public Vector3 targetPosition;
    public float switchTime = 2;
    public Vector3 camePos;
    private float leftTime;
    public ConstantMovement constantMovement;
    public ExtendedFlycam extendedFlycam;
    public SpaceshipMovement spaceshipMovement;
    public ShootBullet shootBullet;

    public bool isSwitching;
    private Vector3 posDiff;
    private Vector3 rotDiff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwitching && leftTime > 0) {
            spaceship.transform.position += posDiff / switchTime * Time.deltaTime;
            spaceship.transform.Rotate(rotDiff / switchTime * Time.deltaTime);
            leftTime -= Time.deltaTime;
        }
        else if(isSwitching && leftTime <= 0)
        {
            spaceship.transform.position = targetPosition;
            spaceship.transform.rotation = Quaternion.identity;
            camera3d.SetActive(false);
            camera2d.SetActive(true);
            camera2d.transform.position = spaceship.transform.position+camePos;
            isSwitching = false;
            constantMovement.isActive = true;
            spaceshipMovement.enabled = true;
            shootBullet.enabled = true;
        }
    }
    public void StartSwitch() {
        leftTime = switchTime;
        isSwitching = true;
        posDiff= targetPosition-spaceship.transform.position;
        rotDiff = -spaceship.transform.rotation.eulerAngles;
        camera3d.GetComponent<Animator>().SetTrigger("switch");
        extendedFlycam.enabled = false;
    }
}
