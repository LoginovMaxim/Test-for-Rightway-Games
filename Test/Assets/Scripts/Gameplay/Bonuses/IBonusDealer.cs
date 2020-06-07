using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public interface IBonusDealer
    {
        BonusType BonusType { get; }

        float BonusValue { get; }
    }
}
