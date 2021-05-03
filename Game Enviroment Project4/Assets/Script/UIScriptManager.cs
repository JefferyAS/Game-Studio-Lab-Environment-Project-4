using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptManager : MonoBehaviour
{
    public GameObject losePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lose() {
        losePanel.SetActive(true);
        Time.timeScale = 0;
        Screen.lockCursor = false;
    }
    public void Continue() {
        losePanel.SetActive(false);
        Time.timeScale = 1;
        Screen.lockCursor = true;
    }
}
