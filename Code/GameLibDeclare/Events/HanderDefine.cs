using System;
using System.Collections.Generic;

namespace GameLib.Cfg.Data
{
    //获取数据回调定义
    public static class HanderDefine
    {
        public delegate bool OnLuaBaseDataHandler(string name, out int count, out int indexFactor, out IntPtr compressData, out IntPtr columnShiftAndList, out int _compressMaxColumn, out Dictionary<string, int> nameIndexs);
        public delegate bool OnLuaDataHandler(string name, out IntPtr compressData);
        public delegate string OnSetStringHandler(int id);

        //从lua端填充数据回调
        public static OnLuaBaseDataHandler BaseDataCallBack { get; private set; }
        public static OnLuaDataHandler DataCallBack { get; private set; }
        //获取文字回调
        public static OnSetStringHandler SetStingCallBack { get; private set; }

        //设置从lua端填充数据回调
        public static void SetLuaBaseDataCallBack(OnLuaBaseDataHandler callBack)
        {
            BaseDataCallBack = callBack;
        }
        public static void SetLuaDataCallBack(OnLuaDataHandler callBack)
        {
            DataCallBack = callBack;
        }
        //设置获取文字回调
        public static void SetStringCallBack(OnSetStringHandler callBack)
        {
            SetStingCallBack = callBack;
        }
    }
}