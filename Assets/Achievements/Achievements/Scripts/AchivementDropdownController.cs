using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Dropdown))]
public class AchivementDropdownController: MonoBehaviour
{


    private Dropdown m_dropdown;
    public Action<Achievements> onValueChanged;

    private Dropdown Dropdown {


        get {
            if (m_dropdown == null)
            {

                m_dropdown = GetComponent<Dropdown>();
            }
            return m_dropdown;
        }
      

    }
    

    private void Start()
    {
        UpdateOptions();
        Dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);

    }

    private void HandleDropdownValueChanged(int value)
    {

        if (onValueChanged != null) {

            onValueChanged((Achievements)value);
        }


    }

    [ContextMenu("UpdatedOptions()")]
    public void UpdateOptions() {

        Dropdown.options.Clear();
        var values=Enum.GetValues(typeof(Achievements));
        foreach (Achievements achivement in values) {

            Dropdown.options.Add(new Dropdown.OptionData(achivement.ToString()));
        }
        Dropdown.RefreshShownValue();
    }
}
