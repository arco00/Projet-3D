using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource musicMenu;
    public AudioSource musicJeu;
        void Update()
    {
        if (SceneManager.GetActiveScene().name=="Jeu" && musicMenu.isPlaying){
            Debug.Log("lancer music jeu");
            musicJeu.Play();
            musicMenu.Stop();
        }

        //je remte le "gestctive scene " pour pouvoir mettre le isplaing au dessu et limité le nombre d'action 
        else if (SceneManager.GetActiveScene().name!="Jeu" && musicJeu.isPlaying){
            Debug.Log("lancer music menu");
            musicJeu.Stop();
            musicMenu.Play();
        }     
    }
}
