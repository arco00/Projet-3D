using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffValeur : MonoBehaviour
{
    private GameObject[] gos;
   
    // code inutile garder pour les "archive" 
    void Update()
    {
        
        gos= GameObject.FindGameObjectsWithTag("Valeur");
        foreach (GameObject objet in gos){
            objet.GetComponent<TMP_Text>().text=objet.GetComponent<Coin>().valeur.ToString(); // bug ici
            Debug.Log("changement de tag");
            objet.GetComponent<TMP_Text>().tag="Piece";  //changement de tag pour que le text ne change plus
        } 
        
    }
}
