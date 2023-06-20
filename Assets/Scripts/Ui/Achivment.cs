using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace TankBattle.UI
{
    public class Achivment : MonoBehaviour
    {
        private Animator popUp;
        private TextMeshProUGUI[] achievementText;
        private Rank rank;
        private int enemyCount = 0;
        private int shootCount = 0;

        private void Start()
        {
            popUp = GetComponent<Animator>();
            achievementText = GetComponentsInChildren<TextMeshProUGUI>();
            MVC.Enemy.TankController.OnEnemyDeath += EnemyKillAchievement;
            MVC.Player.TankController.OnPlayerShoot += ShootingAchievement;
        }

        private void ShootingAchievement()
        {
            shootCount++;
            switch (shootCount)
            {
                case 1:
                    achievementText[0].text = "bronz achievement unlocked";
                    achievementText[1].text = "shooted first time.";
                    popUp.SetTrigger("Achievement");
                    break;
                case 5:
                    achievementText[0].text = "silver achievement unlocked";
                    achievementText[1].text = shootCount + " bullets shooted";
                    popUp.SetTrigger("Achievement");
                    break;
                case 10:
                    achievementText[0].text = "silver achievement unlocked";
                    achievementText[1].text = shootCount + " bullets shooted";
                    popUp.SetTrigger("Achievement");
                    break;
            }
        }

        private void EnemyKillAchievement()
        {
            enemyCount++;
            rank = (Rank)enemyCount;
            switch (rank)
            {
                case Rank.bronz:
                    achievementText[0].text = "bronz achievement unlocked";
                    achievementText[1].text = "killed first enemy";
                    break;
                case Rank.silver:
                    achievementText[0].text = "silver achievement unlocked";
                    achievementText[1].text = "killed " + enemyCount + " Enemies.";
                    break;
                case Rank.gold:
                    achievementText[0].text = "gold achievement unlocked";
                    achievementText[1].text = "killed " + enemyCount + " Enemies.";
                    break;
                default:
                    break;
            }
            popUp.SetTrigger("Achievement");
        }
        private void OnDestroy()
        {
            MVC.Enemy.TankController.OnEnemyDeath -= EnemyKillAchievement;
             MVC.Player.TankController.OnPlayerShoot -= ShootingAchievement;
        }
    }
}