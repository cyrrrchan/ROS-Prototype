using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTPCListener : MonoBehaviour
{

    //set your RTPCID to the name of your desired gameparameter (under GameSyncs)
    public string _rtpcID_One;
    public string _rtpcID_Two;
    public string _rtpcID_Three;
    public string _rtpcID_Four;

    private void Start()
    {
        // make sure all RTPC values are set to 0
        AkSoundEngine.SetRTPCValue(_rtpcID_One, 0.0f);
        AkSoundEngine.SetRTPCValue(_rtpcID_Two, 0.0f);
        AkSoundEngine.SetRTPCValue(_rtpcID_Three, 0.0f);
        AkSoundEngine.SetRTPCValue(_rtpcID_Four, 0.0f);
    }
    // Update is called once per frame
    void Update()
    {

        // RTPCValue_type.RTPCValue_Global
        // for whatever reason, this constant isn't exposed by name by WWise C#/Unity headers
        //int type = 1;

        // will contain the value of the RTPC parameter after the GetRTPCValue call
        //float value;

        // retrieves current value of the RTPC parameter and stores it in 'value'
        //AkSoundEngine.GetRTPCValue(rtpcID_One, gameObject, 0, out value, ref type);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AkSoundEngine.SetRTPCValue(_rtpcID_One, 100f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Two, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Three, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Four, 0.0f);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AkSoundEngine.SetRTPCValue(_rtpcID_One, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Two, 100f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Three, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Four, 0.0f);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AkSoundEngine.SetRTPCValue(_rtpcID_One, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Two, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Three, 100f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Four, 0.0f);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AkSoundEngine.SetRTPCValue(_rtpcID_One, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Two, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Three, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Four, 100f);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            AkSoundEngine.SetRTPCValue(_rtpcID_One, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Two, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Three, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcID_Four, 0.0f);
        }


        //
        // use 'value' here
        //
        // e.g. transform.localScale += Vector3( value, 0, 0 );
        // which would scale by the value of the RTPC parameter
    }
}
