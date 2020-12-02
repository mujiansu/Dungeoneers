using System;
using System.Collections.Generic;
using MessagePack;
using Steamworks;
using UnityEngine;

public class SteamHelpers
{
    private static readonly Dictionary<Type, object> Callbacks = new Dictionary<Type, object>();

    public static CSteamID Me;

    public static CGameID GameId;

    /// <summary>
    /// Register callback to steam
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="func"></param>
    public static void RegisterCallback<T>(Callback<T>.DispatchDelegate func)
    {
        Callbacks.Add(typeof(T), Callback<T>.Create(func));
    }

    public static void Init()
    {
        Me = SteamUser.GetSteamID();
        SteamFriends.GetFriendGamePlayed(Me, out FriendGameInfo_t friendGameInfo);
        GameId = friendGameInfo.m_gameID;
    }

    public static bool GetPacket<T>(out T packet, out CSteamID remoteId, PacketChannel channel)
    {
        if (SteamNetworking.IsP2PPacketAvailable(out var packetSize, (int)channel))
        {
            var packetBytes = new byte[packetSize];
            if (!SteamNetworking.ReadP2PPacket(packetBytes, packetSize, out var bytesRead, out var packetRemoteId, (int)channel) || packetRemoteId == Me)
            {
                packet = default(T);
                remoteId = packetRemoteId;
                return false;
            }
            packet = MessagePackSerializer.Deserialize<T>(packetBytes);
            remoteId = packetRemoteId;
            return true;
        }
        packet = default(T);
        remoteId = default(CSteamID);
        return false;
    }

    public static bool TryGetFriendIds(out List<CSteamID> friendIds)
    {
        var friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
        var friendIdsList = new List<CSteamID>();
        if (friendCount != -1)
        {
            for (var i = 0; i < friendCount; i++)
            {
                friendIdsList.Add(SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate));
            }
        }
        friendIds = friendIdsList;
        if (friendCount >= 0) return true;
        return false;
    }

    public static bool TryGetFriendsMetadata(out List<SteamFriendMetadata> friends)
    {
        friends = new List<SteamFriendMetadata>();
        if (!TryGetFriendIds(out List<CSteamID> friendIds)) return false;
        foreach (var friendId in friendIds)
        {
            SteamFriends.GetFriendGamePlayed(friendId, out FriendGameInfo_t friendGameInfo);
            var friend = new SteamFriendMetadata
            {
                Name = SteamFriends.GetFriendPersonaName(friendId),
                Avatar = GetSteamImageAsTexture2D(SteamFriends.GetSmallFriendAvatar(friendId)),
            };
            friend.GameId = friendGameInfo.m_gameID;
            friend.lobbyId = friendGameInfo.m_steamIDLobby;
            friend.State = SteamFriends.GetFriendPersonaState(friendId);
            friends.Add(friend);
        }

        return true;
    }

    public static Texture2D GetSteamImageAsTexture2D(int image)
    {
        Texture2D ret = null;
        uint ImageWidth;
        uint ImageHeight;
        bool bIsValid = SteamUtils.GetImageSize(image, out ImageWidth, out ImageHeight);

        if (bIsValid)
        {
            byte[] Image = new byte[ImageWidth * ImageHeight * 4];

            bIsValid = SteamUtils.GetImageRGBA(image, Image, (int)(ImageWidth * ImageHeight * 4));
            if (bIsValid)
            {
                ret = new Texture2D((int)ImageWidth, (int)ImageHeight, TextureFormat.RGBA32, false, true);
                ret.LoadRawTextureData(Image);
                ret.Apply();
            }
        }

        return ret;
    }

    public enum PacketChannel
    {
    }
}

public class SteamFriendMetadata
{
    public string Name { get; set; }
    public Texture2D Avatar { get; set; }
    public EPersonaState State { get; set; }
    public CGameID GameId { get; set; }
    public CSteamID lobbyId { get; set; }
}
