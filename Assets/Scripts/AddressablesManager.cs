using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

[Serializable]
public class AssetRefernceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetRefernceAudioClip(string guid) : base(guid) { }
}

public class AddressablesManager : MonoBehaviour
{
    [SerializeField]
    private AssetReferenceTexture2D unityLogoAssetReference;

    [SerializeField]
    private RawImage rawImageUnityLogo;

    [SerializeField]
    private WebRequestOverride wro;

    private GameObject shop;

    private void Start()
    {
        wro.First();
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    private void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        unityLogoAssetReference.LoadAssetAsync<Texture2D>();
    }

    private void Update()
    {
        if (unityLogoAssetReference.Asset != null && rawImageUnityLogo.texture == null)
        {
            rawImageUnityLogo.texture = unityLogoAssetReference.Asset as Texture2D;
            Color currentColor = rawImageUnityLogo.color;
            currentColor.a = 1.0f;
            rawImageUnityLogo.color = currentColor;
        }
    }

    // private void OnDestroy()
    // {
    //     prefabShop.ReleaseInstance(shop);
    //     unityLogoAssetReference.ReleaseAsset();
    // }
}
