using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;
namespace GameUI
{
    public class PauseUI : Singleton<PauseUI>, IUIView
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Button unPause;

        public void InitView()
        {
            Hide();
            unPause.onClick.RemoveAllListeners();
            unPause.onClick.AddListener(() => { TimeManager.Instance.IsPause.Value = false; });

            TimeManager.Instance.IsPause.OnChange += () =>
            {
                if (TimeManager.Instance.IsPause.Value)
                {
                    Show();
                    return;
                }
                Hide();
            };
        }

        private void Show()
        {
            _root.SetActive(true);
        }
        private void Hide()
        {
            _root.SetActive(false);
        }


    }
}
