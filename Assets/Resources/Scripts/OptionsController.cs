using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsPanel;

    [SerializeField]
    private int indexLevel = 1;
    public void TurnOnOffPanel()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadFurniture()
    {
        SceneManager.LoadScene(indexLevel);
    }

}
