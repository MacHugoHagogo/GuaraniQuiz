using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Threading.Tasks;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;
using System;


public class LeDadosSeco : MonoBehaviour {
 

    public int QtdPerguntas;
    public Text DadosBaseSeco;
    public string UidUser;



    // Use this for initialization
    void Start () {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://quiz-guarani.firebaseio.com/");


        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Cria os Arrays para receber os dados.
        Question.Pergunta = new string[QtdPerguntas];
        Question.R1 = new string[QtdPerguntas];
        Question.R2 = new string[QtdPerguntas];
        Question.R3 = new string[QtdPerguntas];
        Question.R4 = new string[QtdPerguntas];
        Question.Resposta = new string[QtdPerguntas];
        UidUser = PlayerPrefs.GetString("UidUser");
        DadosBaseSeco.text = " Dados base seco =" + UidUser.ToString();
       // UidUser = "o3Qdp7J9M3hSOgNzsHRspMU1U2n1";


        InitializeFirebase();
       // Hash.text = Usuario.UID.ToString() + "<<-";

    }

    // Update is called once per frame
    void InitializeFirebase() {

        FirebaseApp app = FirebaseApp.DefaultInstance;

        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://quiz-guarani.firebaseio.com/");
        if (app.Options.DatabaseUrl != null)
            app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        StartListener();
    }

    void  StartListener(){

        print("Vai começar a ler os dados");

        FirebaseDatabase.DefaultInstance
      .GetReference("Questions/Nivel1")
      .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
              print("Deu erro" );
              // Handle the error...
          }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                print("quantidade de filhos" + snapshot.ChildrenCount.ToString());

              for (int i = 0; i < QtdPerguntas; i++)
                { 
                    // Le os dados do Banco no atalho /Tela+Indice+/Pergunta - Desse jeito ele busca os itens da árvore
                    // no caminho certo e coloca no indice do arrey.
                  Question.Pergunta[i] = snapshot.Child("/Tela" + (i+1).ToString() + "/Pergunta").Value.ToString();
                  Question.R1[i] = snapshot.Child("/Tela" + (i + 1).ToString() + "/R1").Value.ToString();
                  Question.R2[i] = snapshot.Child("/Tela" + (i + 1).ToString() + "/R2").Value.ToString();
                  Question.R3[i] = snapshot.Child("/Tela" + (i + 1).ToString() + "/R3").Value.ToString();
                  Question.R4[i] = snapshot.Child("/Tela" + (i + 1).ToString() + "/R4").Value.ToString();
                  Question.Resposta[i] = snapshot.Child("/Tela" + (i + 1).ToString() + "/Resposta").Value.ToString();
                  

              }

              print("Dado 1=" + Question.Pergunta[0].ToString()  );
              // Do something with snapshot...
          }
        });

        print("Vai começar a ler os dados de Usuário");

        FirebaseDatabase.DefaultInstance
      .GetReference("Usuarios")
      .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              print("Deu erro");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              print("Leitura antes de abrir =" + UidUser.ToString());

              // Le os dados do Banco no atalho /Tela+Indice+/Pergunta - Desse jeito ele busca os itens da árvore
              // no caminho certo e coloca no indice do arrey.

                //  Usuario.Nome = snapshot.Child(UidUser.ToString() + "/Nome").Value.ToString();
                //  Usuario.eMail = snapshot.Child(UidUser.ToString() + "/eMail").Value.ToString();
                //  Usuario.DataNascimento = snapshot.Child(UidUser.ToString() + "/DataNascimento").Value.ToString();
                //  Usuario.UID = UidUser;

     //         Hash.text = "Dado Nome = " + UidUser.ToString();
              print("Dado eMail =" + Usuario.eMail.ToString());

              // Do something with snapshot...
          }
      });

        print("Passou pela leitura");



    }

    public void LimparAll() {

        PlayerPrefs.DeleteAll();
    }
}
