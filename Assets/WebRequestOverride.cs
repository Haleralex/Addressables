using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;

internal class WebRequestOverride : MonoBehaviour
{
    //Register to override WebRequests Addressables creates to download
    public void First()
    {
        Addressables.WebRequestOverride = EditWebRequestURL;
    }
    
    //Override the url of the WebRequest, the request passed to the method is what would be used as standard by Addressables.
    private void EditWebRequestURL(UnityWebRequest request)
    {
        Debug.Log(request.url);
        
    }
}