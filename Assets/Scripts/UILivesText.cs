using UnityEngine;
using TMPro;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }


    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnlivesChanged;
        tmproText.text = GameManager.Instance.Lives.ToString();
    }

    private void HandleOnlivesChanged(int livesRemaining)
    {
        tmproText.text = livesRemaining.ToString();
    }
}
