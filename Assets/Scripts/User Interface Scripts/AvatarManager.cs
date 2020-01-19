using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AvatarManager : MonoBehaviour
{

    public List<Sprite> Avatars = new List<Sprite>();

    private Image _image;
    private int _index;

    private void Awake()
    {

        if (GetComponent<Image>() == null || Avatars.Count == 0)
            Destroy(gameObject);

        _image = GetComponent<Image>();
        _image.sprite = Avatars[0];

    }

    public string GetAvatarName()
    {
        return _image.sprite.name;
    }

    public void NextAvatar()
    {
        _index = (_index == Avatars.Count - 1) ? _index : _index + 1;
        _image.sprite = Avatars[_index];
    }

    public void PreviousAvatar()
    {
        _index = (_index == 0) ? _index : _index - 1;
        _image.sprite = Avatars[_index];
    }

}
