using System;
using UnityEngine;

[Serializable]
public class UserData
{
    [SerializeField] private string userName;
    [SerializeField] private int cash;
    [SerializeField] private int balance;

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

    public int Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public UserData(string userName, int cash, int balance)
    {
        this.userName = userName;
        this.cash = cash;
        this.balance = balance;
    }
}
