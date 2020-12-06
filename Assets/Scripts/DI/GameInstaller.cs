﻿using Dugeoneer.Netowrking.Packets;
using Dugeoneer.Steamworks;
using Dungeoneer.Managers;
using Zenject;
namespace Dungeoneer.DI
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<LobbyManager.MembersUpdateSignal>().OptionalSubscriber();
            Container.DeclareSignal<LobbyManager.LobbyInviteReceivedSignal>();
            DeclarePacketSignals();
            Container.BindInterfacesAndSelfTo<SteamManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LobbyManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<NetworkingManager>().AsSingle();
        }

        private void DeclarePacketSignals()
        {
            Container.DeclareSignal<NetworkingManager.PacketSignal<CharacterPacket>>();
        }
    }

}
