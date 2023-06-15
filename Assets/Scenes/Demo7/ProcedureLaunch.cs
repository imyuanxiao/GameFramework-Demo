using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Procedure;
using System;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Demo7
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("Demo7 初始！");

            // 获取框架事件组件
            EventComponent Event  =  GameEntry.GetComponent<EventComponent>();
            Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);

            // 获取框架网络组件
            WebRequestComponent WebRequest  = GameEntry.GetComponent<WebRequestComponent>();
            string url = "https://boy3d.com/zb_users/upload/demo7.txt";
            
            // AddWebRequest 方法默认使用GET请求
            WebRequest.AddWebRequest(url, this);


        }

        private void OnWebRequestSuccess(object sender, GameEventArgs e)
        {
            WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
            // 获取回应的数据
            string responseJson = Utility.Converter.GetString(ne.GetWebResponseBytes());
            Log.Debug("responseJson：" + responseJson);
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            Log.Warning("请求失败");
        }

    }
}