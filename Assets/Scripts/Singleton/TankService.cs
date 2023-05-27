using UnityEngine;
using TankBattle.MVC;
using TankBattle.ScriptableObjects;

namespace TankBattle.Singleton
{
    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private TankView tankView;
        public TankTypeArray tankArray;
        private TankModel tankModel;
        private TankController tankController;

        private void Start()
        {
            tankModel = new TankModel(tankArray.tankTypes[(int)AvailableTank.playerTankGreen]);
            tankController = new TankController(tankModel, tankView);
            tankController.SpawnTank(transform.position);
        }
    }
}
