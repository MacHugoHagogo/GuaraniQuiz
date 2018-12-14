using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{


    public  string Nome;
    public  string eMail;
 //   
    public  string DataNascimento;
    public string UID;


    public User()
    {
    }

    public User(string nome, string email, string dataNascimento, string uid)
    {
        this.Nome = nome;
        this.eMail = email;
   //     this.UID = uid;
        this.DataNascimento = dataNascimento;
        this.UID = uid;
    }
}