using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;

    void Start()
    {
        NextGuess();
    }

    public void HigherButton()
    {
        min = guess + 1;
        NextGuess();
    }

    public void LowerButton()
    {
        max = guess - 1;
        NextGuess();
    }

    private void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }
}
