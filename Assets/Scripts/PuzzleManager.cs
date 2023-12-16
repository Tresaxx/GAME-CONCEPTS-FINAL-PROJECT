using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject puzzle;
    public Player player;
    public FakeElonMusk elon;
    public Text timer;
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public AudioSource powerUpSound;
    public AudioSource powerDownSound;
    public float time;
    public bool puzzleCompletion = false;
    public int puzzlesCompleted = 0;
    private int answer;
    private int randQuestion1;
    private int randQuestion2;
    private int questionAnswer;
    private int wrongQuestion1;
    private int wrongQuestion2;
    private int wrongAnswer1;
    private int wrongAnswer2;
    private bool puzzleWrong = false;


    void Awake(){
        answer = Random.Range(1, 3);
        randQuestion1 = Random.Range(1, 100);
        randQuestion2 = Random.Range(1, 100);
        questionAnswer = randQuestion1 + randQuestion2;
        wrongQuestion1 = Random.Range(1, 100);
        wrongQuestion2 = Random.Range(1, 100);
        wrongAnswer1 = wrongQuestion1 + wrongQuestion2;
        wrongAnswer2 = wrongQuestion1 + randQuestion2;
        if(wrongAnswer1 == questionAnswer){
            wrongAnswer1 = 5;
        }
        if(wrongAnswer2 == questionAnswer){
            wrongAnswer2 = 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        PuzzleQuestion();
        if(player.puzzleActive == true){
            time = player.puzzleTime - player.puzzleTimer;
            puzzle.SetActive(true);
            if(time < 0){
                time = 0;
            }
            question.text = randQuestion1.ToString() + " + " + randQuestion2.ToString() + "?";
            timer.text = "TIMER: " + time.ToString("F2");
        }
        if(player.puzzleActive == false){
            puzzle.SetActive(false);
        }
        if(puzzleCompletion){
            elon.timer = elon.waitTime - 5;
            powerUpSound.Play(0);
            puzzlesCompleted++;
            ScoreManager.instance.AddPoint(50000);
            puzzleCompletion = false;
            player.puzzleTimer = player.puzzleTime;
            answer = Random.Range(1, 3);
            randQuestion1 = Random.Range(1, 100);
            randQuestion2 = Random.Range(1, 100);
            questionAnswer = randQuestion1 + randQuestion2;
            wrongQuestion1 = Random.Range(1, 100);
            wrongQuestion2 = Random.Range(1, 100);
            wrongAnswer1 = wrongQuestion1 + wrongQuestion2;
            wrongAnswer2 = wrongQuestion1 + randQuestion2;
            if(wrongAnswer1 == questionAnswer){
                wrongAnswer1 = 5;
            }
            if(wrongAnswer2 == questionAnswer){
                wrongAnswer2 = 2;
            }
        } else if(puzzleWrong){
            powerDownSound.Play(0);
            puzzle.SetActive(false);
            puzzleWrong = false;
            player.puzzleTimer = player.puzzleTime;
        }
    }

    public void PuzzleQuestion(){
        if(answer == 1){
            answer1.text = questionAnswer.ToString();
            answer2.text = wrongAnswer1.ToString();
            answer3.text = wrongAnswer2.ToString();
        } else if(answer == 2){
            answer1.text = wrongAnswer2.ToString();
            answer2.text = questionAnswer.ToString();
            answer3.text = wrongAnswer1.ToString();
        } else {
            answer1.text = wrongAnswer1.ToString();
            answer2.text = wrongAnswer2.ToString();
            answer3.text = questionAnswer.ToString();
        }
    }
    public void button1()
    {
        if(answer == 1){
            puzzleCompletion = true;
        } else{
            puzzleWrong = true;
        }
    }
    public void button2()
    {
        if(answer == 2){
            puzzleCompletion = true;
        } else{
            puzzleWrong = true;
        }
    }
    public void button3()
    {
        if(answer == 3){
            puzzleCompletion = true;
        } else{
            puzzleWrong = true;
        }
    }
}
