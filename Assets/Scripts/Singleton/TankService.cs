using UnityEngine;
using TankBattle.MVC;

namespace TankBattle.Singleton
{
    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private TankView tankView;
        private TankModel tankModel = new();
        private TankController tankController;

        private void Start()
        {
            //Instantiate(tankView.gameObject, transform.position, Quaternion.identity);
            tankController = new TankController(tankModel, tankView);
            tankController.SpawnTank(transform.position);
        }
    }
}
