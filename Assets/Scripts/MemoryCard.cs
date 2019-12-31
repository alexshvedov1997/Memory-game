using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardBack;
    [SerializeField]
    SceneController _controller;
    private int _id;
   

    public int id
    {
        get
        {
            return _id;
        }
    }

    public void SetCard(int id, Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
        _id = id;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (_cardBack.activeSelf && _controller.canReveal)
        {
            _cardBack.SetActive(false);
            _controller.CardRevealed(this);
        }
    }
    public void UnReveal()
    {
        _cardBack.SetActive(true);
    }
}
