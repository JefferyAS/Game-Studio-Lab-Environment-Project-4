using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public int maxHP;
    public int HP;
    public bool isEnemyShip;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            LoseHealth(1);
        }
    }
}
