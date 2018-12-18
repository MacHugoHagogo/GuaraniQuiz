using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class responder : MonoBehaviour
{
    // BackUp ANTES de colocar as alteraões do PAUL
    /*
    //  private LeDadosSeco LeDadosSeco;

    private int idTema;

    [Header("Firebase")]


    public int QtdPerguntas;


    [Header("Respostas")]

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostasTxt;
    private int Vidas;

    [Header("Botões de resposta")]
    public Button[] respostas;
    public Button btnProxima;
    public Color corAcerto, corErro;



    // public GameObject CertoA;
    //public GameObject ErradoA;

    [Header("Barra")]
    public GameObject barraProgresso;
    public GameObject barraTempo;
    public int qtdRespondida = 0;

    [Header("Opções de Jogo")]
    public bool perguntasAleatorias;
    public bool jogarComTempo;
    public float tempoResponder;
    public bool mostrarCorreta;
    public int qtdPiscar;
    public bool podeClicar = true;

    /*
    [Header("Configuração das Perguntas")]

    public string[] perguntas;      // ARmazena todas as perguntas
    public string[] AlternativaA;   // Armezena todas as alterantivas A
    public string[] AlternativaB;   // Armezena todas as alterantivas B
    public string[] AlternativaC;   // Armezena todas as alterantivas C
    public string[] AlternativaD;   // Armezena todas as alterantivas D
    public string[] corretas;       // Armezena todas as alterantivas corretas
    */

    /*  BAckup ANTES Da alteração do paul ----- quebrou o corte geral
    private int idPergunta;

    public float acertos;
    public float qtdQuestoes;
    public float media;
    public float percRespondido;
    public float valorY = 0.5f;
    public float percTempo;
    public float tempTime;
    public int notaFinal;
    public int idBtnCorreto;

    private soundController soundController;
    // private LeDadosSeco LeDadosSeco;
    //  private Question question;

    // Use this for initialization
    void Start()
    {
    soundController = FindObjectOfType(typeof(soundController)) as soundController;

    barraTempo.SetActive(false);

    controlabarraTempo();

    idTema = PlayerPrefs.GetInt("idTema");
    idPergunta = 0;
    qtdQuestoes = Question.Pergunta.Length;


    //print(qtdQuestoes);

    //Os campos Perguntas e as respostas são carregados pela primeira vez com base no Array estático da Classe Question.
    pergunta.text = Question.Pergunta[0];
    respostaA.text = Question.R1[0];
    respostaB.text = Question.R2[0];
    respostaC.text = Question.R3[0];
    respostaD.text = Question.R4[0];

    /*
    print("Classe Responder - Método Start: QtdQuestões =" + qtdQuestoes);
    int i;
    try { 
        for (i = 0; i < qtdQuestoes; i++) {
            print("Classe Responder - Método Start: Questão[" + i + "] " + Question.Pergunta[i].ToString());
        }
    }
    catch { print("Classe Responder - Método Start: Estourou Indice do Vetor de Perguntas"); }
    */

    /*  BAckup ANTES Da alteração do paul ----- quebrou o corte geral
    }

    void Update()
    {
    if (jogarComTempo == true)
    {
    tempTime += Time.deltaTime;
    controlabarraTempo();

    if (tempTime >= tempoResponder)
    {
        print("Método Update - Muda pergunta por limite de tempo ");
        proximaPergunta();
    }
    }

    }

    void controlabarraTempo()
    {
    // print("Método controlaBarraTempo - tempTime + tempoResponder " + tempoResponder);
    if (jogarComTempo == true) { barraTempo.SetActive(true); }
    percTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;
    if (percTempo < 0) { percTempo = 0; }
    barraTempo.transform.localScale = new Vector3(percTempo, 1, 1);

    }

    public void resposta(string alternativa)
    {

    // verifica se pode aceitar a resposta
    if (podeClicar == false)
    {
    return;
    }

    // Coloca impossibilitado de responder até clicr a próxima
    podeClicar = false;

    qtdRespondida++;

    // verifica se escolheu a alternativa certa.
    print("Classe Responder - Método resposta: Alternativa = " + alternativa); // + " Pergunta " + Question.R1[idPergunta].ToString() + " Resposta " + Question.Resposta[idPergunta].ToString());
    if (alternativa == "A")
    {
    if (Question.R1[idPergunta] == Question.Resposta[idPergunta])
    {
        acertos += 1;
        idBtnCorreto = 0;
        //   soundController.playAcerto();
        //   print("Parou no A");
    }
    else
    {
        //    soundController.playErro();
        print("PDeu RUIM !!");
    }

    }
    else if (alternativa == "B")
    {
    if (Question.R2[idPergunta] == Question.Resposta[idPergunta])
    {
        acertos += 1;
        idBtnCorreto = 1;
        // soundController.playAcerto();
        // print("Parou no B");

    }
    else
    {
        //  soundController.playErro();
        print("PDeu RUIM !!");
    }
    }
    else if (alternativa == "C")
    {
    if (Question.R3[idPergunta] == Question.Resposta[idPergunta])
    {
        acertos += 1;
        idBtnCorreto = 2;
        //  soundController.playAcerto();
        //   print("Parou no C");

    }
    else
    {
        //   soundController.playErro();
        print("PDeu RUIM !!");
    }
    }
    else if (alternativa == "D")
    {
    if (Question.R4[idPergunta] == Question.Resposta[idPergunta])
    {
        acertos += 1;
        idBtnCorreto = 3;
        //  soundController.playAcerto();
        //    print("Parou no D");

    }
    else
    {
        // soundController.playErro();
        print("PDeu RUIM !!");
    }
    }

    progressoBarra();

    }

    public void proximaPergunta()
    {

    print("Classe Responder - Método proximaPergunta = ");
    idPergunta++;
    tempTime = 0;
    podeClicar = true;

    for (int i = 0; i < 4; i++)
    {

    respostas[i].image.color = Color.white;

    }

    print("Método proximaPergunta: Compara valores para Calcular Média = " + idPergunta + " qtdQuestoes " + qtdQuestoes);

    if (idPergunta == qtdQuestoes) // Question.Pergunta.Length
    {

    // calcula a media
    media = 10 * (acertos / qtdQuestoes);

    // arredonda a nota
    notaFinal = Mathf.RoundToInt(media);

    //verifica se a nota é maior que a anterior

    if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
    {

        PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
        PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);

        print("Nota Final =" + notaFinal.ToString());
        //      PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
        //      PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
        //      SceneManager.LoadScene("notaFinal");

    }
    voltaParaTema();
    }
    else
    {

    print("Classe Responder - Método proximaPergunta - Proxima Pergunta = " + idPergunta + " qtdQuestoes " + qtdQuestoes);
    // carrega a proxima pergunta
    if (idPergunta < qtdQuestoes)
    {
        pergunta.text = Question.Pergunta[idPergunta];
        respostaA.text = Question.R1[idPergunta];
        respostaB.text = Question.R2[idPergunta];
        respostaC.text = Question.R3[idPergunta];
        respostaD.text = Question.R4[idPergunta];
    }
    //progressoBarra();
    }

    }

    public void progressoBarra()
    {


    percRespondido = ((qtdRespondida / qtdQuestoes));
    print("Classe Responder - Método progressoBarra: Qtd Questões Respondidas =" + qtdRespondida + " Questoes " + qtdQuestoes + " % Respostas " + percRespondido);


    respondeu();
    if (qtdRespondida >= 1)
    {

    barraProgresso.transform.localScale = new Vector3(percRespondido, 0.5f, 1);

    //Verifica se é para pintar as respostas Certas e erradas
    if (mostrarCorreta == true)
    {
        print("Classe Responder - Método resposta: Colorindo botões corAcerto e corErro");
        // Coloca todos os botões com acor de erro.
        foreach (Button i in respostas)
        {

            i.image.color = corErro;
        }
        //  respostas[idBtnCorreto].image.color = corAcerto;
        respostas[idBtnCorreto].image.color = corAcerto;

    }

    proximaPergunta();
    }
    else { barraProgresso.transform.localScale = new Vector3(percRespondido, 0, 0); }

    }

    public void voltaParaTema()
    {

    PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
    PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
    print("Classe Responder - Método voltaParaTema: Chama cena notaFinal");
    SceneManager.LoadScene("notaFinal");
    }

    public void respondeu()
    {
    print("Classe Responder - Método respondeu: Qtd Questões Respondidas =" + qtdRespondida);
    if (qtdRespondida <= 1)
    {
    infoRespostasTxt.text = "Respondida " + qtdRespondida + " de " + qtdQuestoes.ToString() + " Perguntas";
    //proximaPergunta();
    }
    else
    {
    infoRespostasTxt.text = "Respondidas " + qtdRespondida + " de " + qtdQuestoes.ToString() + " Perguntas";
    //proximaPergunta();
    }
    StartCoroutine("MostrarAlternativaCorreta");

    }


    IEnumerator MostrarAlternativaCorreta()
    {

    print("Classe Responder - Método MostrarAlternativaCorreta:  = " + qtdPiscar);
    for (int i = 0; i < qtdPiscar; i++)
    {

    respostas[idBtnCorreto].image.color = corAcerto;
    yield return new WaitForSeconds(0.5f);
    respostas[idBtnCorreto].image.color = Color.white;
    yield return new WaitForSeconds(0.5f);


    }

    }

    }
    */

    //  private LeDadosSeco LeDadosSeco;

    private int idTema;

    [Header("Firebase")]


    public int QtdPerguntas;


    [Header("Respostas")]

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostasTxt;
    private int Vidas;

    [Header("Botões de resposta")]
    public Button[] respostas;
    public Button btnProxima;
    public Color corAcerto, corErro;



    // public GameObject CertoA;
    //public GameObject ErradoA;

    [Header("Barra")]
    public GameObject barraProgresso;
    public GameObject barraTempo;
    public int qtdRespondida = 0;

    [Header("Opções de Jogo")]
    public bool perguntasAleatorias;
    public bool jogarComTempo;
    public float tempoResponder;
    public bool mostrarCorreta;
    public int qtdPiscar;
    public bool podeClicar = true;

    /*
    [Header("Configuração das Perguntas")]

    public string[] perguntas;      // ARmazena todas as perguntas
    public string[] AlternativaA;   // Armezena todas as alterantivas A
    public string[] AlternativaB;   // Armezena todas as alterantivas B
    public string[] AlternativaC;   // Armezena todas as alterantivas C
    public string[] AlternativaD;   // Armezena todas as alterantivas D
    public string[] corretas;       // Armezena todas as alterantivas corretas
    */


    private int idPergunta;

    public float acertos;
    public float media;
    public float percRespondido;
    public float percTempo;
    public float tempTime;
    public float valorY = 0.5f;
    public float qtdQuestoes;
    public int notaFinal;
    public int idBtnCorreto;

    private soundController soundController;
    // private LeDadosSeco LeDadosSeco;
    //  private Question question;

    // Use this for initialization
    void Start()
    {
        soundController = FindObjectOfType(typeof(soundController)) as soundController;

        barraTempo.SetActive(false);

        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;

        //Os campos Perguntas e as respostas são carregados pela primeira vez com base no Array estático da Classe Question.
        pergunta.text = Question.Pergunta[0];
        respostaA.text = Question.R1[0];
        respostaB.text = Question.R2[0];
        respostaC.text = Question.R3[0];
        respostaD.text = Question.R4[0];

        qtdQuestoes = Question.Pergunta.Length;

        /*
        print("Classe Responder - Método Start: QtdQuestões =" + qtdQuestoes);
        int i;
        try { 
            for (i = 0; i < qtdQuestoes; i++) {
                print("Classe Responder - Método Start: Questão[" + i + "] " + Question.Pergunta[i].ToString());
            }
        }
        catch { print("Classe Responder - Método Start: Estourou Indice do Vetor de Perguntas"); }
        */

        controlabarraTempo();
        progressoBarra();

    }

    void Update()
    {
        if (jogarComTempo == true)
        {
            tempTime += Time.deltaTime;
            controlabarraTempo();

            if (tempTime >= tempoResponder)
            {
                print("Método Update - Muda pergunta por limite de tempo ");
                respondeu();
                proximaPergunta();
            }
        }

    }

    void controlabarraTempo()
    {
        //print("01: Classe responder - Método controlaBarraTempo - tempTime + tempoResponder " + tempoResponder);
        if (jogarComTempo == true) { barraTempo.SetActive(true); }
        percTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;
        if (percTempo < 0) { percTempo = 0; }
        barraTempo.transform.localScale = new Vector3(percTempo, 1, 1);

    }

    public void progressoBarra()
    {

        print("02 A - Classe Responder - Método progressoBarra: Qtd Questões Respondidas = " + qtdRespondida + " Questoes " + qtdQuestoes + " percRespondido " + percRespondido);

        if (qtdRespondida == 0)
        {
            barraProgresso.transform.localScale = new Vector3(percRespondido, 1, 1);
            infoRespostasTxt.text = "Respondida " + qtdRespondida + " de " + qtdQuestoes.ToString() + " Perguntas";
        }
        else if (qtdRespondida >= 1)
        {
            percRespondido = ((qtdRespondida / qtdQuestoes));
            print("02 B - Classe Responder - Método progressoBarra: Respondidas = " + qtdRespondida + " Questoes " + qtdQuestoes + " percRespondido = " + percRespondido.ToString("F2"));
            barraProgresso.transform.localScale = new Vector3(percRespondido, 1, 1);
            //Verifica se é para pintar as respostas Certas e erradas
            if (mostrarCorreta == true)
            {
                print("02b - **** Classe Responder - Método resposta: Colorindo botões corAcerto e corErro ***");
                // Coloca todos os botões com acor de erro.
                foreach (Button i in respostas)
                {
                    i.image.color = corErro;
                }
                respostas[idBtnCorreto].image.color = corAcerto;
                StartCoroutine("MostrarAlternativaCorreta");
            }

        }

    }

    public void proximaPergunta()
    {

        idPergunta++;
        tempTime = 0;
        podeClicar = true;

        for (int i = 0; i < 4; i++)
        {

            respostas[i].image.color = Color.white;

        }

        print("05 - Método proximaPergunta: Compara valores para Calcular Média = " + idPergunta + " qtdQuestoes " + qtdQuestoes);
        print("05 - Método proximaPergunta: Compara Notas - notaFinal Temp = " + notaFinal + " notaFinal Banco: " + PlayerPrefs.GetInt("notaFinal" + idTema.ToString()));

        if (idPergunta == qtdQuestoes) // Question.Pergunta.Length
        {

            // calcula a media
            media = 10 * (acertos / qtdQuestoes);

            // arredonda a nota
            notaFinal = Mathf.RoundToInt(media);

            //verifica se a nota é maior que a anterior

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {

                //PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                //PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);

                PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
                PlayerPrefs.SetFloat("qtdQuestoes", qtdQuestoes);

                // print("Nota Final =" + notaFinal.ToString() + " qtdQuestoes " + qtdQuestoes);
                //      PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
                //      PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
                //      SceneManager.LoadScene("notaFinal");

            }
            voltaParaTema();
        }
        else
        {

            print("05 - Classe Responder - Método proximaPergunta - Proxima Pergunta = " + idPergunta + " qtdQuestoes " + qtdQuestoes);
            // carrega a proxima pergunta
            if (idPergunta < qtdQuestoes)
            {
                pergunta.text = Question.Pergunta[idPergunta];
                respostaA.text = Question.R1[idPergunta];
                respostaB.text = Question.R2[idPergunta];
                respostaC.text = Question.R3[idPergunta];
                respostaD.text = Question.R4[idPergunta];
            }
            //progressoBarra();
        }

    }

    public void respondeu()
    {

        qtdRespondida += 1;
        print("04 - Classe Responder - Método respondeu: Qtd Questões Respondidas =" + qtdRespondida);

        if (qtdRespondida <= 1)
        {
            infoRespostasTxt.text = "Respondida " + qtdRespondida + " de " + qtdQuestoes.ToString() + " Perguntas";
            //proximaPergunta();
        }
        else
        {
            infoRespostasTxt.text = "Respondidas " + qtdRespondida + " de " + qtdQuestoes.ToString() + " Perguntas";
            //proximaPergunta();
        }
        progressoBarra();

    }

    public void resposta(string alternativa)
    {

        // verifica se pode aceitar a resposta
        if (podeClicar == false)
        {
            return;
        }

        // Coloca impossibilitado de responder até clicr a próxima
        podeClicar = false;

        // verifica se escolheu a alternativa certa.
        print("03 - Classe Responder - Método resposta: Alternativa = " + alternativa);
        if (alternativa == "A")
        {
            if (Question.R1[idPergunta] == Question.Resposta[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 0;
                //   soundController.playAcerto();
                //   print("Parou no A");
            }
            else
            {
                //    soundController.playErro();
                print("PDeu RUIM !!");
            }

        }
        else if (alternativa == "B")
        {
            if (Question.R2[idPergunta] == Question.Resposta[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 1;
                // soundController.playAcerto();
                // print("Parou no B");

            }
            else
            {
                //  soundController.playErro();
                print("PDeu RUIM !!");
            }
        }
        else if (alternativa == "C")
        {
            if (Question.R3[idPergunta] == Question.Resposta[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 2;
                //  soundController.playAcerto();
                //   print("Parou no C");

            }
            else
            {
                //   soundController.playErro();
                print("PDeu RUIM !!");
            }
        }
        else if (alternativa == "D")
        {
            if (Question.R4[idPergunta] == Question.Resposta[idPergunta])
            {
                acertos += 1;
                idBtnCorreto = 3;
                //  soundController.playAcerto();
                //    print("Parou no D");

            }
            else
            {
                // soundController.playErro();
                print("PDeu RUIM !!");
            }
        }

        respondeu();
        //proximaPergunta();

    }

    public void voltaParaTema()
    {

        PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
        PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
        print("Classe Responder - Método voltaParaTema: Chama cena notaFinal");
        SceneManager.LoadScene("notaFinal");
    }




    IEnumerator MostrarAlternativaCorreta()
    {

        print("05 - Classe Responder - Método MostrarAlternativaCorreta:  = " + qtdPiscar);
        for (int i = 0; i < qtdPiscar; i++)
        {

            respostas[idBtnCorreto].image.color = corAcerto;
            yield return new WaitForSeconds(0.5f);
            respostas[idBtnCorreto].image.color = Color.white;
            yield return new WaitForSeconds(0.5f);


        }

        if (qtdRespondida == 0)
        {
            infoRespostasTxt.text = "Respondida " + qtdRespondida + " de " + qtdQuestoes.ToString() + " Perguntas";
        }
        else if (qtdRespondida >= 1)
        {
            proximaPergunta();
        }
    }

}


