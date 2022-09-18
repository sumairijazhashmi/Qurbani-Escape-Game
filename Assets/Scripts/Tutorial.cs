using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject audioListener;
    [SerializeField] TMPro.TMP_Text swipeRight;
    [SerializeField] TMPro.TMP_Text swipeLeft;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(audioListener);
    }
    public void Play() {
        audioListener.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
