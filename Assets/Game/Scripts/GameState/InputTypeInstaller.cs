using UnityEngine;
using UnityEngine.InputSystem;
using YG;
using Zenject;

public class InputTypeInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;
    public override void InstallBindings()
    {
        bool isMobile = SystemInfo.deviceType == DeviceType.Handheld;

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
