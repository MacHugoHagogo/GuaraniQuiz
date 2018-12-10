using System.Collections;
using System.Collections.Generic;
// Controla as cenas
using UnityEngine.SceneManagement;
using UnityEngine;


public class comandosBasicos : MonoBehaviour {


    private Scene thisScene;


    // Funcão para carregar a cena
    public void carregaCena(string nomeScena){

        //Application.LoadLevel(nomeScena);
        print("Vai carregar a cena");
        SceneManager.LoadScene(nomeScena);


    }

    public void ressetarPontos(){

        PlayerPrefs.DeleteAll();
}

}
