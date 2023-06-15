using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Demo3
{
    public class ProcedureMenu : ProcedureBase
    {

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("进入菜单流程，可以在这里加载菜单UI！");

            UIComponent UI = GameEntry.GetComponent<UIComponent>();
            //加载UI
            UI.OpenUIForm("Assets/Scenes/Demo3/GameMenuUI.prefab", "DefaultGroup");
            


        }
    }


}
