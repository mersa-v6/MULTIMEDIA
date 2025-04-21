using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabel : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    GameObject label;

    public string name;

    public TextMesh tm;

    // Start is called before the first frame update

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        label = new GameObject("player_label");
        label.layer = 0;

        label.transform.rotation = Camera.main.transform.rotation;
        tm = label.AddComponent<TextMesh>();
        tm.text = name;
        tm.color = new Color(0.1f, 0.1f, 0.1f);
        tm.fontStyle = FontStyle.Bold;
        tm.alignment = TextAlignment.Center;
        tm.anchor = TextAnchor.MiddleCenter;
        tm.characterSize = 0.065f;
        tm.fontSize = 60;
    }

    // Update is called once per frame
    void Update()
    {
        label.transform.position = myRigidbody.position + Vector2.up * 1f;
    }
}
