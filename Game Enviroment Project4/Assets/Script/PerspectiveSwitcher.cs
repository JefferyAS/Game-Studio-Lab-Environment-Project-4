using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerspectiveSwitcher : MonoBehaviour
{
    public GameObject spaceship;
    public GameObject camera3d;
    public GameObject camera2d;
    public Transform targetPosition;
    public float switchTime = 2;
    public float backTime = 5;
    public Vector3 camePos;
    private float leftTime;
    public ConstantMovement constantMovement;
    public ExtendedFlycam extendedFlycam;
    public SpaceshipMovement spaceshipMovement;
    public ShootBullet shootBullet;

    public bool isSwitching;
    private Vector3 posDiff;
    private Vector3 rotDiff;
    private Rigidbody rigidbody;

    public bool isBack;
    public Transform backPoint;
    public Image screenSwtichImage;
    public Vector3 cameraBackPoint;
    public Quaternion cameraBackRotation;

    public bool gameFinish;
    public SceneLoader sceneLoader;
    public TextFade winText;

    public GameObject Ui2DPanel;

    // Start is called before the first frame update
    void Start()
    {
        cameraBackPoint = camera3d.transform.localPosition;
        cameraBackRotation = camera3d.transform.localRotation;
        rigidbody = spaceship.GetComponent<Rigidbody>();
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
            Ui2DPanel.SetActive(true);
            spaceship.transform.position = targetPosition.position;
            spaceship.transform.rotation = Quaternion.identity;
            camera3d.SetActive(false);
            camera3d.transform.localPosition = cameraBackPoint;
            camera3d.transform.localRotation = cameraBackRotation;
            camera2d.SetActive(true);
            camera2d.transform.position = spaceship.transform.position+camePos;
            isSwitching = false;
            constantMovement.isActive = true;
            spaceshipMovement.enabled = true;
            shootBullet.enabled = true;
            camera3d.GetComponent<Animator>().enabled = false;
            rigidbody.constraints= RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezeRotation;

        }
        if (isBack && leftTime>0) {
            Color color = screenSwtichImage.color;
            screenSwtichImage.color = new Color(color.r,color.g,color.b,color.a+1/switchTime*Time.deltaTime);
            leftTime -= Time.deltaTime;
        }
        else if(isBack &&leftTime<=0){
            if (gameFinish) {
                sceneLoader.LoadScene(2);
            }
            isBack = false;
            camera3d.SetActive(true);
            camera2d.SetActive(false);
            shootBullet.enabled = false;
            spaceshipMovement.enabled = false;
            constantMovement.isActive = false;
            extendedFlycam.enabled = true;
            spaceship.transform.position = backPoint.position;
            Color color = screenSwtichImage.color;
            screenSwtichImage.color = new Color(color.r, color.g, color.b,0);
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            
        }
    }
    public void StartSwitch() {
        leftTime = switchTime;
        isSwitching = true;
        posDiff= targetPosition.position-spaceship.transform.position;
        rotDiff = -spaceship.transform.rotation.eulerAngles;
        camera3d.GetComponent<Animator>().enabled = true;
        camera3d.GetComponent<Animator>().SetTrigger("switch");
        extendedFlycam.enabled = false;
        gameFinish = false;
    }
    public void StartBack() {
        Ui2DPanel.SetActive(false);
        leftTime = backTime;
        isBack = true;
        if (gameFinish) {
            winText.ShowText();
        }
    }
}
