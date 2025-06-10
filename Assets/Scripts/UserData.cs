using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;


[System.Serializable]
public class UserData
{
    public string id { get; private set; }
    public string password { get; private set; }

    [SerializeField] private string userName;
    [SerializeField] private int cash;
    [SerializeField] private ulong balance;


    //프로퍼티로만 접근할 수 있음.
    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    public int Cash
    {
        get { return cash; }
        set { cash = value; }
    }
    public ulong Balance // 은행 잔액은 훨씬 클 수 있다. u: 언사인드(부호 없이)
    {
        get { return balance; }
        set { balance = value; }
    }

    public UserData(string id, string password, string userName, int cash, ulong balance)
    {
        this.id = id;
        this.password = password;
        this.userName = userName;
        this.cash = cash;
        this.balance = balance;
    }
}

