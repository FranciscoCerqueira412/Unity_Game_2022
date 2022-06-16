using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour
{
    public GameObject fpsText;
    public float deltaTime;

    private void Start()
    {
        fpsText.SetActive(true);
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(fps).ToString();
    }
}