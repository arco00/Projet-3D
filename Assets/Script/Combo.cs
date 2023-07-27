using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public TMP_Text scoreAff;
    public GameObject barreCombo;
    public Configuration config;
    
    void Start() { 
    scoreAff.text="Combo:"+Manager.instance.combo;  
    }
    void Update() {
        //maj du score
        scoreAff.text="Combo:"+Manager.instance.combo; 
        //faire de la barre un timer
        if(Manager.instance.combo!=0){
            barreCombo.GetComponent<Image>().fillAmount=1-Manager.instance.timeCombo/config.comboExpire;
        }
        else{
            barreCombo.GetComponent<Image>().fillAmount=1;
        }
    }
}
