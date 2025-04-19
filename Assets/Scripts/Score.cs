using TMPro;
using UnityEngine;

public sealed class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    private int _score;

    public int ScoreCount {
        get => _score;

        set {
            if (_score == value) return;

            _score = value;

            scoreText.SetText($"Score: {_score}");
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() => Instance = this;
}
