using System;
using System.Text;
using Models;
using UnityEngine;

namespace Systems
{
    public static class PhotonSerializationSystem
    {
        public static object DeserializePlayerModel(byte[] data)
        {
            var color = new Color
            {
                r = BitConverter.ToSingle(data, 0),
                g = BitConverter.ToSingle(data, 4),
                b = BitConverter.ToSingle(data, 8),
                a = BitConverter.ToSingle(data, 12)
            };

            var health = BitConverter.ToInt32(data, 16);
            var countOfCoins = BitConverter.ToInt32(data, 20);
            var playerName = Encoding.UTF8.GetString(data, 24, data.Length - 24);
            
            var result = new PlayerModel(color, health, countOfCoins, playerName);
            
            return result;
        }

        public static byte[] SerializePlayerModel(object obj)
        {
            var playerModel = (PlayerModel) obj;
            var playerNameBytes = Encoding.UTF8.GetBytes(playerModel.PlayerName);
            var result = new byte[24 + playerNameBytes.Length];
        
            BitConverter.GetBytes(playerModel.Color.r).CopyTo(result, 0);
            BitConverter.GetBytes(playerModel.Color.g).CopyTo(result, 4);
            BitConverter.GetBytes(playerModel.Color.b).CopyTo(result, 8);
            BitConverter.GetBytes(playerModel.Color.a).CopyTo(result, 12);
            
            BitConverter.GetBytes(playerModel.Health).CopyTo(result, 16);
            BitConverter.GetBytes(playerModel.CountOfCoins).CopyTo(result, 20);

            playerNameBytes.CopyTo(result, 24);
            
            return result;
        }
    }
}