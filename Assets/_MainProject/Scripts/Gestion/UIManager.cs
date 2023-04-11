using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    private int indexScene;
    private bool _enPause;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;

        _gameManager = FindObjectOfType<GameManager>();
        _txtAccrochages.text = "Accrochages : " + _gameManager.GetPointage();
        Time.timeScale = 1;
        _enPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (indexScene != 0) 
        { 
        float temps = Time.time - _gameManager.GetTempsDepart();
        _txtTemps.text = "Temps : " + temps.ToString("f2");
        GestionPause();
        }
    }


    public void ChangerPointage(int p_pointage)
    {
        _txtAccrochages.text = "Accrochages : " + p_pointage.ToString();
    }


    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }




}
