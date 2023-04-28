using UnityEngine;

public class Section : MonoBehaviour
{

    // private void OnEnable()
    // {
    //     Activate();
    // }

    public void Activate()
    {
        gameObject.SetActive(true);
        
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeftBound"))
        {
            gameObject.SetActive(false);
        }
    }
}
