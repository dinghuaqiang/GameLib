using Code.Logic.System;
using GameLib.Core.Base;

namespace Code.Logic.MapLogic
{
    public class CopyLogicSystem : ISystem
    {
        private CopyLogicBase _copyLogic;

        public void Initialize()
        {
            //int cfgCopyType = RedCfg();
            int cfgCopyType = 1;
            COPY_LOGIC_TYPE cfgLogicType = (COPY_LOGIC_TYPE)cfgCopyType;
            switch (cfgLogicType)
            {
                case COPY_LOGIC_TYPE.EXP_COPY:
                    _copyLogic = new ExpCopyLogic();
                    break;
                case COPY_LOGIC_TYPE.MONEY_COPY:
                    _copyLogic = new MoneyCopyLogic();
                    break;
                default:
                    break;
            }
        }

        public void UnInitialize()
        {
            
        }

        public void OnSceneEnter()
        {
            _copyLogic.OnEnterScene(null);
        }

        public void Update(float deltaTime)
        {
            _copyLogic.Update(deltaTime);
        }
    }
}
