using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class Imagen : MonoBehaviour
{
    public InputField IPs;
    public string geturl;
    public Renderer rend;
    void Start()
    {
     
    }

    void Update()
    {
        StartCoroutine(GetTexture());
        var t = Task.Run(async delegate
        {
            await Task.Delay(90);
            return 42;
        });
        t.Wait();
    }
    IEnumerator GetTexture()
    {

        while (true)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(geturl);
            yield return www.SendWebRequest();
            if (www.isDone == true)
            {
                rend = GetComponent<Renderer>();
                rend.material.mainTexture = DownloadHandlerTexture.GetContent(www);
                UnityWebRequest.ClearCookieCache();
            }
            StopAllCoroutines();
        }
    }
}
