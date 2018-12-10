using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class responder : MonoBehaviour
{

    private int idTema;

    [Header("Respostas")]

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;
    private int Vidas;

    [Header("Botões de resposta")]

    public Button[]     respostas;
    public Button       btnProxima;
    public Color        corAcerto, corErro;
   


   // public GameObject CertoA;
    //public GameObject ErradoA;

    [Header("Barra")]

    public GameObject   barraProgresso;
    public int          qtdrespondida = 0;

    [Header("Opções de Jogo")]

    public bool     perguntasAleatorias;
    public bool     jogarComTempo;
    public float    tempoResponder;
    public bool     mostrarCorreta;
    public int      qtdPiscar;
    public bool     podeClicar = true;

    [Header("Configuração das Perguntas")]

    public string[] perguntas;      // ARmazena todas as perguntas
    public string[] AlternativaA;   // Armezena todas as alterantivas A
    public string[] AlternativaB;   // Armezena todas as alterantivas B
    public string[] AlternativaC;   // Armezena todas as alterantivas C
    public string[] AlternativaD;   // Armezena todas as alterantivas D
    public string[] corretas;       // Armezena todas as alterantivas corretas



    private int idPergunta;

    public float acertos;
    public float qtdQuestoes;
    public float media;
    public int notaFinal;
    public int idBtnCorreto;

    private soundController soundController;

    // Use this for initialization
    void Start()
    {
        soundController = FindObjectOfType(typeof(soundController)) as soundController;
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        qtdQuestoes = perguntas.Length;
        // print(qtdQuestoes);
        pergunta.text = perguntas[idPergunta];
        respostaA.text = AlternativaA[idPergunta];
        respostaB.text = AlternativaB[idPergunta];
        respostaC.text = AlternativaC[idPergunta];
        respostaD.text = AlternativaD[idPergunta];
        progressoBarra();
        respondeu();
        btnProxima.interactable = true;
        //  btnVoltar.interactable = false;

    }

    public void resposta(string alternativa)
    {

        // verifica se pode aceitar a resposta
        if(podeClicar==false)
        {
            return;
        }
       
        // Coloca impossibilitado de responder até clicr a próxima
        podeClicar = false;

        // verifica se escolheo a alternativa certa.
        if (alternativa == "A")
        {
            if (AlternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 0;
                soundController.playAcerto();
             //   print("Parou no A");
            }
            else
            {
                soundController.playErro();
                print("PDeu RUIM !!");
            }

        }
        else if (alternativa == "B")
        {
            if (AlternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 1;
                soundController.playAcerto();
                // print("Parou no B");

            }
            else
            {
                soundController.playErro();
                print("PDeu RUIM !!");
            }
        }
        else if (alternativa == "C")
        {
            if (AlternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 2;
                soundController.playAcerto();
                //   print("Parou no C");

            }
            else
            {
                soundController.playErro();
                print("PDeu RUIM !!");
            }
        }
        else if (alternativa == "D")
        {
            if (AlternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 3;
                soundController.playAcerto();
                //    print("Parou no D");

            } else {
                soundController.playErro();
                print("PDeu RUIM !!");
            }
        }
        qtdrespondida += 1;


        // marcar a resposta certa

        if (AlternativaA[idPergunta] == corretas[idPergunta]){
            idBtnCorreto = 0;
            print("Parou no A !!");
        }
        else if (AlternativaB[idPergunta] == corretas[idPergunta])
        {
            idBtnCorreto = 1;
            print("Parou no B !!");
        }
        else if(AlternativaC[idPergunta] == corretas[idPergunta])
        {
            idBtnCorreto = 2;
            print("Parou no C !!");
        }
        else if(AlternativaD[idPergunta] == corretas[idPergunta])
        {
            idBtnCorreto = 3;
            print("Parou no D !!");
        } 


        //Verifica se é para pintar as respostas Certas e erradas
        if (mostrarCorreta== true){

            // Coloca todos os botões com acor de erro.
            foreach(Button i in respostas){

                i.image.color = corErro;
            }
            //  respostas[idBtnCorreto].image.color = corAcerto;
            respostas[idBtnCorreto].image.color = corAcerto;


            // StartCoroutine("MopstrarAlterantivaCorreta");
        }


      //  proximaPergunta();

    }

    public void proximaPergunta(){

        idPergunta++;
        podeClicar = true;

           for (int i = 0; i < 4; i++){

            respostas[i].image.color = Color.white;
        }
        print("IdPergunta para calcular =" + idPergunta.ToString());

        if (idPergunta < perguntas.Length) {
      //  if (idPergunta >= qtdQuestoes){

            // calcula a media
            media = 10 * (acertos / qtdQuestoes);

            // arredonda a nota
            notaFinal = Mathf.RoundToInt(media);

            //verifica se a nota é maior que a anterior

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())){

                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int) acertos);

      //      }
                print("Nota Final =" + notaFinal.ToString());
      //      PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
      //      PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
      //      SceneManager.LoadScene("notaFinal");

        }

            pergunta.text = perguntas[idPergunta];
            respostaA.text = AlternativaA[idPergunta];
            respostaB.text = AlternativaB[idPergunta];
            respostaC.text = AlternativaC[idPergunta];
            respostaD.text = AlternativaD[idPergunta];
            progressoBarra();
            respondeu();
        }
        else {

            progressoBarra();

        //    btnProxima.interactable = false;
        //    btnAcabou.interactable = true;
        //    podeClicar = false;
            respondeu();
            print("Acabou as Questões");
            //verifica se a nota é maior que a anterior
            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {

                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);

            }
            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
            Vidas = PlayerPrefs.GetInt("vidas");
            PlayerPrefs.SetInt("vidas", Vidas = Vidas - 1);
            SceneManager.LoadScene("notaFinal");
        }

    }

    public void progressoBarra(){

        float percRespondido =((qtdrespondida/ qtdQuestoes));
      //  float valorY = 0.5f;

        barraProgresso.transform.localScale = new Vector3(percRespondido, 0.5f, 1);

        print("Percentual de progresso :" + percRespondido.ToString());

    }

    public void voltaParaTema(){

        PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
        PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);

        SceneManager.LoadScene("notaFinal");
    }

    public void respondeu(){

        infoRespostas.text = "Respondeu " + (idPergunta).ToString() + " de " + qtdQuestoes.ToString();

    }


    IEnumerator  MopstrarAlterantivaCorreta(){

        for (int i = 0; i < qtdPiscar; i++){

            respostas[idBtnCorreto].image.color = corAcerto;
            yield return new WaitForSeconds(0.2f);
            respostas[idBtnCorreto].image.color = Color.white;
            yield return new WaitForSeconds(0.2f);


        }

    }

}