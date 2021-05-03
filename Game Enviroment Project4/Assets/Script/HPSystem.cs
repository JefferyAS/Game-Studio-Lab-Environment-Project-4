using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public int maxHP;
    public int HP;
    public bool isEnemyShip;
    public AudioSource hitAudio;
    public AudioSource deathAudio;
    public UIScriptManager uIScript;
    public Transform restartPoint;
    // Start is called before the first frame update
    void Start()
    {
        ResetHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetHP()
    {
        HP = maxHP;
    }
    public void LoseHealth(int damage) {
        HP -= damage;
        if (!isEnemyShip) {
            hitAudio.Play();
        }
        if (HP<=0) {
            deathAudio.Play();
            if (isEnemyShip)
            {
                Destroy(this.gameObject);
            }
            else {
                uIScript.Lose();
                ResetHP();
                transform.position = restartPoint.position;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            LoseHealth(1);
        }
    }
}
