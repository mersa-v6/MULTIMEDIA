using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public class Area : MonoBehaviour
{
    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        
        Debug.Log(box);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);

        CurrentArea currentObject = other.gameObject.GetComponent<CurrentArea>();

        //Debug.Log(currentObject);

        if(currentObject != null) {
            Debug.Log("Entered on " + box.name);

            currentObject.setArea(this);
  
            // Agora.io Implimentation
            IRtcEngine mRtcEngine = IRtcEngine.GetEngine(AgoraInterfaceScript.appId);
            var channelName = box.name;
            mRtcEngine.LeaveChannel();
            mRtcEngine.JoinChannel(channelName, "extra", 0); // join the channel with given match name
            Debug.Log("joining channel:" + channelName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
