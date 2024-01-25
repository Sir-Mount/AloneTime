using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransInteractive : InteractableBase
{
    public string sceneName;

    public override void Activate() {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
