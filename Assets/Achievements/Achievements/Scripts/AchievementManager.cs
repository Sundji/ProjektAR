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
    [SerializeField] [HideInInspector]
    private List<AchivementItemController> achivementItems;

    public AchivementDropdownController achivementDropdownController;

    private void Start()
    {
        //   achivementDropdownController.onValueChanged += HandleAchievementDropdownChanged;
        //LoadAchievementsTable();
        ModelBehaviour.ModelVisibleEvent.AddListener(modelPrikazan);
    }

    public void modelPrikazan(string model, string lesson, string text)
    {
        int brojModela = PlayerPrefs.GetInt("BrojUcitanihModela", 0);

        if (brojModela == 0)
            UnlockAchievement(Achievements.PrviSken);
        else if (brojModela == 4)
            UnlockAchievement(Achievements.Skeniranih5);
    }

    private void HandleAchievementDropdownChanged(Achievements achievement)
    {
        achievementToShow = achievement;
    }

    public void showNotification(Achievements achievement1)
    {
        Achievement achievement=database.achievements[(int)achievement1];
        achievementNotificationController.ShowNotification(achievement);
    }
    [ContextMenu("LoadAchievementsTable()")]
    private void LoadAchievementsTable() {
        foreach (AchivementItemController controller in achivementItems) {
            DestroyImmediate(controller.gameObject);
        }
        achivementItems.Clear();
        foreach (Achievement achievement in database.achievements) {

            GameObject obj = Instantiate(achievmentItemPrefab, content);
            AchivementItemController controller = obj.GetComponent<AchivementItemController>();
            bool unlocked = PlayerPrefs.GetInt(achievement.id, 0) == 1;
            controller.unlocked = unlocked;
            controller.achievement = achievement;
            controller.RefereshView();
            achivementItems.Add(controller);
        }
    
    }

    public void UnlockAchievement()
    {
        Achievement achievement = database.achievements[(int)achievementToShow];
        achievementNotificationController.ShowNotification(achievement);

        if (DBManager.LoggedIn) {
            DBManager.AddExperience(2000);
            OnlineDataSave saveData = new OnlineDataSave();
            saveData.CallSavePlayerData();
        }
    }

    public void UnlockAchievement(Achievements achievement1) {

        Achievement achievement = database.achievements[(int)achievement1];
        if (achievement.unlocked) {
            return;
        }
        showNotification(achievement1);
        PlayerPrefs.SetInt(achievement.id, 1);
        achievement.unlocked = true;

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UnlockAchievement(Achievements.PrviKviz);
        }
    }

    //public void lockAllAchievements() {

    //    foreach (Achievement achievement in database.achievements) {

    //        PlayerPrefs.DeleteKey(achievement.id);
    //    }

    //    foreach (AchivementItemController controller in achivementItems) {
    //        controller.unlocked = false;
    //        controller.RefereshView();
    //    }
    //}
}
