using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using System.IO;

public static class GetHeadImageByUID 
{
    static Dictionary<int, string> _headImages = new Dictionary<int, string>();

    static async Task<string> GetImagePath(int userID)
    {
        if (!_headImages.ContainsKey(userID))
        {
            string Url = "https://api.bilibili.com/x/space/acc/info?mid=" + userID.ToString() + "&jsonp=jsonp";
            UnityWebRequest request = UnityWebRequest.Get(Url);
            request.SetRequestHeader("user-agent", @"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.198 Safari/537.36");
            request.timeout = 5;//3.等待响应时间，超过5秒结束
            await request.SendWebRequest();
            if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"获取失败！");
                return null;
            }
            else
            {
                string jsonData = request.downloadHandler.text;
                var data = JsonMapper.ToObject(jsonData);
                jsonData = data["data"]["face"].ToString();
                if (!_headImages.ContainsKey(userID))
                    _headImages.Add(userID, jsonData);
                return jsonData;
            }
        }

        return _headImages[userID];
    }
    public static async Task<Texture2D> GetHeadTexture(int userID)
    {
        string url = await GetImagePath(userID);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        await request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"获取失败！");
            return null;
        }
        else
        {
            byte[] bytes = request.downloadHandler.data;
            Texture2D tex = ByteToTex2d(bytes);
            //Texture2D tex = DownloadHandlerTexture.GetContent(request);
            return tex;
        }

    }
    public static async Task<Sprite> GetHeadSprite(int userID)
    {
        Texture2D tex = await GetHeadTexture(userID);
        if (tex is null) return null;
        Sprite temp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
        return temp;
    }
    public static Texture2D ByteToTex2d(byte[] bytes, int w = 100, int h = 100)
    {
        Texture2D tex = new Texture2D(w, h);
        tex.LoadImage(bytes);
        return tex;
    }

    public static Texture2D GetFileTex(string filePath, int w = 100, int h = 100)
    {
        if (!File.Exists(filePath))
            return null;
        byte[] imgData = File.ReadAllBytes(filePath);
        return ByteToTex2d(imgData);
    }

}
public static class ExtensionMethods
{
    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<object>();
        asyncOp.completed += obj => { tcs.SetResult(null); };
        return ((Task)tcs.Task).GetAwaiter();
    }
}