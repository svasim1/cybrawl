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
        Debug.Log(GameData.P2Score);
        float Score = 11 - GameData.P2Score; 
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Score", Score);
    }
}
