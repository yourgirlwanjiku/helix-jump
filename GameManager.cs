using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro ;
using UnityEngine.UI ;
using UnityEngine.EventSystems; 


public class GameManager : MonoBehaviour
{

    public static bool gameOver ;
    public static bool levelCompleted  ;
    public static bool mute  = false;
    public static bool isGameStarted  ;

    public GameObject gameOverPanel ;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel ;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;
    public Slider gameProgressSlider ;
    public TextMeshProUGUI currentlevelText;
    public TextMeshProUGUI nextlevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    public static int numberOfPassedRings;
    public static int score = 0;
    
    
    private void Awake()
    {
   currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
    
    // Start is called before the first frame update
    void Start()
    {
       Time.timeScale = 1;
       numberOfPassedRings = 0;
        levelCompleted = false ;
        gameOver = false ;
        highScoreText.text= "Best Score\n" +  PlayerPrefs.GetInt("High Score", 0);
    isGameStarted = false ;
        
    }

    // Update is called once per frame
    void Update()
    {   
        //update our ui elements
        currentlevelText.text = currentLevelIndex.ToString();
        nextlevelText.text = (currentLevelIndex +1).ToString();
        

        int progress =numberOfPassedRings*100/ FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value =progress;
      
      scoreText.text =score.ToString();
       //sets the game play panel active when game starts to play
       if(Input.GetMouseButtonDown(0) && !isGameStarted){
          //  if(EventSystem.current.IsPointerOverGameObject())
          if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //pointing over a ui element
             return ;
           isGameStarted = true ; 
           gamePlayPanel.SetActive(true) ; 
           startMenuPanel.SetActive(false) ; 
       }
       
        //gameover
        if(gameOver){
            Time.timeScale =0;
            gameOverPanel.SetActive(true) ;
            if(Input.GetButtonDown("Fire1")){
               if(score> PlayerPrefs.GetInt("HighScore", 0)) {
                   PlayerPrefs.SetInt ("HighScore", score) ;
               }
                 score= 0;
                SceneManager.LoadScene("Level");
            }
        }

        if(levelCompleted){
            
            levelCompletedPanel.SetActive(true) ;
            if(Input.GetButtonDown("Fire1")){

                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex +1)  ;
               
                SceneManager.LoadScene("Level");
            }
        }
    }
}
