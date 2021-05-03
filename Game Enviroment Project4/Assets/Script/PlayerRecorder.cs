using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    public GameObject player;

    public bool isRecording;
    public List<Vector3> recordPath;
    public List<float> recordShoot;
    public float recordInterval=0.5f;
    public int round=0;
    public GameObject enemyShip;

    private List<Vector3> currentPath;
    private List<float> currentShoot;
    private float startTime;
    private float recordTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRecording && recordTimer <= 0)
        {
            recordTimer = recordInterval;
            currentPath.Add(player.transform.position);
        }
        else if(isRecording&& recordTimer>0)
        {
            recordTimer -= Time.deltaTime;
        }
    }
    public void StartRecord() {
        isRecording = true;
        startTime = Time.time;
        currentPath = new List<Vector3>();
        currentShoot = new List<float>();
        if (round>0) {
            GameObject enemy=Instantiate(enemyShip,transform.position,Quaternion.identity);
            enemy.GetComponent<EnemyShipScript>().Setup(recordPath,recordShoot);
        }
    }
    public void RecordShooting() {
        if (currentShoot != null&& isRecording) {
            currentShoot.Add(Time.time-startTime);
        }
    }
    public void EndRecord()
    {
        isRecording = false;
        recordPath = currentPath;
        recordShoot = currentShoot;
        round += 1;
        Debug.Log(currentPath);
    }
}
