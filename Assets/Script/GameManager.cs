using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerPaddle;
    public Transform EnemyPaddle;
    public Ballcontroller ballController;

    public int playerScore = 0;
    public int enemyScore = 0;
    
    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;


    public int winPoints;
    //Inserir dentro do ResetGame

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        PlayerPaddle.position = new Vector3(7f, 0f, 0f);
        EnemyPaddle.position = new Vector3(-7f,0f, 0f);

        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;
        
        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);

    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }
    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }
    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vit�ria " + winner;
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}

