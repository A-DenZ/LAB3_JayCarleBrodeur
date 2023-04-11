using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    [SerializeField] private GameObject _Instructions = default;
    private bool _isInstructionOn = false;
    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(noScene + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }

    public void instructionOnOff()
    {
        if (_isInstructionOn == false)
        {
            _Instructions.SetActive(true);
            _isInstructionOn = true;
        }
        else
        {
            _Instructions.SetActive(false);
            _isInstructionOn = false;
        }


    }
}
