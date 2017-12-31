using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breathMeter : MonoBehaviour {

    public Image meterImage;

    private bool breathing = false;
    public int segments;
    public float time;
    private float meterFilled = 1f;
    private float segmentSize;
 
	// Use this for initialization
	void Start () {
        meterImage.fillAmount = meterFilled;
        segmentSize = 1f / segments;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            breathing = true;
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            breathing = false;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && breathing == true)
        {
            meterImage.fillAmount -= segmentSize;
        }

        if (breathing == false && meterImage.fillAmount != 1f)
        {
            meterImage.fillAmount += Time.deltaTime / time;
        }
    }
}
