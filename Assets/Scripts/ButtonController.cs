using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator _scoreAnimator;
    [SerializeField] private Animator _friendsAnim;
    [SerializeField] private List<ItemDescr> _items;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private RewardButton _rewardButton;
    private bool _isPlaying = true;
    private void Start()
    {
        for (int i = 0; i < SaveData.instance.info.items.Count; i += 2)
        {
            foreach (var it in _items)
            {
                if (SaveData.instance.info.items[i] == it.Price)
                {
                    DisableButton(it);
                    Shop.OnBuyHappened?.Invoke(it);
                }
            }
        }
    }
    public void DisableButton(ItemDescr item)
    {
        _buttons[_items.IndexOf(item)].interactable = false;

    }
    public void SetMusicActive()
    {
        _isPlaying = !_isPlaying;
        _mixer.SetFloat("MasterVolume", _isPlaying ? 0f : -80f);
    }
    public void Reward()
    {
        _rewardButton.Clicked();
    }
    public void PlayAnimScore()
    {
        _scoreAnimator.SetBool("Play", true);
    }
    public void PlayAnimFriends()
    {
        _friendsAnim.SetBool("Play", true);
    }
    public Animator GetAnimatorScore() => _scoreAnimator;
    public Animator GetAnimatorFriends() => _friendsAnim;

}
