using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScriptableObject/ScoreData")]
public class ScoreData : ScriptableObject
{
    [SerializeField] private int highScore;

    public int HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }
}
