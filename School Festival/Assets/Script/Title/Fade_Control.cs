using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade_Control : MonoBehaviour
{
    public GameObject fade;

    public int until_fade;
    void Start()
    {
        fade.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown((KeyCode.Return)))
        {
            Invoke("FadeStart", until_fade);
        }
    }

    void FadeStart()
    {
        fade.gameObject.SetActive(true);
        Invoke("Next", 2);
    }

    void Next()
    {
        SceneManager.LoadScene("Ingame");
    }
}
