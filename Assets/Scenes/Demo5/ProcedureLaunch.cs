using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Procedure;
using System;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Demo5
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Debug("Demo5 初始！");
            // 获取框架事件组件
            EventComponent Event = GameEntry.GetComponent<EventComponent>();
            // 订阅加载成功事件
            Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            // 获取框架数据表组件
            DataTableComponent DataTable = GameEntry.GetComponent<DataTableComponent>();
            Type dataRowType = Type.GetType("Demo5.DREnemy");
            DataTableBase dataTableBase = DataTable.CreateDataTable(dataRowType);
            dataTableBase.ReadData("Assets/Scenes/Demo5/Enemy.txt");
        
        }
        private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
        { 
            // 获取框架数据表组件
            DataTableComponent DataTable = GameEntry.GetComponent<DataTableComponent>();
            // 获得数据表
            IDataTable<DREnemy> dtScene = DataTable.GetDataTable<DREnemy>();
            
            // 获得所有行
            DREnemy[] drEnemies = dtScene.GetAllDataRows();
 
            Log.Debug("drEnemies:" + drEnemies.Length);
            // 根据行号获得某一行
            DREnemy drScene = dtScene.GetDataRow(1); // 或直接使用 dtScene[1]
            if (drScene != null)
            {
                // 此行存在，可以获取内容了
                string name = drScene.Name;
                int atk = drScene.Atk;
                int def = drScene.Def;
                Log.Debug("name:" + name + ", atk:" + atk+ ", def:" + def);
            }
            else
            {
                // 此行不存在
            }

            // 获得满足条件的所有行
            DREnemy[] drScenesWithCondition = dtScene.GetDataRows(x => x.Id > 0);
         
            // 获得满足条件的第一行
            DREnemy drSceneWithCondition = dtScene.GetDataRow(x => x.Name == "强化和谐号");
            if(drSceneWithCondition == null){
                Log.Debug("未找到敌人数据");
                return;
            }
            Log.Debug(drSceneWithCondition.Name);
        }
    }
}