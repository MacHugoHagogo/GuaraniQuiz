using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class GravaDados : MonoBehaviour {

    // Use this for initialization
    void Start () {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://quiz-guarani.firebaseio.com/");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

       // DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Leaders");



        WriteNewUser(Usuario.Nome, Usuario.eMail, Usuario.DataNascimento, Usuario.UID);


    }
    
    private void WriteNewUser(string nome, string email, string dataNascimento, string uid)
    {




        User user = new User(nome, email, dataNascimento, uid);
        string json = JsonUtility.ToJson(user);

        DatabaseReference usersref = FirebaseDatabase.DefaultInstance.GetReference("Usuarios");

        usersref.Child(uid.ToString()).SetRawJsonValueAsync(json);

        print("JSON =" + json.ToString());

        // print("UID para gravar ="+  )

        //  DatabaseReference mDatabaseRef =   

        // DatabaseReference mmDatabaseRef =  ;



         // mDatabaseRef.Child("Usuarios").Child(Usuario.UID).SetRawJsonValueAsync(json);

    }


}
