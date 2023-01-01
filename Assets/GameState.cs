using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    [SerializeField] private CollisionProvider _playerOutWallProvider;
    [SerializeField] private CollisionProvider _enemyOutWallProvider;

    [SerializeField] private GameUI _ui;

    [SerializeField] private CpuDefault _cpu;
    [SerializeField] private PaddleController _player;

    [SerializeField] private BallLauncher _ballLauncher;
    [SerializeField] private float RespownTime = 1f;

    [SerializeField] private int GameEndPoint = 10;

    private int _playerPoint;
    public int PlayerPoint {
        get { return _playerPoint; }
        private set {
            _playerPoint = value;
            _ui.SetPlayerPointText(_playerPoint);
        }
    }

    private int _enemyPoint;
    public int EnemyPoint {
        get { return _enemyPoint; }
        private set {
            _enemyPoint = value;
            _ui.SetEnemyPointText(_enemyPoint);
        }
    }

    // Start is called before the first frame update
    void Start() {
        _playerOutWallProvider.CollisionEnterAction = collision => {
            if (collision.gameObject.name == "ball") {
                Destroy(collision.gameObject);
                EnemyPoint++;

                if (CheckGameEnd(EnemyPoint)) {
                    _ui.SetWinner(GameUI.Winner.Enemy);
                    return;
                }

                StartCoroutine(ReLaunchBall(RespownTime));
            }
        };

        _enemyOutWallProvider.CollisionEnterAction = collision => {
            if (collision.gameObject.name == "ball") {
                Destroy(collision.gameObject);
                PlayerPoint++;

                if (CheckGameEnd(PlayerPoint)) {
                    _ui.SetWinner(GameUI.Winner.Player);
                    return;
                }
                StartCoroutine(ReLaunchBall(RespownTime));
            }
        };
    }

    private bool CheckGameEnd(int point) {
        return point == GameEndPoint;
    }

    private void ResetGame() {
        _ui.SetWinner(GameUI.Winner.None);
        PlayerPoint = 0;
        EnemyPoint = 0;

        //  座標をリセット
        _cpu.ResetPosition();
        _player.ResetPosition();

        //  最初のボールを発射
        StartCoroutine(ReLaunchBall(RespownTime));
    }

    private IEnumerator ReLaunchBall(float waitTime) {
        yield return new WaitForSeconds(waitTime);

        BallBase ball = _ballLauncher.LaunchBall();

        _cpu.SetBallTransform(ball.gameObject.transform);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ResetGame();
        }
    }
}
