using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;



public class OptionSon : MonoBehaviour
{

    public Slider slider ;
    public AudioMixer Mixer ;
    public string Group;

 
    public void  changementVol(){
        // le +0.1 est la pour lutter au probleme du log lorsque on est à 0 (log(0) n'existe pas) , mit directemnt dans le jeu
        Mixer.SetFloat(Group,Mathf.Log10(slider.value)*20);
    }
}

