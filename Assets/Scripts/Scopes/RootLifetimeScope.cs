using GlobalServices;
using GlobalServices.Progress;
using GlobalServices.Skins;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder _Builder)
        {
            _Builder.Register<SaveLoadService>(Lifetime.Singleton);

            _Builder.Register<SceneLoaderService>(Lifetime.Singleton);

            _Builder.RegisterEntryPoint<ProgressService>().As<ProgressService>();

            _Builder.RegisterEntryPoint<SkinsService>().As<SkinsService>();

            _Builder.RegisterEntryPoint<ScoreService>().As<ScoreService>();
        }
    }
}