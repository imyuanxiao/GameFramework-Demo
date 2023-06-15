using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Procedure;
using System;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Demo6
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("Demo6 初始！");

            base.OnEnter(procedureOwner);

            // 获取框架实体组件
            EntityComponent entityComponent  =  GameEntry.GetComponent<EntityComponent>();    
            // 创建实体
            entityComponent.ShowEntity<PlayerLogic>(1, "Assets/Scenes/Demo6/Player.prefab", "PlayerGroup");
        
        }
    }
}