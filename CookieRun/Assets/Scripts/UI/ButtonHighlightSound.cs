using Literal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlightSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private AudioSource _audioSource;
    private AudioClip _buttonHighlightSound;
    private AudioClip _buttonOnClickSound;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _buttonHighlightSound = DataManager.LoadAudioClip(AudioClipName.BUTTON_HIGHLIGHT);
        _buttonOnClickSound = DataManager.LoadAudioClip(AudioClipName.BUTTON_CLICK);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        _audioSource.PlayOneShot(_buttonHighlightSound);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_buttonOnClickSound);
    }
}
