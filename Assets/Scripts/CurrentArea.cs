using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentArea : MonoBehaviour
{
    public GameObject notifyObject;

    Area currentArea;

    // Start is called before the first frame update
    void Start()
    {
        notifyObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Area getArea() {
        return currentArea;
    }

    public void setArea(Area area) {
        StartCoroutine(ShowRoom(area.name));

        this.currentArea = area;
    }

    IEnumerator ShowRoom(string roomName)
    {
        notifyObject.GetComponentInChildren<Text>().text = roomName;
        notifyObject.SetActive(true);
        yield return new WaitForSeconds(3);
        notifyObject.SetActive(false);
    }
}
