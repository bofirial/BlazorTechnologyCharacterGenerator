﻿using TechnologyCharacterGenerator.Models;
using TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class HitPointsTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public ushort UserHashIndex => 2;
        public ushort Order => 10;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel TechnologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            TechnologyCharacterViewModel.HitPoints = (ushort)(userHashValue * 50);
        }
    }
}