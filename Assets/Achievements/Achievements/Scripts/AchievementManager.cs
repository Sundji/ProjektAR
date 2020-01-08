using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public AchievementDatabase database;
    public AchievementNotificationController achievementNotificationController;

    public Achievements achievementToShow;
    public GameObject achievmentItemPrefab;
    public Transform content;
    [SerializeField][HideInInspector]
    private List<AchivementItemController> achivementItems;

    public AchivementDropdownController achivementDropdownController;

    private void Start()
    {
        achivementDropdownController.onValueChanged += HandleAchievementDropdownChanged;
        //LoadAchievementsTable();
    }

    private void HandleAchievementDropdownChanged(Achievements achievement)
    {
        achievementToShow = achievement;
    }

    //public void showNotification()
    //{
    //    Achievement achievement=database.achievements[(int)achievementToShow];
    //    achievementNotificationController.ShowNotification(achievement);
    //}
    //[ContextMenu("LoadAchievementsTable()")]
    //private void LoadAchievementsTable() {
    //    foreach (AchivementItemController controller in achivementItems) {
    //        DestroyImmediate(controller.gameObject);
    //    }
    //    achivementItems.Clear();
    //    foreach (Achievement achievement in database.achievements) {

    //        GameObject obj = Instantiate(achievmentItemPrefab, content);
    //        AchivementItemController controller = obj.GetComponent<AchivementItemController>();
    //        bool unlocked = PlayerPrefs.GetInt(achievement.id, 0) == 1;
    //        controller.unlocked = unlocked;
    //        controller.achievement = achievement;
    //        controller.RefereshView();
    //        achivementItems.Add(controller);
    //    }
    
    }

    //public void UnlockAchievement()
    //{
    //    UnlockAchievement(achievementToShow);
    //}

    //public void UnlockAchievement(Achievements achievement) {

    //    AchivementItemController item = achivementItems[(int)achievement];
    //    if (item.unlocked) {
    //        return;
    //    }
    //    showNotification();
    //    PlayerPrefs.SetInt(item.achievement.id, 1);
    //    item.unlocked = true;
    //    item.RefereshView();

    //}

    //public void lockAllAchievements() {

    //    foreach (Achievement achievement in database.achievements) {

    //        PlayerPrefs.DeleteKey(achievement.id);
    //    }

    //    foreach (AchivementItemController controller in achivementItems) {
    //        controller.unlocked = false;
    //        controller.RefereshView();
    //    }
    //}
//}
