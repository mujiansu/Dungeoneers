﻿using Dungeoneer.Netowrking.Packets;
using Dungeoneer.Steamworks;
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
            Container.DeclareSignal<LobbyManager.LobbyInviteReceivedSignal>().OptionalSubscriber();
            Container.DeclareSignal<LobbyManager.LobbyJoinedSignal>().OptionalSubscriber();
            Container.DeclareSignal<SceneChangingManager.SceneTransitionSignal>().OptionalSubscriber().RunAsync();
            DeclarePacketSignals();
            Container.BindInterfacesAndSelfTo<SteamManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneChangingManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<NetworkingManager>().AsSingle();
        }

        private void DeclarePacketSignals()
        {
            Container.DeclareSignal<NetworkingManager.PacketSignal<CharacterPacket>>();
            Container.DeclareSignal<NetworkingManager.PacketSignal<SceneChangePacket>>();
        }
    }

}
