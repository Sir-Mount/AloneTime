using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour
{

    private UIDocument uiDocument;
    private Button playAgainButton;
    private Button mainMenuButton;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        playAgainButton = uiDocument.rootVisualElement.Q<Button>("playAgainButton");
        playAgainButton.clicked += PlayAgainButtonOnClicked;
        mainMenuButton = uiDocument.rootVisualElement.Q<Button>("mainMenuButton");
        mainMenuButton.clicked += ExitButtonOnClicked;
    }

    private void PlayAgainButtonOnClicked()
    {
        SceneManager.LoadScene("TransitionToScene");
    }

    private void ExitButtonOnClicked()
    {
        SceneManager.LoadScene("UI Scene");
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
