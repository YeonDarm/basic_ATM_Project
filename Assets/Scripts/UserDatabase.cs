using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class UserDatabase
{
    [JsonProperty("users")]
    public Dictionary<string, UserData> Users { get; private set; }
        = new Dictionary<string, UserData>(StringComparer.OrdinalIgnoreCase);

    // 특정 ID의 사용자가 이미 등록되어 있는지 확인.
    public bool ContainsUser(string id)
    {
        return !string.IsNullOrWhiteSpace(id) && Users.ContainsKey(id);
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
            Users.Add(newUser.id, newUser);
        }
        else
        {
            //text로 전달해도 좋은...
            throw new InvalidOperationException($"ID '{newUser.id}'는 이미 사용 중입니다.");
        }
    }

    //데이터 가져오기..
    public UserData GetUser(string id)
    {
        if (ContainsUser(id))
        {
            return Users[id];
        }
        return null;
    }

    //데이터 삭제(나중에...)
    public bool RemoveUser(string id)
    {
        return ContainsUser(id) && Users.Remove(id);
    }
}
