using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBs;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerfectNote = 150;

    public int currentMultiplier = 1;
    public int MultiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;

                theMusic.Play();

            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        { 
             MultiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= MultiplierTracker)
            {
                 MultiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

      //  currentScore += scorePerNote *currentMultiplier;
      scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerfectNote * currentMultiplier;
        NoteHit();
    }


    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultiplier = 1;
        MultiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
