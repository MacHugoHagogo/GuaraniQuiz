using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class notaFinal : MonoBehaviour {
    // BackUp ANTES de colocar as alterações do PAUL
    /* 
    public int idTema;

    public Text txtNota;
    public Text txtInfoTema;
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    public int notaFinall;
    public int acertos;

    private soundController HinoSom;


    // Use this for initialization
    void Start () {

        idTema = PlayerPrefs.GetInt("idTema");
        notaFinall = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());
        HinoSom = FindObjectOfType(typeof(soundController)) as soundController;
        estrela1.SetActive(false); 
        estrela2.SetActive(false);
        estrela3.SetActive(false);



        //   txtNota.text = notaFinall.ToString();
        txtNota.text = acertos.ToString();
        txtInfoTema.text = "Você acertou " + acertos.ToString() + " de 10 perguntas";

        if(acertos == 10){
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
            HinoSom.playHino();
        }
        else if (acertos >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (acertos >= 4)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }



    }
	
	// botão jogar novamente

    public void jogarNovamente(){

        SceneManager.LoadScene("t1");


    }


}
*/

    public int idTema;

    [Header("Configuração dos Textos")]
    public Text notaFinalTxt;
    public Text txtMsgFeedback;
    public Text txtMsgInstrução;



    [Header("Configurando Imagens (Pontuação)")]
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    [Header("Configurando dos Paineis")]
    public GameObject[] paineis;


    [Header("Definições Gerais")]
    public int notaFinall;
    public int acertos;
    public float totQuestoes;
    public float percAcerto;
    public Text txtNota;




    private soundController HinoSom;


    // Use this for initialization
    void Start()
    {


        paineis[0].SetActive(true);
        idTema = PlayerPrefs.GetInt("idTema");
        notaFinall = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());
        totQuestoes = PlayerPrefs.GetFloat("qtdQuestoes");

        //HinoSom = FindObjectOfType(typeof(soundController)) as soundController;

        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        //txtNota.text = notaFinall.ToString();
        //txtInfoTema.text = "Você acertou " + acertos.ToString() + " de 10 perguntas";

        print("Classe notaFinal - Método Start - Total acertos: " + acertos + " Total Questoes: " + totQuestoes);
        notaFinalTxt.text = acertos.ToString();

        if (totQuestoes > 0)
        {
            percAcerto = (acertos / totQuestoes);
            print("Classe notaFinal - Método Start - Percentual acertos: " + percAcerto);
            if (acertos == totQuestoes)
            {
                estrela1.SetActive(true);
                estrela2.SetActive(true);
                estrela3.SetActive(true);
                txtMsgFeedback.text = "Gooooolaaaaçooo!";
                txtMsgInstrução.text = "Bugrino Raiz! Sabe muito de quem joga muito!";
                HinoSom.playHino();
            }
            else if (percAcerto >= 0.8)
            {
                estrela1.SetActive(true);
                estrela2.SetActive(true);
                estrela3.SetActive(false);
                txtMsgFeedback.text = "Na Traaave!";
                txtMsgInstrução.text = "Siga na luta Guerreiro! " + percAcerto.ToString("F2");
            }
            else if (percAcerto >= 0.5)
            {
                estrela1.SetActive(true);
                estrela2.SetActive(false);
                estrela3.SetActive(false);
                txtMsgFeedback.text = "Z4 - Zona de Rebaixamento!";
                txtMsgInstrução.text = "Na vitória ou na derrota! Lute! O Bugre é o time da virada! " + percAcerto.ToString("F2");
            }
            else
            {
                txtMsgFeedback.text = "Que vergonha: Rebaixado!";
                txtMsgInstrução.text = "Faça o Tour Guarani, e aprenda mais sobre o Único Campeão de Campinas!";
            }
        }
    }

    // botão jogar novamente

    public void jogarNovamente()
    {

        SceneManager.LoadScene("T" + idTema.ToString());


    }


}

