using UnityEngine;
using Manager;

namespace UI
{

public class GameOver : MonoBehaviour {
    public GameOverMenu GameOverMenu {
        get {
            if (_gameOverMenu == null)
            {
                _gameOverMenu = new GameOverMenu();
            }

            return _gameOverMenu;
        }
    }

    private GameOverMenu _gameOverMenu;

    public SelectableText restartText;
    public SelectableText goToTitleText;

    public void Update()
    {
        if (GameOverMenu.CurrentOption == GameOverMenu.GameOverOption.Restart)
        {
            restartText.isSelected = true;
            goToTitleText.isSelected = false;
            return;
        }

        restartText.isSelected = false;
        goToTitleText.isSelected = true;
    }
}

}