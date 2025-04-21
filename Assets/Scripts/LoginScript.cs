using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public Button connectButton;
    public InputField inputField;

    public Text errorText;

    public static string playerName;

    // Start is called before the first frame update
    void Start()
    {
        errorText.enabled = false;
        Button btn = connectButton.GetComponent<Button>();
        btn.onClick.AddListener(OnConnect);
    }

    void OnConnect()
    {
        if(!string.IsNullOrEmpty(inputField.text)) {
            playerName = inputField.text;
            SceneManager.LoadScene("SampleScene");
        }
        else {
            errorText.enabled = true;
        }
    }
}
