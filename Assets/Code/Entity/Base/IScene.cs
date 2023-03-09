using UnityEngine;

namespace Code.Entity.Base
{
    public interface IScene
    {
        ////Entities的处理
        //EntityContainer Entities { get; }

        ////场景的消息
        //Messenger Msger { get; }

        //最矮的飞行高度
        float MinMountFlyHeight { get; }
        //最高的飞行高度
        float MaxMountFlyHeight { get; }

        //获取地形位置
        Vector3 GetTerrainPosition(float x, float z);

        //获取地形高度
        bool GetHeightOnTerrain(float aX, float aZ, out float aHeight);

        //获取地形高度
        float GetHeightOnTerrain(float aX, float aZ);
    }
}
