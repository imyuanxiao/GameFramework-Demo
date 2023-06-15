using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Demo3
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("Demo3初始！");
            SceneComponent scene  = GameEntry.GetComponent<SceneComponent>();
            // 切换场景
            scene.LoadScene("Assets/Scenes/Demo3/Demo3Menu.unity", this);
            // 切换流程
            ChangeState<ProcedureMenu>(procedureOwner);
        }
    }
}
