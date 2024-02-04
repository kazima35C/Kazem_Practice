using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Game;
namespace GameUI
{
    public class GameUI : Singleton<GameUI>, IUIView
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private TextMeshProUGUI healthPlayer;
        [SerializeField] private TextMeshProUGUI killScore;
        [SerializeField] private TextMeshProUGUI timeScore;


        private void Start()
        {
            InitView();
        }
        public void InitView()
        {
            _root.SetActive(true);
            GameManager.Instance.enemyKilled.OnChange += ShowKillScore;
            ShowKillScore();
            DeathUI.Instance.InitView();
            PauseUI.Instance.InitView();
        }
        private void Update()
        {
            timeScore.text = GameManager.Instance.GameTime.ToString();
            healthPlayer.text = "Health: " + GameManager.Instance.HealthPlayer.ToString();
            if (GameManager.Instance.HealthPlayer <= 0)
            {
                DeathUI.Instance.Show();
            }
        }

        private void ShowKillScore()
        {
            killScore.text = "Score: " + GameManager.Instance.enemyKilled.Value.ToString();
        }
        private void OnDestroy()
        {
            if(GameManager.Instance)
                GameManager.Instance.enemyKilled.OnChange -= ShowKillScore;
        }
    }
}
