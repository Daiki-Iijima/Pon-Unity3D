using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public enum Winner {
        None,
        Player,
        Enemy,
    }

    [SerializeField] private TextMeshProUGUI _playerPointText;
    [SerializeField] private Image _playerWinImage;
    [SerializeField] private TextMeshProUGUI _enemyPointText;
    [SerializeField] private Image _enemyWinImage;

    public void SetWinner(Winner winner) {
        _enemyWinImage.gameObject.SetActive(false);
        _playerWinImage.gameObject.SetActive(false);
        switch (winner) {
            case Winner.None: {
                }
                break;
            case Winner.Player: {
                    _playerWinImage.gameObject.SetActive(true);
                }
                break;
            case Winner.Enemy: {
                    _enemyWinImage.gameObject.SetActive(true);
                }
                break;
        }
    }

    public void SetPlayerPointText(int point) {
        string setText = point.ToString();
        if (point < 10) {
            setText = "0" + point.ToString();
        }

        _playerPointText.text = setText;
    }

    public void SetEnemyPointText(int point) {
        string setText = point.ToString();
        if (point < 10) {
            setText = "0" + point.ToString();
        }

        _enemyPointText.text = setText;
    }
}
