using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{


    public  string Nome;
    public  string eMail;
 //   public  string UID;
    public  string DataNascimento;


    public User()
    {
    }

    public User(string nome, string email, string dataNascimento)
    {
        this.Nome = nome;
        this.eMail = email;
   //     this.UID = uid;
        this.DataNascimento = dataNascimento;
    }
}