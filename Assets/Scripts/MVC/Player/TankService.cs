using UnityEngine;
using TankBattle.ScriptableObjects;
using TankBattle.Singleton;

namespace TankBattle.MVC.Player
{
    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private TankView tankView;
        [SerializeField] private TankTypes tankType;
        [SerializeField] private GameObject mainCamera;
        private TankModel tankModel;
        private TankController tankController;

        private void Start()
        {
            tankModel = new TankModel(tankType);
            tankController = new TankController(tankModel, tankView, transform.position, mainCamera);
        
        }
    }
}
