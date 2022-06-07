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
    private AssetReference prefabShop;

    [SerializeField]
    private AssetReference musicAsset;

    [SerializeField]
    private AssetReferenceTexture2D unityLogoAssetReference;

    [SerializeField]
    private RawImage rawImageUnityLogo;

    private GameObject shop;

    private void Start()
    {
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    private void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        prefabShop.InstantiateAsync().Completed += (go) =>
        {
            var shop = go.Result;
            this.shop = shop;
        };

        musicAsset.LoadAssetAsync<AudioClip>().Completed += (clip) =>
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip.Result;
            audioSource.playOnAwake = false;
            audioSource.loop = true;
            audioSource.Play();
        };

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
