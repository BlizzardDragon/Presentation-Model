using FrameworkUnity.OOP.Zenject.Installers;

namespace PresentationModel
{
    public class GameSystemsInstallerPM : BaseGameSystemsInstaller
    {
        protected override void InstallGameSystems()
        {
            Container.Bind<CharacterInfo>().AsSingle();
            Container.Bind<PlayerLevel>().AsSingle();
            Container.Bind<UserInfo>().AsSingle();

            Container.Bind<PresentationModelCharacter>().AsSingle();
        }
    }
}
