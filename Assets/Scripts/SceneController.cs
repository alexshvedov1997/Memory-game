using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    [SerializeField] private TextMesh scoreLabel;
    [SerializeField]
    private MemoryCard originalCard;
    [SerializeField]
    private Sprite[] images;
    private int gridRow = 2;
    private int gridColm = 4;
    private const float offsetX = 2.0f;
    private const float offsetY = 3.5f;
    int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private int score;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }
    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null) _firstRevealed = card;
        else
        {
            _secondRevealed = card;
            // Debug.Log("Match" + (_firstRevealed.id == _secondRevealed.id));
            StartCoroutine(CheckCard());
        }
    }
    IEnumerator CheckCard()
    {
        if(_firstRevealed.id == _secondRevealed.id)
        {
            score++;
            // Debug.Log("Score:" + score);
            scoreLabel.text = "Score:" + score.ToString();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            _firstRevealed.UnReveal();
            _secondRevealed.UnReveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        numbers = ShufflerCard(numbers);
        Vector3 startPos = originalCard.transform.position;
        for(int i =0; i < gridColm; i++)
        {
            for(int j = 0; j < gridRow; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                    card = originalCard;
                else
                    card = Instantiate(originalCard) as MemoryCard;
                int index = j * gridColm + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);
                float posX =  (offsetX * i) + startPos.x;
                float posY = (- offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);

            }
        }
    }
    private int [] ShufflerCard(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for( int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
   public void Restart()
    {
        //  Application.LoadLevel("Scene");
        SceneManager.LoadScene("SampleScene");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
