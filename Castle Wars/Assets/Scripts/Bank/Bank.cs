using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    [SerializeField] TextMeshProUGUI displayBalance;
    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDistplay();
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDistplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDistplay();

        if (currentBalance < 0)
        {
            //lose the game
            ReloadScene();
        }
    }
    void UpdateDistplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
