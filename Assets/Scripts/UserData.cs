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
    [SerializeField] //JSON 직렬화하기 위해 필요.
    private string _userName; // 백킹 필드.
    public string UserName // << 해당 프로퍼티를 호출하면
    {
        //백킹필드롤 가져오면서 동시에 값이 변경되면 이벤트로 값이 변경한다.
        get => _userName;
        set {
            if (_userName != value) {
                _userName = value;
                OnUserDataChanged?.Invoke(); //이벤트/구독
            }
        }
    }

    //위와 동일.
    [SerializeField]
    private int _cash;
    public int Cash
    {
        get => _cash;
        set {
            if (_cash != value)
            {
                _cash = value;
                OnUserDataChanged?.Invoke();
            }
        }
    }

    //위와 동일.
    [SerializeField]
    private ulong _balance;
    public ulong Balance // 은행 잔액은 훨씬 클 수 있다. u: 언사인드(부호 없이)
    {
        get => _balance;
        set {
            if (_balance != value) {
                _balance = value;
                OnUserDataChanged?.Invoke();
            }
        }
    }


    public event Action OnUserDataChanged; //이벤트: 값이 변경될 때 호출
    public UserData(string id, string password, string userName, int cash, ulong balance)
    {
        this.id = id;
        this.password = password;
        this.UserName = userName;
        this.Cash = cash;
        this.Balance = balance;
    }
}

