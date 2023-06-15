using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Demo6
{

    public class PlayerLogic : EntityLogic
    {
       protected PlayerLogic()
        {

        }
        protected override void OnShow(object userData)
        {
            base.OnShow(userData); 
            Log.Debug("显示Player实体.");
        }
    }
}