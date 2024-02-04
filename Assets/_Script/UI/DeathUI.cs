using System.Collections;
using System.Collections.Generic;
using GameUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathUI : Singleton<DeathUI>, IUIView
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Button Restart;

    public void InitView()
    {
        _root.SetActive(false);

        Restart.onClick.RemoveAllListeners();
        Restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
    public void Show()
    {
        _root.SetActive(true);
    }

}
