using UnityEngine;
using Zenject;

public class InputTypeInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;
    public override void InstallBindings()
    {
        bool isMobile = Application.isMobilePlatform || Screen.width < 800;

        if (isMobile)
        {
            _joystick.gameObject.SetActive(true);
            Container.BindInterfacesAndSelfTo<MobileMovement>().AsSingle();
        }
        else
        {
            if (_joystick != null)
                _joystick.gameObject.SetActive(false);
            Container.BindInterfacesAndSelfTo<DesktopMovement>().AsSingle();
        }

        Container.Bind<Joystick>().FromInstance(_joystick);

        Container.Bind<MovementHandler>().AsSingle().NonLazy();
    }
}
