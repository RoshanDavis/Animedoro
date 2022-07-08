using UnityEngine.UI;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Text timer,pause,start;
    public float maxTime, currentTime;
    public bool running = false, study = true;
    public GameObject Title, StartButton, PauseButton, ResetButton,SkipButton,Add5minButton,BG;
    public Sprite[] sprites;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        start.text = "Start Study";
        currentTime = maxTime;
        i = Random.Range(0, sprites.Length);
        BG.GetComponent<Image>().sprite = sprites[i];    
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
            Timer();
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Next();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Previous();
        }
    }

    public void Next()
    {
        if (i >= sprites.Length - 1)
            i = -1;
        BG.GetComponent<Image>().sprite = sprites[++i];
    }

    public void Previous()
    {
        if (i <= 0)
            i = sprites.Length;
        BG.GetComponent<Image>().sprite = sprites[--i];
    }
    public void SetTime()
    {
        if (study)
            maxTime = 40 * 60;
        else
            maxTime = 20 * 60;
    }
    public void Timer()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            int min = (int)(currentTime / 60);
            int sec = (int)(currentTime % 60);
            if (sec >= 10)
                timer.text = min + ":" + sec;
            else
                timer.text = min + ":0" + sec;
        }
        else
        {
            running = false;
            study = !study;
            Title.SetActive(true);
            if (study)
                start.text = "Start Study";
            else
                start.text = "Start Anime";
            StartButton.SetActive(true);
            PauseButton.SetActive(false);
            timer.gameObject.SetActive(false);
            ResetButton.SetActive(false);
            SkipButton.SetActive(false);
            Add5minButton.SetActive(false);
        }
    }
    public void StartTimer()
    {
        SetTime();
        TimerReset();
        running = true;
        Title.SetActive(false);
        StartButton.SetActive(false);
        PauseButton.SetActive(true);
        timer.gameObject.SetActive(true);
        ResetButton.SetActive(true);
        SkipButton.SetActive(true);
        Add5minButton.SetActive(true);
    }
    public void PauseTimer()
    {
        running = !running;
        if (running == false)
            pause.text = "Resume";
        else
            pause.text = "Pause";
    }
    public void  TimerReset()
    {
        currentTime = maxTime;
        running = true;
    }
    public void Skip()
    {
        currentTime = 0;
        running = true;
    }
    public void Add5min()
    {
        currentTime += 5 * 60;
    }
        
}
