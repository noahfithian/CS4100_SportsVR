using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public enum GameState {Active, Paused, DisplayingWinScreen, Restarting};
    private GameState _state;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI _scoreText;
    public int score {private set; get;} //This configuration makes the variable like a property, allowing the code to privately set in this class and publicly get from other classes

    // public int otherScore {private set => _otherScore = value + 1; get;}
    // private int _otherScore;

    public void Start() => StartGame();
    public void SetScore(int scoreToAdd) {
        score += scoreToAdd;
        _scoreText.text = " " + score + " ";
    }
    public void StartGame()
    {
        _state = GameState.Active;
        StartCoroutine(SpawnTarget());
        SetScore(0);
    }

    private IEnumerator SpawnTarget()
    {
        while (_state == GameState.Active)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}


