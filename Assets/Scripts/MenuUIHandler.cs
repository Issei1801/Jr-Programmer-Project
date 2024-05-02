using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD

#if UNITY_EDITOR
using UnityEditor;
#endif

=======
#if UNITY_EDITOR
using UnityEditor;
#endif
>>>>>>> 591d2006a546d95afd8c211e91a9ab12f86c704e

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public bool UNITY_EDITOR { get; private set; }

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

        MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    if (UNITY_EDITOR)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit(); // original code to quit Unity player
        }
    }
}
