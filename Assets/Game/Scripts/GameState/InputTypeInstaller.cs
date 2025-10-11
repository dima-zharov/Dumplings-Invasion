using UnityEngine;
using UnityEngine.InputSystem;
using YG;
using Zenject;

public class InputTypeInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;
    public override void InstallBindings()
    {
        bool isDesctop = YG2.envir.isDesktop;

        if (isDesctop)
        {
             if (_joystick != null)
                 _joystick.gameObject.SetActive(false);
             Container.BindInterfacesAndSelfTo<DesktopMovement>().AsSingle();
        }
        else
        {
            _joystick.gameObject.SetActive(true);
            Container.BindInterfacesAndSelfTo<MobileMovement>().AsSingle();
        }

        Container.Bind<Joystick>().FromInstance(_joystick);

        Container.Bind<MovementHandler>().AsSingle().NonLazy();
    }

}
