[System.Serializable]
public class UserData
{
    public string userName;
    public int cash;
    public ulong balance;

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

    public UserData(string userName, int cash, ulong balance)
    {
        this.userName = userName;
        this.cash = cash;
        this.balance = balance;
    }
}

