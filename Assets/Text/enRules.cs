using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enRules : MonoBehaviour
{
    private string[] engText = {
        "    1.  A 9x9 restricted zone (81 available positions) will be used as the playing field.",
        "",
        "    2.	The first player starts with one starting point, which is in the center of his own first line of attack. The second player starts with two points to compensate for the loss of initiative in his moves.",
        "",
        "    3.	The price value of lines for each player is determined by theirs distance from the starting line of a particular player. Since the field is 9x9, then the lines of calculation of the final points are also nine.",
        "    For example, the line from which the first player starts will earn him 1 point for each captured position, but the same line will bring 9 points for each position captured to the second player, since it is distant from his starting line by 7 lines (the start line is starting the ninth line is the last and seven between them).",
        "",
        "    4.	You can capture a position only if it is not yet captured by another player and is adjacent to the one you have already captured.",
        "    5.	If any uncaptured positions are completely isolated by one player from the second, that is, he cannot capture them at all, they are automatically captured without spending the turn of the player who isolated them.",
        "    6.	The victory is given to the player who scored more points after the division of all 81 positions, or in the case of the same number of points, the victory goes to the player whose turn to go was second.",
        "    7. In the \"Tactics\" mode at the beginning of the game, random obstacles are generated that overlap the path and do not allow the grip of the cells. The barriers are mirrored, and therefore balanced.",
        "    8. Also in this game mode, the virtual opponent will ignore any obstacles. This increases the complexity of the game and requires you to make optimal strategic decisions.",
        "    9. The victory is awarded in the same way as in the standard mode, but the game can be completed ahead of time if there are cells on the field that cannot be captured due to obstacles."
    };

    private string[] engTittles = {
        "Combat Dots",
        "Single\nplayer",
        "Multi\nplayer",
        "Settings\n",
        "Quit\n",
        "Rules",
        "Victory!",
        "Light",
        "Easy",
        "Medium",
        "Hard",
        "Impossible",
        "Standart",
        "Tactical",
        "Choose gamemode",
        "Select the number of obstacles"
    };          

    public string[] EngText { get => engText; set => engText = value; }
    public string[] EngTittles { get => engTittles; set => engTittles = value; }
}