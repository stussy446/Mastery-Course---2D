using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lives { get; private set; }

    private int coins;

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
        
    }

    internal void KillPlayer()
    {
        Lives--;

        if (OnLivesChanged != null)
        {
            OnLivesChanged(Lives);  
        }

        if (Lives <= 0)
        {
            RestartGame();
        }

    }


    internal void AddCoin()
    {
        coins++;
        OnCoinsChanged?.Invoke(coins);
    }


    private void RestartGame()
    {
        Lives = 3;
        coins = 0;

        OnCoinsChanged?.Invoke(coins);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
