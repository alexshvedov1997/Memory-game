using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] string targetMessage;
    Color highLight = Color.cyan;
     void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite!= null)
        {
            sprite.color = highLight;
        }
    }
    private void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null) sprite.color = Color.white;
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

    }
    private void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if(targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
