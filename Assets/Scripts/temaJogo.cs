using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Habilitar os componentes de UI no sistema.
using UnityEngine.SceneManagement;
using UnityEngine;


public class temaJogo : MonoBehaviour {

    //Declaração de variáveis



    public Button       btnPlay;
    public Text         txtNomeTema;
    public GameObject   infoTema;
    public Text         txtInfoTema;
    public GameObject   estrela1;
    public GameObject   estrela2;
    public GameObject   estrela3;

    [Header("Configuração da paginação")]
    public Button[] BtnPaginacao;
    public GameObject[] PainelTemas;

    private bool AtivarBtnPaginação;

    // public GameObject[] estrelas;


    public int idPagina;



    //Banco de Dados fake 
    public string[]     nomeTema;
    public int          numeroQuestoes;


    public int         idTema;
    public int Vidas;

    public bool requerNotaMinima;
    public int  notaMinimaNecessaria;

    private Button btnTema;


    private soundController soundController;


    // Use this for initialization
    void Start () {


        // Ativa o botão de paginação 
        ligarDesligarPaginacao();

        // recebe o botão
        btnTema = GetComponent<Button>();

       // btnPlay.interactable = false;
        infoTema.SetActive(false);
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        txtInfoTema.text = "";
       
        soundController = FindObjectOfType(typeof(soundController)) as soundController;

    }

    void ligarDesligarPaginacao() {

        if (PainelTemas.Length > 1)
        {
            AtivarBtnPaginação = true;
        }
        else
        {
            AtivarBtnPaginação = false;
        }

        for (int i = 0, BtnPaginacaoLength = BtnPaginacao.Length; i < BtnPaginacaoLength; i++)
        {
            Button b = BtnPaginacao[i];
            b.gameObject.SetActive(AtivarBtnPaginação);
        }

    }

    private bool verificaNotaMinima()
    {

      //  btnTema.interactable = false;

        if (requerNotaMinima == true)
        {

            int notaFinal = PlayerPrefs.GetInt("notaFinal" + (idTema - 1).ToString());

            if (notaFinal >= notaMinimaNecessaria)
            {

        //        btnTema.interactable = true;
                return true;

            }
            else
            {
                txtNomeTema.text = "Nao tem nota minima";
                return false;


            }

        }
        else
        {
          //  btnTema.interactable = true;
            return true;
        }
    }

        public void SelecioneTema(int i){
        // Seleciona o tema que se vai trabalhar. Recebe em "i" o tema.

        idTema = i;


        Vidas = PlayerPrefs.GetInt("vidas");
        print("Vidas =" + Vidas.ToString());
        //       print("Selecionou o tema =" + nomeTema[(idTema - 1)].ToString());

        if (Vidas <= 0)
        {

            txtNomeTema.text = "Você não tem moedas o suficiente para jogar";


        }
        else
        {

            // verificaNotaMinima nota minima para jogar.
            print("nota minima ta marcado? " + requerNotaMinima.ToString());

            if (requerNotaMinima == true)
            {

                bool verificaMinima = verificaNotaMinima();
                print("Retornou minimo ?" + verificaMinima.ToString());

                if (verificaMinima == false)
                {

                    txtNomeTema.text = "Você Tem de obter pelo menos 2 estrelas na fase anterior para poder jogar";
                }
                else
                {
                    AgoraRoda();
                }
            }

            else

            {
                    AgoraRoda();
            }
        }

    }

    private void AgoraRoda(){

        // PODE SELECONAR
        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        int acertos = PlayerPrefs.GetInt("acertos" + idTema.ToString());
        infoTema.SetActive(false);
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        int idNomeTema = idTema - 1;
        txtNomeTema.text = nomeTema[idNomeTema];
        txtInfoTema.text = "Você acertou  " + acertos.ToString() + " de " + numeroQuestoes.ToString() + " questões";
        print("Funcionou as selação");
        if (notaFinal == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 4)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }


        PlayerPrefs.SetInt("idTema", idTema);

        infoTema.SetActive(true);
        btnPlay.interactable = true;
        print("Botão Play Liberado  =" + idTema.ToString());


    }
    public void Jogar(){

        int idTemaJogar = PlayerPrefs.GetInt("idTema", idTema);

        print("Tema ao selecionar JPGAR =" + idTemaJogar.ToString());
        if(idTemaJogar > 0){
        SceneManager.LoadScene( "T"+ idTemaJogar.ToString());
        }


    }

    public void VaiParaLoja()
    {

            SceneManager.LoadScene("loja");


    }

    public void BtnPagina (int i) {

        idPagina += i;
        if (idPagina < 0) { idPagina = PainelTemas.Length - 1;  }
        else if( idPagina >= PainelTemas.Length) { idPagina = 0; }

        foreach (GameObject p in PainelTemas)
        {
            p.gameObject.SetActive(false);
        }
        PainelTemas[idPagina].SetActive(true);
        print("Pagina =" + idPagina.ToString());


    }
}
