using Gameplay.CameraDistance;
using Gameplay.Chip;
using Gameplay.Paddles;
using Gameplay.StateMachine;
using Gameplay.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private ChipMove             chip;
        [SerializeField] private GameplayUIController uiController;

        protected override void Configure(IContainerBuilder _Builder)
        {
            _Builder.RegisterComponent(uiController);

            _Builder.Register<ChipMoveService>(Lifetime.Singleton);

            _Builder.RegisterEntryPoint<PlayerPaddleService>().As<PlayerPaddleService>();

            _Builder.RegisterComponent(chip);

            _Builder.RegisterEntryPoint<EnemyPaddleService>().As<EnemyPaddleService>();

            _Builder.Register<GameplayStateMachine>(Lifetime.Singleton);

            _Builder.RegisterEntryPoint<CameraDistanceService>().As<CameraDistanceService>();
        }
    }
}