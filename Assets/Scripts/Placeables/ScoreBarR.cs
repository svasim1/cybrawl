using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBarR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }
    // Update is called once per frame
    void FixedUpdate(){
        Debug.Log(GameData.P1Score);
        float Score = 12 - GameData.P1Score; 
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Score", Score);
    }
}