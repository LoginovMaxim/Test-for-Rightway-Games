using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.UI
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _content;

        private void OnEnable()
        {
            Time.timeScale = 1;
        }

        public void ShowLosePanel()
        {
            Time.timeScale = 0;         // остановить игровое время
            _content.SetActive(true);   // показать контент (текст поражения, кнопка перезапуска, очки видны, панель полупрозрачна)
        }

        public void OnReloadGame()      // перезапустить игру
        {
            SceneManager.LoadScene(0);  // загрузка единственной нулевой сцены
        }
    }
}
