using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class UserDatabase
{
    [JsonProperty("users")]
    public List<UserData> Users { get; set; } = new List<UserData>();

    // 특정 ID의 사용자가 이미 등록되어 있는지 확인.
    public bool ContainsUser(string id)
    {
        return Users.Exists(u => u.id == id);
    }

    public void AddUser(UserData newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException(nameof(newUser));
        }
        
        // Users.Add(newUser);
        if (!ContainsUser(newUser.id))
        {
            Users.Add(newUser);
        }
        else
        {
            //text로 전달해도 좋은...
            throw new Exception("이미 사용 중인 ID.");
        }
    }
}
