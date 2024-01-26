using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private UIDocument uiDocument;
    private Button StartButton;
    private Button ExitButton;
    private Button settingsButton;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        StartButton = uiDocument.rootVisualElement.Q<Button>("StartButton");
        StartButton.clicked += StartButtonOnClicked;
        ExitButton = uiDocument.rootVisualElement.Q<Button>("ExitButton");
        ExitButton.clicked += ExitButtonOnClicked;
        settingsButton = uiDocument.rootVisualElement.Q<Button>("SettingsButton");
    }

    private void StartButtonOnClicked()
    {
        Debug.Log("Click!");
        SceneManager.LoadScene("TransitionToScene");
    }

    private void ExitButtonOnClicked()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
