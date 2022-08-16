using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += PlayCoinDing;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinsChanged -= PlayCoinDing;
    }

    private void PlayCoinDing(int coins)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
