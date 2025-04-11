using UnityEngine;
using Zenject;

public class InputTypeInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;
    public override void InstallBindings()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (_joystick != null)
                _joystick.gameObject.SetActive(false);
            Container.BindInterfacesAndSelfTo<DesktopMovement>().AsSingle();
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            _joystick.gameObject.SetActive(true);
            Container.BindInterfacesAndSelfTo<MobileMovement>().AsSingle();
        }

        Container.Bind<Joystick>().FromInstance(_joystick);

        Container.Bind<MovementHandler>().AsSingle().NonLazy();
    }
}
