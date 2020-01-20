using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelController
{
    private static int[] levelReqs = {
        0, 2180, 4710, 6560, 8740, 11260, 14130, 17330, 20900, 24830, 29100, 33780, 38800, 44200, 50000, 56200,
        62700, 70000, 77000, 84700, 92800, 101300, 110200, 120000, 129000, 150000, 160000, 172200, 184000, 196200,
        208800, 221800, 235300, 249200, 263505, 278300, 293400, 309000, 325000, 341500, 358400, 375800, 393500, 411800,
        430500, 449500, 469100, 489110, 509600
    };

    public static int DetermineLevel(int experience)
    {
        for (int i = 0; i < levelReqs.Length; i++)
        {
            if (experience >= levelReqs[i] & experience < levelReqs[i + 1])
            {
                return i + 1;
            }
        }

        //should be impossible, experience always start at at least 0
        return -1;
    }

    public static int DetermineLevel()
    {
        return DetermineLevel(DBManager.experience);
    }
}
