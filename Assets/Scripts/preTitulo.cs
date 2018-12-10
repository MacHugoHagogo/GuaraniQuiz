using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class preTitulo : MonoBehaviour {

    public int tempoEspera;


	// Use this for initialization
	void Start () {

        // StartCoroutine("esperar");
       // SceneManager.LoadScene("titulo");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator esperar(){

        yield return new  WaitForSeconds(tempoEspera);
        SceneManager.LoadScene("titulo");

    }
}
