using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using System;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        Observable.Timer(TimeSpan.FromSeconds(1f)).TakeUntilDisable(gameObject).Subscribe(_ => 
        {
            SceneManager.LoadScene("Game");
        });
    }
}
