using GameFramework;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Demo4
{

    public class ProcedureMenu : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("进入菜单流程");

            // 加载框架Event组件
            EventComponent Event = GameEntry.GetComponent<EventComponent>();
            
            // 订阅UI加载成功事件
            Event.Subscribe(OpenUIFormSuccessEventArgs.EventId,OnOpenUIFormSuccess);
            
            //加载框架UI组件
            UIComponent UI = GameEntry.GetComponent<UIComponent>();
            //加载UI
            UI.OpenUIForm("Assets/Scenes/Demo4/GameMenuUI.prefab", "DefaultGroup",this);
            
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            // 判断userData是否为自己
            if (ne.UserData != this)
            {
                return;
            }
            Log.Debug("UI_Menu：恭喜你，成功地召唤了我。");
        }
    }
}