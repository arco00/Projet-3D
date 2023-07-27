using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreAff;
    void Start() { 
    scoreAff.text=""+Saver.instance.score;  
    }
    void Update() {
        //maj du score
        scoreAff.text=""+Saver.instance.score; 
    }
}
