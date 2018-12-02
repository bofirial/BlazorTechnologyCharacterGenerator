﻿using BlazorRpgPersonaCommon.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public class CharacterClassRpgPersonaPropertyGenerator : IRpgPersonaPropertyGenerator
    {
        private readonly (string Class, ClassTypes ClassType)[] _characterClasses = {
            (Class:"Archer",    ClassType: ClassTypes.Agile),
            (Class:"Thief",     ClassType: ClassTypes.Agile),
            (Class:"Hunter",    ClassType: ClassTypes.Agile),
            (Class:"Rogue",     ClassType: ClassTypes.Agile),
            (Class:"Warrior",   ClassType: ClassTypes.Strong),
            (Class:"Barbarian", ClassType: ClassTypes.Strong),
            (Class:"Druid",     ClassType: ClassTypes.Strong),
            (Class:"Soldier",   ClassType: ClassTypes.Strong),
            (Class:"Wizard",    ClassType: ClassTypes.Magician),
            (Class:"Mage",      ClassType: ClassTypes.Magician),
            (Class:"Warlock",   ClassType: ClassTypes.Magician),
            (Class:"Sorceror",  ClassType: ClassTypes.Magician),
            (Class:"Paladin",   ClassType: ClassTypes.Healer),
            (Class:"Priest",    ClassType: ClassTypes.Healer),
            (Class:"Shaman",    ClassType: ClassTypes.Healer),
            (Class:"Healer",    ClassType: ClassTypes.Healer),
        };

        public ushort UserHashIndex => 0;
        public ushort Order => 10;

        public void GenerateRpgPersonaProperty(ref RpgPersonaViewModel rpgPersonaViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            var characterClass = _characterClasses[userHashValue];

            rpgPersonaViewModel.Class = characterClass.Class;
            rpgPersonaViewModel.ClassType = characterClass.ClassType;
        }
    }
}