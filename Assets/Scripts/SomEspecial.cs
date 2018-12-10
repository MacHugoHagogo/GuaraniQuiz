using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomEspecial : MonoBehaviour {



    private AudioSource AudioSpecial;
    public AudioClip hinoTime;


	// Use this for initialization
	void Start () {

        AudioSpecial = GetComponent<AudioSource>();


    }
	
    public void TocaOHino(){

        AudioSpecial.PlayOneShot(hinoTime);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
