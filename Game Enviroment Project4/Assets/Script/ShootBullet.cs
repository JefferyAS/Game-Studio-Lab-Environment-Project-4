using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public float setCoolDown;
    public float startForce;
    private float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = setCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown <= 0) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                GameObject newBullet=Instantiate(bullet,transform.position,Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().AddForce(0,0,startForce);
            }
        }
        else
        {
            coolDown -= Time.deltaTime;
        }
    }
}
