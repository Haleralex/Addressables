using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class NonAddressablesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabShop;

    [SerializeField]
    private AudioClip musicAsset;

    [SerializeField]
    private Texture2D unityLogoAssetReference;

    [SerializeField]
    private RawImage rawImageUnityLogo;

    private void Start()
    {
        AddressablesManager_Completed();
    }

    private void AddressablesManager_Completed()
    {
        GameObject.Instantiate(prefabShop);
        rawImageUnityLogo.texture = unityLogoAssetReference;
        var ass = gameObject.AddComponent<AudioSource>();
        ass.playOnAwake = false;
        ass.clip = musicAsset;
        ass.Play();
    }
}
