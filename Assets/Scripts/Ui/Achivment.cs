using UnityEngine;
using TankBattle.MVC.Enemy;

namespace TankBattle.UI
{
    public class Achivment : MonoBehaviour
    {
        private Animator popUp;

        private void Start()
        {
            popUp = GetComponent<Animator>();
            TankController.OnEnemyDeath += PopInAchivment;
        }
        private void PopInAchivment()
        {
            popUp.SetTrigger("Killed Enemy");
        }
    }
}