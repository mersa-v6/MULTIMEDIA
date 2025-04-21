using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadCarShowroom()
    {
        SceneManager.LoadScene("CarShowroom");
    }
}