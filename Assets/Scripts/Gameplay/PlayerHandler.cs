using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerHandler : MonoBehaviour
{
    private Transform Player1;
    private Transform Player2;
    private bool AlreadyWon = false;
    public float FloatHealthR;
    public float FloatHealthL;
    public string PlayerHandler11131;

    void FixedUpdate()
    {

        HandleHealth();
        // Find the objects called Player1 and Player2
        GameObject Player1Obj = GameObject.Find("Player1");
        GameObject Player2Obj = GameObject.Find("Player2");

        if(Player1Obj != null && Player2Obj == null && AlreadyWon == false){
            AlreadyWon = true;
            Player1Win();
            Debug.Log("Player 1 Wins!");
            NextLevel();
        }
        if(Player2Obj != null && Player1Obj == null && AlreadyWon == false){
            AlreadyWon = true;
            Player2Win();
            Debug.Log("Player 2 Wins!");
            NextLevel();
        }
        if(Player1Obj == null && Player2Obj == null && AlreadyWon == false){
            AlreadyWon = true;
            Draw();
            Debug.Log("Draw!");
            NextLevel();
        }

    }

    string LvlNum(){
        string LvlNum = Random.Range(1, 4).ToString();
        Debug.Log("Level Number: " + LvlNum);
        return LvlNum;
    }

    void NextLevel(){
        Time.timeScale = 0.20f;
        Invoke("ResetTime", 0.5f);
        Invoke("LoadNextLevel", 0.51f);
    }

    void ResetTime(){
        Time.timeScale = 1f;
    }

    void LoadNextLevel(){
        SceneManager.LoadScene("PVP" + LvlNum());
    }

    void Player1Win(){
        GameData.P1Score++;
        Debug.Log("Player 1 Score: " + GameData.P1Score);
        if(HasWon(GameData.P1Score)){
            Debug.Log("Player 1 has won the game!");
        }
        else{
            Debug.Log("Player 1 has not won the game yet!");
        }
    }

    void Player2Win(){
        GameData.P2Score++;
        Debug.Log("Player 2 Score: " + GameData.P2Score);
        if(HasWon(GameData.P2Score)){
            Debug.Log("Player 2 has won the game!");
            Reset();
        }
        else{
            Debug.Log("Player 2 has not won the game yet!");
        }
    }

    void Draw(){
        Debug.Log("Player 1 Score: " + GameData.P1Score);
        Debug.Log("Player 2 Score: " + GameData.P2Score);
    }

    bool HasWon(int Score){
        if (Score > 2.5f){
            return true;
        }
        else{
            return false;
        }
    }

    void Reset(){
        GameData.P1Score = 0;
        GameData.P2Score = 0;
    }

    void HandleHealth(){
        Image HealthR = GameObject.Find("HealthR").GetComponent<Image>();
        Image HealthL = GameObject.Find("HealthL").GetComponent<Image>();
        GameObject player1Obj = GameObject.Find("Player1");
        GameObject player2Obj = GameObject.Find("Player2");

        if (player1Obj != null) {
            FloatHealthL = player1Obj.GetComponent<TargetableObject>().health;
            //Debug.Log("Player 1 Health: " + FloatHealthL);
        } else {
            FloatHealthL = 0;
        }

        if (player2Obj != null) {
            FloatHealthR = player2Obj.GetComponent<TargetableObject>().health;
            //Debug.Log("Player 2 Health: " + FloatHealthR);
        } else {
            FloatHealthR = 0;
        }

        HealthR.fillAmount = FloatHealthR / 100f;
        HealthL.fillAmount = FloatHealthL / 100f;
    }
}
