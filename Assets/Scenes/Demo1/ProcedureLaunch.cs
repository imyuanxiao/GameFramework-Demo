using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        string welcomeMessage = Utility.Text.Format("Hello! This is Demo1.", Version.GameFrameworkVersion);
        // 打印调试级别日志，用于记录调试类日志信息
        Log.Debug(welcomeMessage);

        // 打印信息级别日志，用于记录程序正常运行日志信息
        Log.Info(welcomeMessage);

        // 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用
        Log.Warning(welcomeMessage);

        // 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用
        Log.Error(welcomeMessage);

        // 打印严重错误级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏框架
        Log.Fatal(welcomeMessage);
    }
}