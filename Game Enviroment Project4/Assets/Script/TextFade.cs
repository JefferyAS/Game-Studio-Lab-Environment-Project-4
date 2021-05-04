using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public Text text;
    public bool showAtStart;
    public float fadeSpeed;
    public float survivedTime;
    private float startTime;
    private bool isShowing;
    // Start is called before the first frame update
    void Start()
    {
        if (showAtStart) {
            ShowText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing&&Time.time-startTime>survivedTime) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - fadeSpeed*Time.deltaTime);
        }
        else if (isShowing && text.color.a < 1) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + fadeSpeed*Time.deltaTime);
        }
        else if (isShowing && text.color.a <= 0) {
            isShowing = false;
        }
    }
    public void ShowText() {
        startTime = Time.time;
        isShowing = true;
    }
}
