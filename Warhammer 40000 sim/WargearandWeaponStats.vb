Module WargearandWeaponStats
    Dim user As Integer = 4
    Public ReadOnly SM_Melee_Weapons As String() = {"Chainsword", "Power sword", "Power axe", "Power maul", "Power lance", "Power fist", "Lightning claw", "Thunder hammer"}
    Public ReadOnly SM_two_Sergeant_Equipment As String() = {"Chainsword", "Power sword", "Power axe", "Power maul", "Power lance", "Power fist", "Lightning claw", "Thunder hammer"}
    Public ReadOnly SM_one_Sergeant_Equipment As String() = {"Boltgun", "Combi-flamer", "Combi-grav", "Combi-melta", "Combi-plasma", "Storm bolter"}
    Public ReadOnly SM_Pistols As String() = {"Bolt pistol", "Plasma pistol", "Grav-pistol"}
    Public ReadOnly SM_Combi_Weapons As String() = {"Storm bolter", "Combi-plasma", "Combi-flamer", "Combi-melta", "Combi-grav"}
    Public ReadOnly SM_Special_Weapons As String() = {"Flamer", "Plasma gun", "Meltagun", "Grav-gun"}
    Public ReadOnly SM_Heavy_Weapons As String() = {"Missile launcher", "Heavy bolter", "Multi-melta", "Lascannon", "Grav-cannon And Grav-amp", "Plasma cannon"}
    Public ReadOnly SM_Terminator_Melee_Weapons As String() = {"Lightning claw", "Power fist", "Thunder hammer", "Storm shield"}
    Public ReadOnly SM_Terminator_Combi_Weapons As String() = {"Storm bolter", "Combi-plasma", "Combi-flamer", "Combi-melta"}
    Public ReadOnly SM_Terminator_Heavy_Weapons As String() = {"Heavy flamer", "Assault cannon", "Cyclone missile launcher And Storm bolter"}
    Public ReadOnly SM_Dreadnought_Heavy_Weapons As String() = {"Twin heavy flamer", "Twin autocannon", "Twin heavy bolter", "Twin lascannon", "Assault cannon", "Heavy plasma cannon"}
    Public ReadOnly DE_Tools_of_Torment As String() = {"Hexrifle", "Liquifier gun", "Stinger pistol"}
    Public ReadOnly DE_Weapons_of_Torture As String() = {"Agoniser", "Electrocorrosive whip", "Flesh gauntlet", "Mindphase gauntlet", "Scissorhand", "Venom blade"}
    Public ReadOnly N_Melee_Weapons As String() = {"Hyperphase sword", "Voidblade", "Warscythe"}
    Public ReadOnly AE_Autarch_Weapons As String() = {"Avenger shuriken catapult", "Death spinner", "Fusion gun", "Lasblaster", "Power sword", "Reaper launcher", "Scorpion chainsword"}
    Public ReadOnly AE_Heavy_Weapons As String() = {"Aeldari missile launcher", "Bright lance", "Scatter laser", "Shuriken cannon", "Starcannon"}
    Public ReadOnly AE_Vehicle_Equipment As String() = {"Crystal targeting matrix", "Spirit stones", "Star engines", "Vectored engines"}
    Public ReadOnly O_Shooty_Weapons As String() = {"Shoota", "Kustom shoota", "Kombi-weapon with rokkit launcha", "Kombi-weapon with skorcha"}
    Public ReadOnly O_Soupedup_Weapons As String() = {"Kombi-weapon with rokkit launcha", "Kustom mega-blasta", "Rokkit launcha", "Kombi-weapon with skorcha", "Kustom mega-slugga"}
    Public ReadOnly O_Eavy_Weapons As String() = {"Big shoota", "Rokkit launcha"}
    Public ReadOnly O_Choppy_Weapons As String() = {"Big choppa", "Power klaw"}
    Public ReadOnly T_Ranged_Weapons As String() = {"Airbursting fragmentation projector", "Burst cannon", "Cyclic ion blaster", "Flamer", "Fusion blaster", "Missile pod", "Plasma rifle"}
    Public ReadOnly T_Support_Systems As String() = {"Advanced targeting system", "Counterfire defence system", "Drone controller", "Early warning override", "Multi-tracker", "Shield generator", "Stimulant injector", "Target lock", "Velocity tracker"}
    Function assault(ByVal advanced As Boolean)
        If advanced Then
            Return True
        Else
            Return False
        End If
    End Function
    Function heavy(ByVal moved As Boolean)
        If moved Then
            Return True
        Else
            Return False
        End If
    End Function
   
End Module
