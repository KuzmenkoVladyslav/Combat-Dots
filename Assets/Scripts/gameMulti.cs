﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMulti : MonoBehaviour
{
    [SerializeField]
    private GameObject firstDot;
    [SerializeField]
    private GameObject secondDot;
    [SerializeField]
    private GameObject first50;
    [SerializeField]
    private GameObject second50;
    [SerializeField]
    private GameObject winner;
    [SerializeField]
    private Text victoryText;
    [SerializeField]
    private GameObject field;
    [SerializeField]
    private GameObject vertical;
    [SerializeField]
    private GameObject horizontal;

    int checking_fir = 0;
    int new_checking_fir = 0;
    int testing_auto_first = 0;
    int checking_sec = 0;
    int new_checking_sec = 0;
    int testing_auto_second = 0;
    int count_mf, count_ms;
    private string lang, theme, modeMenu, modeCount, state = "", sound;
    private Text textFirst, textSecond;
    private GameObject newDot, tempoDot, newLine, newLine2;
    private string[,] gameField = new string[9, 9];
    private float[] tempCoordinats = new float[3];
    private int n, m, endCount, points_first = 0, points_second = 0;
    private List<GameObject> destroyObj = new List<GameObject>();
    private List<GameObject> destroyVictory = new List<GameObject>();
    private List<int[]> lines = new List<int[]>();

    void Start()
    {
        while (lines.Count > 0)
        {
            lines.RemoveAt(0);
        }

        if (!PlayerPrefs.GetString("keySound").Equals("soundOff") && !PlayerPrefs.GetString("keySound").Equals("soundOn"))
        {
            PlayerPrefs.SetString("keySound", "soundOff");
        }
        sound = PlayerPrefs.GetString("keySound");
        field.SetActive(true);
        textFirst = GameObject.Find("pointsFirst").GetComponent<Text>();
        textSecond = GameObject.Find("pointsSecond").GetComponent<Text>();
        winner.SetActive(false);
        theme = PlayerPrefs.GetString("keyTheme");
        lang = PlayerPrefs.GetString("keyLang");
        modeMenu = PlayerPrefs.GetString("keyMode");
        modeCount = PlayerPrefs.GetString("keyCount");

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                gameField[i, j] = "neutral";
            }
        }
        gameField[4, 0] = "pre-first";
        gameField[3, 8] = "pre-second";
        gameField[5, 8] = "pre-second";

        if (modeMenu.Equals("Tactic"))
        {
            switch (modeCount)
            {
                case "Two":
                    Creating_Coordinates();
                    break;
                case "Four":
                    Creating_Coordinates();
                    Creating_Coordinates();
                    break;
                case "Six":
                    Creating_Coordinates();
                    Creating_Coordinates();
                    Creating_Coordinates();
                    break;
            }
        }

        Create();
        state = "FIRST TURN START";
    }

    private void Creating_Coordinates()
    {
        int dot_x = 0, dot_y = 0, dot_x2 = 0, dot_y2 = 0, rand_dot;

        dot_x = Random.Range(0, 8);
        dot_y = Random.Range(0, 8);

        if (dot_x == 0)
        {
            if (dot_y == 0)
            {
                rand_dot = Random.Range(0, 2);
                if (rand_dot == 0)
                {
                    dot_x2 = 1;
                    dot_y2 = 0;
                }
                else
                {
                    dot_x2 = 0;
                    dot_y2 = 1;
                }
            }
            if (dot_y == 7)
            {
                rand_dot = Random.Range(0, 2);
                if (rand_dot == 0)
                {
                    dot_x2 = 1;
                    dot_y2 = 7;
                }
                else
                {
                    dot_x2 = 0;
                    dot_y2 = 6;
                }
            }
            if (dot_y != 0 && dot_y != 7)
            {
                rand_dot = Random.Range(0, 3);
                if (rand_dot == 0)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y - 1;
                }
                if (rand_dot == 1)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y + 1;
                }
                if (rand_dot == 2)
                {
                    dot_x2 = dot_x + 1;
                    dot_y2 = dot_y;
                }
            }
        }
        if (dot_x == 7)
        {
            if (dot_y == 0)
            {
                rand_dot = Random.Range(0, 2);
                if (rand_dot == 0)
                {
                    dot_x2 = 6;
                    dot_y2 = 0;
                }
                else
                {
                    dot_x2 = 7;
                    dot_y2 = 1;
                }
            }
            if (dot_y == 7)
            {
                rand_dot = Random.Range(0, 2);
                if (rand_dot == 0)
                {
                    dot_x2 = 6;
                    dot_y2 = 7;
                }
                else
                {
                    dot_x2 = 7;
                    dot_y2 = 6;
                }
            }
            if (dot_y != 0 && dot_y != 7)
            {
                rand_dot = Random.Range(0, 3);
                if (rand_dot == 0)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y - 1;
                }
                if (rand_dot == 1)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y + 1;
                }
                if (rand_dot == 2)
                {
                    dot_x2 = dot_x - 1;
                    dot_y2 = dot_y;
                }
            }
        }
        if (dot_x != 0 && dot_x != 7)
        {
            if (dot_y == 0)
            {
                rand_dot = Random.Range(0, 3);
                if (rand_dot == 0)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y + 1;
                }
                if (rand_dot == 1)
                {
                    dot_x2 = dot_x - 1;
                    dot_y2 = dot_y;
                }
                if (rand_dot == 2)
                {
                    dot_x2 = dot_x + 1;
                    dot_y2 = dot_y;
                }
            }
            if (dot_y == 7)
            {
                rand_dot = Random.Range(0, 3);
                if (rand_dot == 0)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y - 1;
                }
                if (rand_dot == 1)
                {
                    dot_x2 = dot_x - 1;
                    dot_y2 = dot_y;
                }
                if (rand_dot == 2)
                {
                    dot_x2 = dot_x + 1;
                    dot_y2 = dot_y;
                }
            }
            if (dot_y != 0 && dot_y != 7)
            {
                rand_dot = Random.Range(0, 4);
                if (rand_dot == 0)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y - 1;
                }
                if (rand_dot == 1)
                {
                    dot_x2 = dot_x;
                    dot_y2 = dot_y + 1;
                }
                if (rand_dot == 2)
                {
                    dot_x2 = dot_x - 1;
                    dot_y2 = dot_y;
                }
                if (rand_dot == 3)
                {
                    dot_x2 = dot_x + 1;
                    dot_y2 = dot_y;
                }
            }
        }

        Creating_Line(dot_x, dot_x2, dot_y, dot_y2);

        //print("1. " + dot_x + " " + dot_x2 + " " + dot_y + " " + dot_y2);

        lines.Add(new int[4] { dot_x, dot_x2, dot_y, dot_y2 });

        dot_x = 7 - dot_x;
        dot_x2 = 7 - dot_x2;
        dot_y = 7 - dot_y;
        dot_y2 = 7 - dot_y2;

        if (dot_x == dot_x2)
        {
            dot_y++;
            dot_y2++;          
        }
        else
        {
            dot_x++;
            dot_x2++;
        }

        lines.Add(new int[4] { dot_x, dot_x2, dot_y, dot_y2 });
        //print("2. " + dot_x + " " + dot_x2 + " " + dot_y + " " + dot_y2);
    }

    private void Creating_Line(int x1, int x2, int y1, int y2)
    {
        float temp_x = 0f, temp_y = 0f;

        if (x1 == x2)
        {
            switch (x1)
            {
                case 0:
                    temp_y = 2.62f;
                    break;
                case 1:
                    temp_y = 1.87f;
                    break;
                case 2:
                    temp_y = 1.12f;
                    break;
                case 3:
                    temp_y = 0.37f;
                    break;
                case 4:
                    temp_y = -0.37f;
                    break;
                case 5:
                    temp_y = -1.12f;
                    break;
                case 6:
                    temp_y = -1.87f;
                    break;
                case 7:
                    temp_y = -2.62f;
                    break;
            }
            if (y1 < y2)
            {
                switch (y1)
                {
                    case 0:
                        temp_x = -2.62f;
                        break;
                    case 1:
                        temp_x = -1.87f;
                        break;
                    case 2:
                        temp_x = -1.12f;
                        break;
                    case 3:
                        temp_x = -0.37f;
                        break;
                    case 4:
                        temp_x = 0.37f;
                        break;
                    case 5:
                        temp_x = 1.12f;
                        break;
                    case 6:
                        temp_x = 1.87f;
                        break;
                    case 7:
                        temp_x = 2.62f;
                        break;
                }
            }
            else
            {
                switch (y2)
                {
                    case 0:
                        temp_x = -2.62f;
                        break;
                    case 1:
                        temp_x = -1.87f;
                        break;
                    case 2:
                        temp_x = -1.12f;
                        break;
                    case 3:
                        temp_x = -0.37f;
                        break;
                    case 4:
                        temp_x = 0.37f;
                        break;
                    case 5:
                        temp_x = 1.12f;
                        break;
                    case 6:
                        temp_x = 1.87f;
                        break;
                    case 7:
                        temp_x = 2.62f;
                        break;
                }
            }

            newLine = Instantiate(horizontal, horizontal.transform.position, Quaternion.identity) as GameObject;
            newLine.transform.position = new Vector3(temp_x, temp_y, 0);
            destroyVictory.Add(newLine);
            newLine2 = Instantiate(horizontal, horizontal.transform.position, Quaternion.identity) as GameObject;
            newLine2.transform.position = new Vector3(temp_x * (-1), temp_y * (-1), 0);
            destroyVictory.Add(newLine2);
        }
        else
        {
            switch (y1)
            {
                case 0:
                    temp_x = 2.62f;
                    break;
                case 1:
                    temp_x = 1.87f;
                    break;
                case 2:
                    temp_x = 1.12f;
                    break;
                case 3:
                    temp_x = 0.37f;
                    break;
                case 4:
                    temp_x = -0.37f;
                    break;
                case 5:
                    temp_x = -1.12f;
                    break;
                case 6:
                    temp_x = -1.87f;
                    break;
                case 7:
                    temp_x = -2.62f;
                    break;
            }
            if (x1 < x2)
            {
                switch (x1)
                {
                    case 0:
                        temp_y = -2.62f;
                        break;
                    case 1:
                        temp_y = -1.87f;
                        break;
                    case 2:
                        temp_y = -1.12f;
                        break;
                    case 3:
                        temp_y = -0.37f;
                        break;
                    case 4:
                        temp_y = 0.37f;
                        break;
                    case 5:
                        temp_y = 1.12f;
                        break;
                    case 6:
                        temp_y = 1.87f;
                        break;
                    case 7:
                        temp_y = 2.62f;
                        break;
                }
            }
            else
            {
                switch (x2)
                {
                    case 0:
                        temp_y = -2.62f;
                        break;
                    case 1:
                        temp_y = -1.87f;
                        break;
                    case 2:
                        temp_y = -1.12f;
                        break;
                    case 3:
                        temp_y = -0.37f;
                        break;
                    case 4:
                        temp_y = 0.37f;
                        break;
                    case 5:
                        temp_y = 1.12f;
                        break;
                    case 6:
                        temp_y = 1.87f;
                        break;
                    case 7:
                        temp_y = 2.62f;
                        break;
                }
            }

            newLine = Instantiate(vertical, vertical.transform.position, Quaternion.identity) as GameObject;
            newLine.transform.position = new Vector3(temp_x, temp_y, 0);
            destroyVictory.Add(newLine);
            newLine2 = Instantiate(vertical, vertical.transform.position, Quaternion.identity) as GameObject;
            newLine2.transform.position = new Vector3(temp_x * (-1), temp_y * (-1), 0);
            destroyVictory.Add(newLine2);
        }
        newLine.SetActive(true);
        newLine2.SetActive(true);
    }

    private void Create()
    {
        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("maybe first") || gameField[i, j].Equals("maybe second"))
                {
                    gameField[i, j] = "neutral";
                }
                if (gameField[i, j].Equals("pre-first"))
                {
                    newDot = Instantiate(firstDot, firstDot.transform.position, Quaternion.identity) as GameObject;
                    if (i != 4)
                    {
                        newDot.transform.position = new Vector3(firstDot.transform.position.x, firstDot.transform.position.y + (3 - (i * 0.75f)), firstDot.transform.position.z);
                    }
                    newDot.transform.position = new Vector3(newDot.transform.position.x + j * 0.75f, newDot.transform.position.y, firstDot.transform.position.z);
                    newDot.SetActive(true);
                    destroyVictory.Add(newDot);
                    gameField[i, j] = "first";
                    Points();
                    EndGame();

                }

                if (gameField[i, j].Equals("pre-second"))
                {
                    newDot = Instantiate(secondDot, secondDot.transform.position, Quaternion.identity) as GameObject;
                    if (i != 4)
                    {
                        newDot.transform.position = new Vector3(secondDot.transform.position.x, secondDot.transform.position.y + (3 - (i * 0.75f)), secondDot.transform.position.z);
                    }
                    newDot.transform.position = new Vector3(newDot.transform.position.x + (j * 0.75f - 6), newDot.transform.position.y, secondDot.transform.position.z);
                    newDot.SetActive(true);
                    destroyVictory.Add(newDot);
                    gameField[i, j] = "second";
                    Points();
                    EndGame();
                }
            }
        }
    }

    private void Maybe_first()
    {
        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("first"))
                {
                    if (i > 0 && gameField[i - 1, j].Equals("neutral"))
                    {
                        gameField[i - 1, j] = "maybe first";
                    }

                    if (j > 0 && gameField[i, j - 1].Equals("neutral"))
                    {
                        gameField[i, j - 1] = "maybe first";
                    }

                    if (i > 0 && j > 0 && gameField[i - 1, j - 1].Equals("neutral"))
                    {
                        gameField[i - 1, j - 1] = "maybe first";
                    }

                    if (j < 8 && gameField[i, j + 1].Equals("neutral"))
                    {
                        gameField[i, j + 1] = "maybe first";
                    }

                    if (i < 8 && gameField[i + 1, j].Equals("neutral"))
                    {
                        gameField[i + 1, j] = "maybe first";
                    }

                    if (i < 8 && j < 8 && gameField[i + 1, j + 1].Equals("neutral"))
                    {
                        gameField[i + 1, j + 1] = "maybe first";
                    }

                    if (i < 8 && j > 0 && gameField[i + 1, j - 1].Equals("neutral"))
                    {
                        gameField[i + 1, j - 1] = "maybe first";
                    }

                    if (i > 0 && j < 8 && gameField[i - 1, j + 1].Equals("neutral"))
                    {
                        gameField[i - 1, j + 1] = "maybe first";
                    }
                }
            }
        }

        if (modeMenu.Equals("Tactic"))
        {
            switch (modeCount)
            {
                case "Two":
                    Tactical_maybe(lines[0][0], lines[0][1], lines[0][2], lines[0][3], "first", "maybe first");
                    Tactical_maybe(lines[1][0], lines[1][1], lines[1][2], lines[1][3], "first", "maybe first");
                    break;
                case "Four":
                    Tactical_maybe(lines[0][0], lines[0][1], lines[0][2], lines[0][3], "first", "maybe first");
                    Tactical_maybe(lines[1][0], lines[1][1], lines[1][2], lines[1][3], "first", "maybe first");
                    Tactical_maybe(lines[2][0], lines[2][1], lines[2][2], lines[2][3], "first", "maybe first");
                    Tactical_maybe(lines[3][0], lines[3][1], lines[3][2], lines[3][3], "first", "maybe first");
                    break;
                case "Six":
                    Tactical_maybe(lines[0][0], lines[0][1], lines[0][2], lines[0][3], "first", "maybe first");
                    Tactical_maybe(lines[1][0], lines[1][1], lines[1][2], lines[1][3], "first", "maybe first");
                    Tactical_maybe(lines[2][0], lines[2][1], lines[2][2], lines[2][3], "first", "maybe first");
                    Tactical_maybe(lines[3][0], lines[3][1], lines[3][2], lines[3][3], "first", "maybe first");
                    Tactical_maybe(lines[4][0], lines[4][1], lines[4][2], lines[4][3], "first", "maybe first");
                    Tactical_maybe(lines[5][0], lines[5][1], lines[5][2], lines[5][3], "first", "maybe first");
                    break;
            }

            count_mf = 0;

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j].Equals("maybe first"))
                    {
                        count_mf++;
                    }
                }
            }

            if (count_mf == 0 && count_ms == 0)
            {
                state = "END GAME";

                Handheld.Vibrate();

                winner.SetActive(true);

                field.SetActive(false);

                for (int i = 0; i < destroyVictory.Count; i++)
                {
                    Destroy(destroyVictory[i]);
                }

                if (lang.Equals("Ukrainian"))
                {
                    uaRules uatxt = (uaRules)FindObjectOfType(typeof(uaRules));
                    victoryText.text = uatxt.UkrTittles[6];
                }
                if (lang.Equals("Russian"))
                {
                    ruRules rutxt = (ruRules)FindObjectOfType(typeof(ruRules));
                    victoryText.text = rutxt.RusTittles[6];
                }
                if (lang.Equals("English"))
                {
                    enRules entxt = (enRules)FindObjectOfType(typeof(enRules));
                    victoryText.text = entxt.EngTittles[6];
                }

                if (points_first > points_second)
                {
                    if (theme == "light")
                    {
                        victoryText.color = Color.red;
                    }
                    else
                    {
                        victoryText.color = Color.yellow;
                    }
                }
                else
                {
                    if (theme == "light")
                    {
                        victoryText.color = Color.blue;
                    }
                    else
                    {
                        victoryText.color = Color.cyan;
                    }
                }
            }
            else if (count_mf == 0)
            {
                state = "SECOND TURN START";
                TurnSecond();                
            }
        }        
    }

    private void Maybe_second()
    {
        for (int c = 0; c < gameField.GetLength(0); c++)
        {
            for (int v = 0; v < gameField.GetLength(1); v++)
            {
                if (gameField[c, v].Equals("second"))
                {
                    if (c > 0 && gameField[c - 1, v].Equals("neutral"))
                    {
                        gameField[c - 1, v] = "maybe second";
                    }

                    if (v > 0 && gameField[c, v - 1].Equals("neutral"))
                    {
                        gameField[c, v - 1] = "maybe second";
                    }

                    if (c > 0 && v > 0 && gameField[c - 1, v - 1].Equals("neutral"))
                    {
                        gameField[c - 1, v - 1] = "maybe second";
                    }

                    if (v < 8 && gameField[c, v + 1].Equals("neutral"))
                    {
                        gameField[c, v + 1] = "maybe second";
                    }

                    if (c < 8 && gameField[c + 1, v].Equals("neutral"))
                    {
                        gameField[c + 1, v] = "maybe second";
                    }

                    if (c < 8 && v < 8 && gameField[c + 1, v + 1].Equals("neutral"))
                    {
                        gameField[c + 1, v + 1] = "maybe second";
                    }

                    if (c < 8 && v > 0 && gameField[c + 1, v - 1].Equals("neutral"))
                    {
                        gameField[c + 1, v - 1] = "maybe second";
                    }

                    if (c > 0 && v < 8 && gameField[c - 1, v + 1].Equals("neutral"))
                    {
                        gameField[c - 1, v + 1] = "maybe second";
                    }
                }
            }
        }

        if (modeMenu.Equals("Tactic"))
        {
            switch (modeCount)
            {
                case "Two":
                    Tactical_maybe(lines[0][0], lines[0][1], lines[0][2], lines[0][3], "second", "maybe second");
                    Tactical_maybe(lines[1][0], lines[1][1], lines[1][2], lines[1][3], "second", "maybe second");
                    break;
                case "Four":
                    Tactical_maybe(lines[0][0], lines[0][1], lines[0][2], lines[0][3], "second", "maybe second");
                    Tactical_maybe(lines[1][0], lines[1][1], lines[1][2], lines[1][3], "second", "maybe second");
                    Tactical_maybe(lines[2][0], lines[2][1], lines[2][2], lines[2][3], "second", "maybe second");
                    Tactical_maybe(lines[3][0], lines[3][1], lines[3][2], lines[3][3], "second", "maybe second");
                    break;
                case "Six":
                    Tactical_maybe(lines[0][0], lines[0][1], lines[0][2], lines[0][3], "second", "maybe second");
                    Tactical_maybe(lines[1][0], lines[1][1], lines[1][2], lines[1][3], "second", "maybe second");
                    Tactical_maybe(lines[2][0], lines[2][1], lines[2][2], lines[2][3], "second", "maybe second");
                    Tactical_maybe(lines[3][0], lines[3][1], lines[3][2], lines[3][3], "second", "maybe second");
                    Tactical_maybe(lines[4][0], lines[4][1], lines[4][2], lines[4][3], "second", "maybe second");
                    Tactical_maybe(lines[5][0], lines[5][1], lines[5][2], lines[5][3], "second", "maybe second");
                    break;
            }

            count_ms = 0;

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j].Equals("maybe second"))
                    {
                        count_ms++;
                    }
                }
            }

            if (count_ms == 0 && count_mf == 0)
            {
                state = "END GAME";

                Handheld.Vibrate();

                winner.SetActive(true);

                field.SetActive(false);

                for (int i = 0; i < destroyVictory.Count; i++)
                {
                    Destroy(destroyVictory[i]);
                }

                if (lang.Equals("Ukrainian"))
                {
                    uaRules uatxt = (uaRules)FindObjectOfType(typeof(uaRules));
                    victoryText.text = uatxt.UkrTittles[6];
                }
                if (lang.Equals("Russian"))
                {
                    ruRules rutxt = (ruRules)FindObjectOfType(typeof(ruRules));
                    victoryText.text = rutxt.RusTittles[6];
                }
                if (lang.Equals("English"))
                {
                    enRules entxt = (enRules)FindObjectOfType(typeof(enRules));
                    victoryText.text = entxt.EngTittles[6];
                }

                if (points_first > points_second)
                {
                    if (theme == "light")
                    {
                        victoryText.color = Color.red;
                    }
                    else
                    {
                        victoryText.color = Color.yellow;
                    }
                }
                else
                {
                    if (theme == "light")
                    {
                        victoryText.color = Color.blue;
                    }
                    else
                    {
                        victoryText.color = Color.cyan;
                    }
                }
            }
            else if (count_ms == 0)
            {
                state = "FIRST TURN START";
                TurnFirst();                
            }
        }        
    }
       
    private void Tactical_maybe(int tempo_x11, int tempo_x12, int tempo_y11, int tempo_y12, string player, string maybe)
    {
        if (tempo_x11 == tempo_x12)
        {
            if (tempo_y11 < tempo_y12)
            {
                if (gameField[tempo_x11, tempo_y11].Equals(player))
                {
                    if (gameField[tempo_x11 + 1, tempo_y11].Equals(maybe))
                    {
                        if (tempo_y11 > 0)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player))
                                        {
                                            gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_y11 < 7)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                    )
                                {
                                    gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x11, tempo_y11 + 1].Equals(player))
                {
                    if (gameField[tempo_x11 + 1, tempo_y11].Equals(maybe))
                    {
                        if (tempo_y11 > 0)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player))
                                        {
                                            gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_y11 < 7)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                    )
                                {
                                    gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }

                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x11 + 1, tempo_y11].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y11].Equals(maybe))
                    {
                        if (tempo_y11 > 0)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x11, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_y11 < 7)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (!gameField[tempo_x11, tempo_y11].Equals(player))
                                {
                                    gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y11].Equals(maybe))
                    {
                        if (tempo_y11 > 0)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x11, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_y11 < 7)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (!gameField[tempo_x11, tempo_y11].Equals(player))
                                {
                                    gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (gameField[tempo_x11, tempo_y12].Equals(player))
                {
                    if (gameField[tempo_x11 + 1, tempo_y12].Equals(maybe))
                    {
                        if (tempo_y12 > 0)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player))
                                        {
                                            gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(maybe))
                    {
                        if (tempo_y12 < 7)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (!gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y12 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                    )
                                {
                                    gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12 + 2].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12].Equals(player))
                                        {
                                            gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x11, tempo_y12 + 1].Equals(player))
                {
                    if (gameField[tempo_x11 + 1, tempo_y12].Equals(maybe))
                    {
                        if (tempo_y12 > 0)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 - 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player))
                                        {
                                            gameField[tempo_x11 + 1, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(maybe))
                    {
                        if (tempo_y12 < 7)
                        {
                            if (tempo_x11 < 7)
                            {
                                if (!gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y12 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                    )
                                {
                                    gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12 + 2].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 < 7)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }

                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y12].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x11 + 1, tempo_y12].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y12].Equals(maybe))
                    {
                        if (tempo_y12 > 0)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y12].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y12] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12 + 1].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y12] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x11, tempo_y12 + 1].Equals(maybe))
                    {
                        if (tempo_y12 < 7)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (!gameField[tempo_x11, tempo_y12].Equals(player))
                                {
                                    gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x11 + 1, tempo_y12 + 1].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y12].Equals(maybe))
                    {
                        if (tempo_y12 > 0)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y12].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y12 < 8)
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11, tempo_y12 - 1].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y12] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y12].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y12] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12 + 1].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y12] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x11, tempo_y12 + 1].Equals(maybe))
                    {
                        if (tempo_y12 < 7)
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y12 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_x11 > 0)
                            {
                                if (tempo_y12 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y12].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y12].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (!gameField[tempo_x11, tempo_y12].Equals(player))
                                {
                                    gameField[tempo_x11, tempo_y12 + 1] = "neutral";
                                }
                            }
                        }
                    }
                }
            }
        }
        //tut
        else
        {
            if (tempo_x11 < tempo_x12)
            {
                if (gameField[tempo_x11, tempo_y11].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x11 > 0)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }                                    
                                }                                
                            }
                        }
                    }

                    if (gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x11 < 7)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                    )
                                {
                                    gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 + 2, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                        }
                    }
                }

                if (gameField[tempo_x11 + 1, tempo_y11].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x11 > 0)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 2].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8 && tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                        }
                    }

                    if (gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x11 < 7)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                    )
                                {
                                    gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if ( !gameField[tempo_x11 + 2, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }                                
                            }
                        }
                    }
                }

                if (gameField[tempo_x11, tempo_y11 + 1].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x11 > 0)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                        }
                    }

                    if (gameField[tempo_x11 + 1, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x11 < 7)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (!gameField[tempo_x11, tempo_y11].Equals(player))
                                {
                                    gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x11 + 1, tempo_y11 + 1].Equals(player))
                {
                    if (gameField[tempo_x11, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x11 > 0)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x11 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x11 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x11, tempo_y11] = "neutral";
                                        }
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11 - 1].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11 + 1, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x11, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                        }
                    }

                    if (gameField[tempo_x11 + 1, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x11 < 7)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x11 < 8)
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x11 + 1, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x11, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x11, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                    }
                                }                                
                            }
                            else
                            {
                                if (!gameField[tempo_x11, tempo_y11].Equals(player))
                                {
                                    gameField[tempo_x11 + 1, tempo_y11] = "neutral";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (gameField[tempo_x12, tempo_y11].Equals(player))
                {
                    if (gameField[tempo_x12, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x12 > 0)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 2].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8 && tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x12 < 7)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x12 + 2, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                    )
                                {
                                    gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12 + 2, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x12 + 1, tempo_y11].Equals(player))
                {
                    if (gameField[tempo_x12, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x12 > 0)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 - 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 2].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8 && tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(maybe))
                    {
                        if (tempo_x12 < 7)
                        {
                            if (tempo_y11 < 7)
                            {
                                if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x12 + 2, tempo_y11 + 2].Equals(player) &&
                                    !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player) &&
                                    !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                    )
                                {
                                    gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12 + 2, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 < 7)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 + 2].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 + 1].Equals(player))
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11 + 1] = "neutral";
                                    }
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x12, tempo_y11 + 1].Equals(player))
                {
                    if (gameField[tempo_x12, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x12 > 0)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11 - 1].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12 + 1, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x12 + 1, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x12 < 7)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (!gameField[tempo_x12, tempo_y11].Equals(player))
                                {
                                    gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                }
                            }
                        }
                    }
                }

                if (gameField[tempo_x12 + 1, tempo_y11 + 1].Equals(player))
                {
                    if (gameField[tempo_x12, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x12 > 0)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11 - 1].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12, tempo_y11 - 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                                else
                                {
                                    if (tempo_y11 < 8)
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player) &&
                                            !gameField[tempo_x12 - 1, tempo_y11 + 1].Equals(player)
                                            )
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                    else
                                    {
                                        if (!gameField[tempo_x12 - 1, tempo_y11].Equals(player))
                                        {
                                            gameField[tempo_x12, tempo_y11] = "neutral";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11 - 1].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12 + 1, tempo_y11].Equals(player))
                                    {
                                        gameField[tempo_x12, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                    }

                    if (gameField[tempo_x12 + 1, tempo_y11].Equals(maybe))
                    {
                        if (tempo_x12 < 7)
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (tempo_y11 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11 + 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12 + 2, tempo_y11].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tempo_y11 > 0)
                            {
                                if (tempo_x12 < 8)
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player) &&
                                        !gameField[tempo_x12 + 1, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                                else
                                {
                                    if (!gameField[tempo_x12, tempo_y11].Equals(player) &&
                                        !gameField[tempo_x12, tempo_y11 - 1].Equals(player)
                                        )
                                    {
                                        gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                    }
                                }
                            }
                            else
                            {
                                if (!gameField[tempo_x12, tempo_y11].Equals(player))
                                {
                                    gameField[tempo_x12 + 1, tempo_y11] = "neutral";
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void TurnFirst()
    {
        if (state.Equals("FIRST TURN START"))
        {
            Maybe_first();

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j].Equals("maybe first"))
                    {
                        newDot = Instantiate(first50, first50.transform.position, Quaternion.identity) as GameObject;
                        if (i != 4)
                        {
                            newDot.transform.position = new Vector3(first50.transform.position.x, first50.transform.position.y + (3 - (i * 0.75f)), first50.transform.position.z);
                        }
                        newDot.transform.position = new Vector3(newDot.transform.position.x + j * 0.75f, newDot.transform.position.y, first50.transform.position.z);
                        newDot.SetActive(true);
                        destroyObj.Add(newDot);
                    }
                }
            }
            state = "WAITING FOR FIRST COORDINATES";
        }
    }

    private void EndFirst()
    {
        if (sound.Equals("soundOn"))
        {
            GetComponent<AudioManager>().Play("dot");
        }
        
        switch (tempCoordinats[0])
        {
            case -3:
                m = 0;
                break;

            case -2.25f:
                m = 1;
                break;

            case -1.5f:
                m = 2;
                break;

            case -0.75f:
                m = 3;
                break;

            case 0:
                m = 4;
                break;

            case 0.75f:
                m = 5;
                break;

            case 1.5f:
                m = 6;
                break;

            case 2.25f:
                m = 7;
                break;

            case 3:
                m = 8;
                break;
        }

        switch (tempCoordinats[1])
        {
            case 3:
                n = 0;
                break;

            case 2.25f:
                n = 1;
                break;

            case 1.5f:
                n = 2;
                break;

            case 0.75f:
                n = 3;
                break;

            case 0:
                n = 4;
                break;

            case -0.75f:
                n = 5;
                break;

            case -1.5f:
                n = 6;
                break;

            case -2.25f:
                n = 7;
                break;

            case -3:
                n = 8;
                break;
        }

        gameField[n, m] = "pre-first";
        Create();
        Checking_first();

        for (int i = 0; i < destroyObj.Count; i++)
        {
            Destroy(destroyObj[i]);
        }

        state = "SECOND TURN START";
    }

    void TurnSecond()
    {
        if (state.Equals("SECOND TURN START"))
        {
            Maybe_second();

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j].Equals("maybe second"))
                    {
                        newDot = Instantiate(second50, second50.transform.position, Quaternion.identity) as GameObject;
                        if (i != 4)
                        {
                            newDot.transform.position = new Vector3(second50.transform.position.x, second50.transform.position.y + (3 - (i * 0.75f)), second50.transform.position.z);
                        }
                        newDot.transform.position = new Vector3(newDot.transform.position.x + (j * 0.75f - 6), newDot.transform.position.y, second50.transform.position.z);
                        newDot.SetActive(true);
                        destroyObj.Add(newDot);
                    }
                }
            }
            state = "WAITING FOR SECOND COORDINATES";
        }
    }

    private void EndSecond()
    {
        if (sound.Equals("soundOn"))
        {
            GetComponent<AudioManager>().Play("dot");
        }

        switch (tempCoordinats[0])
        {
            case -3:
                m = 0;
                break;
            case -2.25f:
                m = 1;
                break;
            case -1.5f:
                m = 2;
                break;
            case -0.75f:
                m = 3;
                break;
            case 0:
                m = 4;
                break;
            case 0.75f:
                m = 5;
                break;
            case 1.5f:
                m = 6;
                break;
            case 2.25f:
                m = 7;
                break;
            case 3:
                m = 8;
                break;
        }

        switch (tempCoordinats[1])
        {
            case 3:
                n = 0;
                break;
            case 2.25f:
                n = 1;
                break;
            case 1.5f:
                n = 2;
                break;
            case 0.75f:
                n = 3;
                break;
            case 0:
                n = 4;
                break;
            case -0.75f:
                n = 5;
                break;
            case -1.5f:
                n = 6;
                break;
            case -2.25f:
                n = 7;
                break;
            case -3:
                n = 8;
                break;
        }

        gameField[n, m] = "pre-second";
        Create();
        Checking_second();

        for (int i = 0; i < destroyObj.Count; i++)
        {
            Destroy(destroyObj[i]);
        }        

        state = "FIRST TURN START";
    }

    public void Coordinates(float x, float y, float z)
    {
        if (state.Equals("WAITING FOR FIRST COORDINATES"))
        {
            tempCoordinats[0] = x;
            tempCoordinats[1] = y;
            tempCoordinats[2] = z;
            EndFirst();
        }

        if (state.Equals("WAITING FOR SECOND COORDINATES"))
        {
            tempCoordinats[0] = x;
            tempCoordinats[1] = y;
            tempCoordinats[2] = z;
            EndSecond();
        }
    }    

    private void Checking_first()
    {
        checking_fir = 0;
        new_checking_fir = 0;

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("neutral"))
                {
                    gameField[i, j] = "auto-first";
                }
            }
        }
        
        checking_fir = Auto_First();
        new_checking_fir = Auto_First();

        while (checking_fir != new_checking_fir) {
            checking_fir = new_checking_fir;
            new_checking_fir = Auto_First();
        }

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("auto-first"))
                {
                    gameField[i, j] = "pre-first";
                }
            }
        }

        Create();
    }

    private int Auto_First()
    {
        testing_auto_first = 0;

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("auto-first"))
                {
                    if (i > 0 && gameField[i - 1, j].Equals("second") || i > 0 && gameField[i - 1, j].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (j > 0 && gameField[i, j - 1].Equals("second") || j > 0 && gameField[i, j - 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i > 0 && j > 0 && gameField[i - 1, j - 1].Equals("second") || i > 0 && j > 0 && gameField[i - 1, j - 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (j < 8 && gameField[i, j + 1].Equals("second") || j < 8 &&  gameField[i, j + 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i < 8 && gameField[i + 1, j].Equals("second") || i < 8 && gameField[i + 1, j].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i < 8 && j < 8 && gameField[i + 1, j + 1].Equals("second") || i < 8 && j < 8 && gameField[i + 1, j + 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i < 8 && j > 0 && gameField[i + 1, j - 1].Equals("second") || i < 8 && j > 0 && gameField[i + 1, j - 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i > 0 && j < 8 && gameField[i - 1, j + 1].Equals("second") || i > 0 && j < 8 && gameField[i - 1, j + 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }
                }
            }
        }

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("auto-first"))
                {
                    testing_auto_first++;
                }
            }
        }

        return testing_auto_first;
    }

    private void Checking_second()
    {
        checking_sec = 0;
        new_checking_sec = 0;

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("neutral"))
                {
                    gameField[i, j] = "auto-second";
                }
            }
        }

        checking_sec = Auto_Second();
        new_checking_sec = Auto_Second();

        while (checking_sec != new_checking_sec)
        {
            checking_sec = new_checking_sec;
            new_checking_sec = Auto_Second();
        }

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("auto-second"))
                {
                    gameField[i, j] = "pre-second";
                }
            }
        }

        Create();
    }

    private int Auto_Second()
    {
        testing_auto_second = 0;

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("auto-second"))
                {
                    if (i > 0 && gameField[i - 1, j].Equals("first") || i > 0 && gameField[i - 1, j].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (j > 0 && gameField[i, j - 1].Equals("first") || j > 0 && gameField[i, j - 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i > 0 && j > 0 && gameField[i - 1, j - 1].Equals("first") || i > 0 && j > 0 && gameField[i - 1, j - 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (j < 8 && gameField[i, j + 1].Equals("first") || j < 8 && gameField[i, j + 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i < 8 && gameField[i + 1, j].Equals("first") || i < 8 && gameField[i + 1, j].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i < 8 && j < 8 && gameField[i + 1, j + 1].Equals("first") || i < 8 && j < 8 && gameField[i + 1, j + 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i < 8 && j > 0 && gameField[i + 1, j - 1].Equals("first") || i < 8 && j > 0 && gameField[i + 1, j - 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }

                    if (i > 0 && j < 8 && gameField[i - 1, j + 1].Equals("first") || i > 0 && j < 8 && gameField[i - 1, j + 1].Equals("neutral"))
                    {
                        gameField[i, j] = "neutral";
                    }
                }
            }
        }

        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("auto-second"))
                {
                    testing_auto_second++;
                }
            }
        }

        return testing_auto_second;
    }

    private void Update()
    {
        TurnFirst();
        TurnSecond();
    }

    void Points() {
        points_first = 0;
        points_second = 0;
        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("first"))
                {
                    points_first += (j + 1);
                }
                if (gameField[i, j].Equals("second"))
                {
                    points_second += (9-j);
                }
            }
        }

        textFirst.text = points_first.ToString();
        textSecond.text = points_second.ToString();

    }

    void EndGame()
    {
        endCount = 0;
        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                if (gameField[i, j].Equals("first") || gameField[i, j].Equals("second"))
                {
                    endCount++;
                }
            }
        }

        if (endCount == 81)
        {
            state="END GAME";

            Handheld.Vibrate();

            winner.SetActive(true);

            field.SetActive(false);

            for (int i = 0; i < destroyVictory.Count; i++)
            {
                Destroy(destroyVictory[i]);
            }

            if (lang.Equals("Ukrainian"))
            {
                uaRules uatxt = (uaRules)FindObjectOfType(typeof(uaRules));
                victoryText.text = uatxt.UkrTittles[6];               
            }
            if (lang.Equals("Russian"))
            {
                ruRules rutxt = (ruRules)FindObjectOfType(typeof(ruRules));
                victoryText.text = rutxt.RusTittles[6];                
            }
            if (lang.Equals("English"))
            {
                enRules entxt = (enRules)FindObjectOfType(typeof(enRules));
                victoryText.text = entxt.EngTittles[6];
            }

            if (points_first > points_second)
            {
                if (theme == "light")
                {                    
                    victoryText.color = Color.red;
                }
                else
                {
                    victoryText.color = Color.yellow;
                }
            }
            else
            {
                if (theme == "light")
                {
                    victoryText.color = Color.blue;
                }
                else
                {
                    victoryText.color = Color.cyan;
                }
            }
        }
    }
}