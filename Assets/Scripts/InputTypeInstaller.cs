using UnityEngine;
using Zenject;

public class InputTypeInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Container.BindInterfacesAndSelfTo<DesktopMovement>().AsSingle();

        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Container.BindInterfacesAndSelfTo<MobileMovement>().AsSingle();
        }

        Container.Bind<MovementHandler>().AsSingle().NonLazy();
    }
}
