using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class MenuController : MonoBehaviour
    {
        public static MenuController instance;

        //outlets
        public GameObject mainMenu;
        public GameObject optionsMenu;
        public GameObject levelMenu;


        void Awake()
        {
            instance = this;
            Hide();
        }

        public void Show()
        {
            ShowMainMenu();
            gameObject.SetActive(true);
            Time.timeScale = 0;
            PlayerController.instance.isPaused = true;
        }
        public void Hide()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            if (PlayerController.instance != null) {
                PlayerController.instance.isPaused = false;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void SwitchMenu(GameObject someMenu)
        {
            // Clean-up Menus
            mainMenu.SetActive(false);
            optionsMenu.SetActive(false);
            levelMenu.SetActive(false);
            // Turn on requested menu
            someMenu.SetActive(true);
        }

        public void ShowMainMenu()
        {
            SwitchMenu(mainMenu);
        }
        public void ShowOptionsMenu()
        {
            SwitchMenu(optionsMenu);
        }
        public void ShowLevelMenu()
        {
            SwitchMenu(levelMenu);
        }
        public void LoadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}