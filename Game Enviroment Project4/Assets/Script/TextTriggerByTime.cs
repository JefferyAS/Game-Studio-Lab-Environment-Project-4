using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTriggerByTime : MonoBehaviour
{
    public TextFade text1;
    public TextFade text2;
    public TextFade text3;
    public float time1;
    public float time2;
    public float time3;
    private bool isText1;
    private bool isText2;
    private bool isText3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>time1&&!isText1) {
            text1.ShowText();
            isText1 = true;
        }
        if (Time.time > time2 && !isText2)
        {
            text2.ShowText();
            isText2 = true;
        }
        if (Time.time > time3 && !isText3)
        {
            text3.ShowText();
            isText3 = true;
            Screen.lockCursor = false;
        }
    }
}
