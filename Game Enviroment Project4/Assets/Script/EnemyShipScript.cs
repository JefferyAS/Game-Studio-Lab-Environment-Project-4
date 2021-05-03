using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    public GameObject bullet;
    public float startForce;
    public List<Vector3> path;
    public List<float> shot;
    public float startTime;
    public float intervel = 0.5f;

    private int pathIndex;
    private int shotIndex;

    private float pathTimer;
    private Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotIndex < shot.Count&&(Time.time-startTime)>=shot[shotIndex]) {
            EnemyShoot();
            shotIndex += 1;
        }
        if (pathTimer <= 0 && pathIndex + 1 < path.Count)
        {
            pathIndex += 1;
            pathTimer = intervel;
            speed = (path[pathIndex] - transform.position) / intervel;
        }
        else {
            pathTimer -= Time.deltaTime;
        }
        transform.position += speed * Time.deltaTime;
    }
    public void EnemyShoot() {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(0, 0, startForce);
    }
    public void Setup(List<Vector3> path, List<float> shot) {
        this.path = path;
        this.shot = shot;
        startTime = Time.time;
        transform.position = path[0];
        pathIndex = 1;
        speed = (path[pathIndex] - transform.position) / intervel;
        pathTimer = intervel;
        shotIndex = 0;
        
    }
}
