using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public interface IState
{
    void DoAction();
    bool CheckState();
    void updateState(Object stateManager);
}

