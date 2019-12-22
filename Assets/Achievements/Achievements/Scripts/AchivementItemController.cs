using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchivementItemController : MonoBehaviour
{
    [SerializeField] Image unlockedIcon;
    [SerializeField] Image lockedIcon;

    [SerializeField] Text titleLabel;
    [SerializeField] Text descriptionLabel;

    public bool unlocked;
    public Achievement achievement;

    public void RefereshView() {

        titleLabel.text = achievement.title;
        descriptionLabel.text = achievement.description;

        unlockedIcon.enabled = unlocked;
        lockedIcon.enabled = !unlocked;


    }
    private void OnValidate()
    {
        RefereshView();
    }
}
