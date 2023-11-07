using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private Transform Player1;
    private Transform Player2;
    private bool AlreadyWon = false;

    void Update()
    {
        // Find the objects called Player1 and Player2
        GameObject Player1Obj = GameObject.Find("Player1");
        GameObject Player2Obj = GameObject.Find("Player2");

        if(Player1Obj != null && Player2Obj == null && AlreadyWon == false){
            AlreadyWon = true;
            Player1Win();
            Debug.Log("Player 1 Wins!");
        }
        if(Player2Obj != null && Player1Obj == null && AlreadyWon == false){
            AlreadyWon = true;
            Player2Win();
            Debug.Log("Player 2 Wins!");
        }
        if(Player1Obj == null && Player2Obj == null && AlreadyWon == false){
            AlreadyWon = true;
            Draw();
            Debug.Log("Draw!");
        }

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
        if (Score > 3){
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
}
