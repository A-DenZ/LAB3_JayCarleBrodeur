using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionFin : MonoBehaviour
{
    private GameManager _gameManager;
    private Player _player;
    private Player2 _player2;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int noScene = SceneManager.GetActiveScene().buildIndex;
            if (noScene == (SceneManager.sceneCountInBuildSettings - 1))
            {
                if(SceneManager.GetActiveScene().buildIndex != 2)
                {
                    _player.FinPartie();
                }
                _player2.FinPartie();
                _gameManager.SetTempsFinal(Time.time);
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }


}
