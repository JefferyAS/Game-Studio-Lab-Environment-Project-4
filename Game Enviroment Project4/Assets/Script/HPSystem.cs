using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public int maxHP;
    public int HP;
    public bool isEnemyShip;
    public AudioSource hitAudio;
    public AudioSource deathAudio;
    public UIScriptManager uIScript;
    public Transform restartPoint;
    public GameObject ruinPrefab;
    public ParticleSystem particle;

    public Text healthNum;
    public Text healthText;
    public Color highHPColor;
    public Color LowHPColor;
    // Start is called before the first frame update
    void Start()
    {
        ResetHP();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP<=maxHP/2) {
            particle.Play();
        }
        else {
            particle.Stop();
        }
        if (!isEnemyShip) {
            healthNum.text = HP.ToString();
            if (HP <= maxHP / 2) {
                healthText.color = LowHPColor;
                healthNum.color = LowHPColor;
            }
            else {
                healthText.color = highHPColor;
                healthNum.color = highHPColor;
            }
            
        }
    }
    public void ResetHP()
    {
        HP = maxHP;
        particle.Stop();
    }
    public void LoseHealth(int damage) {
        HP -= damage;
        if (HP <= maxHP / 2)
        {
            particle.Play();
        }
        if (!isEnemyShip) {
            hitAudio.Play();
        }
        if (HP<=0) {
            if (isEnemyShip)
            {
                Instantiate(ruinPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else {
                deathAudio.Play();
                Instantiate(ruinPrefab, transform.position, Quaternion.identity);
                uIScript.Lose();
                GameObject enemy=GameObject.Find("Enemy Spaceship(Clone)");
                if (enemy != null) {
                    Destroy(enemy);
                } 
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
