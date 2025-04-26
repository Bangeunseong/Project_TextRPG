using System.Net.Security;
using System.Text;
using System.Text.Json;

namespace TextRPG
{
    /// <summary>
    /// Contains UI Materials
    /// </summary>
    static class UIManager
    {
        /// <summary>
        /// Show Game Start UI
        /// </summary>
        public static void StartUI()
        {
            Console.Clear();
            foreach (string line in Miscs.GameStart) Console.WriteLine(line);
        }

        /// <summary>
        /// Show Character Selection UI
        /// </summary>
        public static void JobSelectionUI()
        {
            Console.Clear();
            foreach (string line in Miscs.CharacterSelection) Console.WriteLine(line);
            Console.WriteLine("\n| 직업 선택 (뒤로가려면 0을 누르세요) |");
            Console.Write("원하는 직업을 선택하세요 : ");
        }

        /// <summary>
        /// Show Inventory UI
        /// </summary>
        /// <param name="character"></param>
        public static void InventoryUI(Character character)
        {
            Console.Clear();
            foreach (string line in Miscs.Inventory) Console.WriteLine(line);
            Console.WriteLine("\n| .:~:..:~:. 인벤토리 .:~:..:~:. |");
            Console.WriteLine("| .:~:. \"방어구\" .:~:. |");
            int i = 1;
            foreach (Armor armor in character.Armors) { Console.WriteLine($"{i++}. {armor}"); }
            Console.WriteLine("\n| .:~:. \"무기\" .:~:. |");
            i = 1;
            foreach (Weapon weapon in character.Weapons) { Console.WriteLine($"{i++}. {weapon}"); }
            Console.WriteLine("\n| .:~:. \"포션\" .:~:. |");
            i = 1;
            foreach (Consumables potion in character.Consumables) { Console.WriteLine($"{i++}. {potion}"); }
            Console.WriteLine("\n| .:~:. \"잡동사니\" .:~:. |");
            i = 1;
            foreach (ImportantItem item in character.ImportantItems) { Console.WriteLine($"{i++}. {item}"); }
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.WriteLine("\n| 1. 뒤로가기 |");
            Console.WriteLine("| 2. 아이템 선택 |");
            Console.Write("원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Inventory UI - Item Selection
        /// </summary>
        public static void InventoryUI_Equipment()
        {
            Console.WriteLine("\n| .:~:..:~:. \"장비\" .:~:..:~:. |");
            Console.WriteLine("| 1. 뒤로가기 |");
            Console.WriteLine("| 2. 착용하기 |");
            Console.WriteLine("| 3. 해제하기 |");
            Console.WriteLine("| 4. 버리기 |");
            Console.Write("원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Inventory UI - Item Selection
        /// </summary>
        public static void InventoryUI_Consumable()
        {
            Console.WriteLine("\n| .:~:..:~:. \"소모품\" .:~:..:~:. |");
            Console.WriteLine("| 1. 뒤로가기 |");
            Console.WriteLine("| 2. 사용하기  |");
            Console.Write("원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Inventory UI - Miscellaneous
        /// </summary>
        public static void InventoryUI_Misc()
        {
            Console.WriteLine("\n| .:~:..:~:. \"잡동사니\" .:~:..:~:. |");
            Console.WriteLine("| 1. 뒤로가기 |");
            Console.WriteLine("| 2. 버리기  |");
            Console.Write("원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Shop UI
        /// </summary>
        /// <param name="character"></param>
        public static void ShopUI(Character character)
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Henry's Shop! .:~:. |");
            foreach (string line in Miscs.Henry) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine($"\n| Gold : {character.Currency} |");
            Console.WriteLine("| 0. 뒤로가기 |");
            Console.WriteLine("| 1. 방어구 구매 |");
            Console.WriteLine("| 2. 무기 구매 |");
            Console.WriteLine("| 3. 포션 구매 |");
            Console.WriteLine("| 4. 아이템 판매 |");
            Console.Write("\n원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Shop List UI
        /// </summary>
        /// <param name="category"></param>
        public static void ShowShopList(Character character, ItemCategory category)
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Henry's Shop! .:~:. |");
            foreach (string line in Miscs.Henry) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine($"\n| Gold : {character.Currency} |");
            switch (category)
            {
                case ItemCategory.Armor:
                    foreach (string line in Miscs.ArmorDesign) Console.WriteLine(line);
                    Console.WriteLine("| .:~:. \"방어구\" .:~:. |");
                    int i = 1;
                    foreach (Armor armor in ItemLists.Armors)
                    {
                        if (character.Armors.Contains(armor)) Console.ForegroundColor = ConsoleColor.Yellow;
                        else Console.ResetColor();
                        Console.WriteLine($"{i++}. {armor}");
                    }
                    break;
                case ItemCategory.Weapon:
                    foreach (string line in Miscs.WeaponDesign) Console.WriteLine(line);
                    Console.WriteLine("| .:~:. \"무기\" .:~:. |");
                    i = 1;
                    foreach (Weapon weapon in ItemLists.Weapons)
                    {
                        if (character.Weapons.Contains(weapon)) Console.ForegroundColor = ConsoleColor.Yellow;
                        else Console.ResetColor();
                        Console.WriteLine($"{i++}. {weapon}");
                    }
                    break;
                case ItemCategory.Consumable:
                    foreach (string line in Miscs.PotionDesign) Console.WriteLine(line);
                    Console.WriteLine("| .:~:. \"포션\" .:~:. |");
                    i = 1;
                    foreach (Consumables potion in ItemLists.Consumables)
                    {
                        Console.WriteLine($"{i++}. {potion}");
                    }
                    break;
            }
            Console.ResetColor();
            Console.Write("\n구매할 상품 번호 입력 (취소하려면 0을 입력하세요) : ");
        }

        /// <summary>
        /// Show Item List UI
        /// </summary>
        /// <param name="character"></param>
        public static void ShowItemList(Character character)
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Henry's Shop! .:~:. |");
            foreach (string line in Miscs.Henry) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine($"\n| Gold : {character.Currency} |");
            Console.WriteLine("| .:~:..:~:..:~:. 아이템 판매 .:~:..:~:..:~:. |");
            Console.WriteLine("| .:~:..:~:. 1. \"방어구\" .:~:..:~:. |");
            int i = 1;
            foreach (Armor armor in character.Armors) { Console.WriteLine($"| {i++}. {armor} |"); }
            Console.WriteLine("| .:~:..:~:. 2. \"무기\" .:~:..:~:. |");
            i = 1;
            foreach (Weapon weapon in character.Weapons) { Console.WriteLine($"| {i++}. {weapon} |"); }
            Console.WriteLine("| .:~:..:~:. 3. \"포션\" .:~:..:~:. |");
            i = 1;
            foreach (Consumables potion in character.Consumables) { Console.WriteLine($"| {i++}. {potion} |"); }
            Console.WriteLine("| .:~:..:~:. 4. \"잡동사니\" .:~:..:~:. |");
            i = 1;
            foreach (ImportantItem item in character.ImportantItems) { Console.WriteLine($"| {i++}. {item} |"); }
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.Write("\n무엇을 판매하겠습니까? ( Type [ Category,Index ], 취소하려면 exit을 입력하세요) : ");
        }

        /// <summary>
        /// Mercenary Shop UI
        /// </summary>
        /// <param name="character"></param>
        public static void MercenaryShopUI(Character character)
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Henry's Shop! .:~:. |");
            foreach (string line in Miscs.Henry) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine($"\n| Gold : {character.Currency} |");
            Console.WriteLine("| 1. 뒤로가기 |");
            Console.WriteLine("| 2. 용병 계약 |");
            Console.WriteLine("| 3. 용병 계약해제 |");
            Console.Write("\n원하는 기능을 선택하세요 : ");

        }

        /// <summary>
        /// Mercenary Shop UI -> Having a contract with mercenary
        /// </summary>
        /// <param name="character"></param>
        /// <param name="mercenaries"></param>
        public static bool MercenaryShopUI_ContractMercenary(Character character, List<Character> mercenaries)
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Henry's Shop! .:~:. |");
            foreach (string line in Miscs.Henry) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            if (mercenaries == null || !mercenaries.Any()) { Console.WriteLine("\n| 죄송합니다, 계약할 수 있는 용병이 현재 없습니다! |"); Console.Write("Press enter to continue..."); Console.ReadLine(); return false; }

            Console.WriteLine($"\n| Gold : {character.Currency} |");
            int i = 1;
            foreach (var mercenary in mercenaries) { Console.WriteLine($"[{i++}]\n{mercenary.ToString()}"); }
            Console.Write("계약하고자 하는 용병을 선택하세요 ( 취소하려면 0을 입력하세요 ) : ");
            return true;
        }

        /// <summary>
        /// Mercenary Shop UI -> Cancel a contract of mercenary
        /// </summary>
        public static bool MercenaryShopUI_CancelContract()
        {
            var mercenaries = MercenaryManager.GetMercenaries();

            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Henry's Shop! .:~:. |");
            foreach (string line in Miscs.Henry) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            if (!mercenaries.Any()) { Console.WriteLine("\n| 죄송합니다, 계약해지를 할 수 있는 용병이 없습니다! |"); Console.Write("\nPress enter key to continue..."); Console.ReadLine(); return false; }

            int i = 1;
            foreach (var mercenary in mercenaries) { Console.WriteLine($"[{i++}] {mercenary.ToString()}\n"); }
            Console.Write("계약해지를 하고자 하는 용병을 선택하세요 ( 취소하려면 0을 입력하세요 ) : ");
            return true;
        }

        /// <summary>
        /// Show Skill List UI
        /// </summary>
        /// <param name="character"></param>
        public static void ShowSkillList(Character character)
        {
            Console.Clear();
            Console.WriteLine("\n| .:~:..:~:..:~:..:~:. Battle .:~:..:~:..:~:..:~:. |");
            foreach (var line in Miscs.BattleDesign) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.WriteLine($"\n| .:~:..:~:. 현재 시간 : {GameManager.GameTime} .:~:..:~:. |");
            Console.WriteLine($"| Lv : {character.Level} | Gold : {character.Currency} |");
            Console.WriteLine($"| HP : {character.Health:F2} | MP : {character.MagicPoint:F2} |");

            foreach (Skill skill in character.Skills)
            {
                if (skill is BuffSkill buffSkill && buffSkill.IsActive)
                    Console.WriteLine($"| {buffSkill.Name} 효과의 남은 턴 ({GameManager.CurrentTurn - buffSkill.UsedTurn}/{buffSkill.TurnInterval}) | ");

            }

            int i = 1;
            Console.WriteLine("\n| .:~:. \"스킬\" .:~:. |");
            foreach (Skill skill in character.Skills) Console.WriteLine($"| {i++}. {skill.ToString()} |");

            Console.Write("\n원하는 스킬을 고르세요 (취소하려면 0을 입력하세요) : ");
        }

        /// <summary>
        /// Show Monster List UI
        /// </summary>
        public static void ShowMonsterList(Character character)
        {
            Console.Clear();
            Console.WriteLine("\n| .:~:..:~:..:~:..:~:. Battle .:~:..:~:..:~:..:~:. |");
            foreach (var line in Miscs.BattleDesign) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.WriteLine($"\n| .:~:..:~:. 현재 시간 : {GameManager.GameTime} .:~:..:~:. |");
            Console.WriteLine($"| Lv : {character.Level} | Gold : {character.Currency} |");
            Console.WriteLine($"| HP : {character.Health:F2} | MP : {character.MagicPoint:F2} |");

            foreach (Skill skill in character.Skills)
            {
                if (skill is BuffSkill buffSkill && buffSkill.IsActive)
                    Console.WriteLine($"| {buffSkill.Name} 효과의 남은 턴 ({GameManager.CurrentTurn - buffSkill.UsedTurn}/{buffSkill.TurnInterval}) | ");

            }

            Console.WriteLine("\n| .:~:..:~:. \"몬스터\" .:~:..:~:. |");
            int i = 1;
            foreach (Monster monster in SpawnManager.spawnedMonsters)
                Console.WriteLine($"| {i++}. {monster.Name} | HP : {monster.Health} |");
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.Write("\n공격할 몬스터를 선택하세요 (취소하려면 0을 입력하세요) : ");
        }

        /// <summary>
        /// Show Cabin UI
        /// </summary>
        /// <param name="character"></param>
        public static void CabinUI(Character character)
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Alby's Cabin! .:~:. |");
            foreach (string line in Miscs.Alby) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.WriteLine($"\n| Gold : {character.Currency} |");
            Console.WriteLine("| 1. 뒤로가기 |");
            Console.WriteLine("| 2. 스탠다드 룸 (최대 체력 25% 회복, 40G) |");
            Console.WriteLine("| 3. 디럭스 룸 (최대 체력 50% 회복, 60G)   |");
            Console.WriteLine("| 4. 스위트 룸 (최대 체력 75% 회복, 80G)   |");
            Console.Write("\n룸 옵션을 선택하세요 : ");
        }

        /// <summary>
        /// Show Quest UI
        /// </summary>
        public static void QuestUI()
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Adventurers' Guild .:~:. |");
            foreach (string line in Miscs.Quest) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine("\n| 1. 뒤로가기 |");
            Console.WriteLine("| 2. Quest 수주 |");
            Console.WriteLine("| 3. Quest 완료 |");
            Console.WriteLine("| 4. 수주 가능한 Quest 목록 |");
            Console.WriteLine("| 5. 완료 가능한 Quest 목록 |");
            Console.WriteLine("| 6. 수주한 Quest 목록 |");
            Console.WriteLine("| 7. 완료한 Quest 목록 |");
            Console.Write("\n원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Quest Selection UI
        /// </summary>
        public static void QuestUI_Contract()
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Adventurers' Guild .:~:. |");
            foreach (string line in Miscs.Quest) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine("\n| .:~:. 수주 가능한 Quest 목록 .:~:. |");
            var questList = QuestManager.GetContractableQuests();
            if (questList == null || !questList.Any()) { Console.WriteLine("| 수주 가능한 Quest가 없습니다! |"); return; }

            foreach (var quest in questList)
                if (quest is KillMonsterQuest killMonsterQuest) Console.WriteLine($"{killMonsterQuest.ToString()}");
                else if (quest is CollectItemQuest collectItemQuest) Console.WriteLine($"{collectItemQuest.ToString()}");
            Console.Write("\nQuest를 선택하세요 : ");
        }

        /// <summary>
        /// Show Quest Completion UI
        /// </summary>
        /// <returns></returns>
        public static bool QuestUI_Complete()
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Adventurers' Guild .:~:. |");
            foreach (string line in Miscs.Quest) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine("\n| .:~:. 완료 가능한 Quest 목록 .:~:. |");
            var questList = QuestManager.GetCompletableQuests();
            if (questList == null || !questList.Any()) { Console.WriteLine("| 완료 가능한 Quest가 없습니다! |"); return false; }

            foreach (var quest in questList)
                if (quest is KillMonsterQuest killMonsterQuest) Console.WriteLine($"{killMonsterQuest.ToString()}");
                else if (quest is CollectItemQuest collectItemQuest) Console.WriteLine($"{collectItemQuest.ToString()}");
            Console.Write("\nQuest를 선택하세요: ");
            return true;
        }

        /// <summary>
        /// Show Quest List UI
        /// </summary>
        /// <param name="type"></param>
        public static void QuestUI_ShowQuests(QuestStatus type)
        {
            Console.Clear();
            Console.WriteLine("| .:~:. Welcome to Adventurers' Guild .:~:. |");
            foreach (string line in Miscs.Quest) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            if (type == QuestStatus.NotStarted)
            {
                Console.WriteLine("\n| .:~:. 수주 가능한 Quest 목록 .:~:. |");
                if (QuestManager.GetContractableQuests() == null || !QuestManager.GetContractableQuests().Any()) { Console.WriteLine("| .:~:. 수주 가능한 Quest가 없습니다! .:~:. |"); }
                else foreach (var quest in QuestManager.GetContractableQuests()) Console.WriteLine($"{quest.ToString()}");
            }
            else if (type == QuestStatus.InProgress)
            {
                Console.WriteLine("\n| .:~:. 수주한 Quest 목록 .:~:. |");
                if (QuestManager.GetContractedQuests() == null || !QuestManager.GetContractedQuests().Any()) { Console.WriteLine("| .:~:. 수주한 Quest가 없습니다! .:~:. |"); }
                else foreach (var quest in QuestManager.GetContractedQuests()) Console.WriteLine($"{quest.ToString()}");
            }
            else if (type == QuestStatus.Completable)
            {
                Console.WriteLine("\n| .:~:. 완료 가능한 Quest 목록 .:~:. |");
                if (QuestManager.GetCompletableQuests() == null || !QuestManager.GetCompletableQuests().Any()) { Console.WriteLine("| .:~:. 완료 가능한 Quest가 없습니다! .:~:. |"); }
                else foreach (var quest in QuestManager.GetCompletableQuests()) Console.WriteLine($"{quest.ToString()}");
            }
            else
            {
                Console.WriteLine("\n| .:~:. 완료한 Quest 목록 .:~:. |");
                if (QuestManager.GetCompletedQuests() == null || !QuestManager.GetCompletedQuests().Any()) { Console.WriteLine("| .:~:. 완료한 Quest가 없습니다! .:~:. |"); }
                else foreach (var quest in QuestManager.GetCompletedQuests()) Console.WriteLine($"{quest.ToString()}");
            }
            Console.Write("\nPress enter to continue...");
            Console.ReadLine();
        }

        /// <summary>
        /// Show Character Status UI
        /// </summary>
        /// <param name="character"></param>
        public static void StatusUI(Character character)
        {
            Console.Clear();

            if (character is Warrior) foreach (string line in Miscs.WarriorDesign) Console.WriteLine(line);
            else if (character is Archer) foreach (string line in Miscs.ArcherDesign) Console.WriteLine(line);
            else if (character is Wizard) foreach (string line in Miscs.MazeDesign) Console.WriteLine(line);

            Console.WriteLine("| .:~:..:~:. \"캐릭터 정보\" .:~:..:~:. |");
            Console.WriteLine($"| \"Name\" : {character.Name} |");
            Console.WriteLine($"| \"Lv {character.Level:D2}\" |");
            Console.WriteLine($"| \"Exp\" : {(character.Exp - (character.Level - 1) * 100) % 100}/100 |");
            Console.WriteLine($"| \"HP\" : {character.Health:F2}/{character.MaxHealth} |");
            Console.WriteLine($"| \"MP\" : {character.MagicPoint:F2}/{character.MaxMagicPoint} |");
            Console.WriteLine($"| \"Gold\" : {character.Currency} |");

            Console.WriteLine("\n| .:~:..:~:. \"캐릭터 상세\" .:~:..:~:. |");

            AttackStat atkStat = new(0, 0, 0);
            if (character.EquippedWeapon != null) atkStat += character.EquippedWeapon.AttackStat;
            foreach (var item in GameManager.Exposables)
            {
                if (item is AttackBuffPotion atkPotion) atkStat += atkPotion.AttackStat;
                else if (item is AllBuffPotion allPotion) atkStat += allPotion.AttackStat;
            }

            DefendStat defStat = new(0, 0, 0);
            foreach (var armor in character.EquippedArmor) if (armor != null) { defStat += armor.DefendStat; }
            foreach (var item in GameManager.Exposables)
            {
                if (item is DefendBuffPotion defPotion) defStat += defPotion.DefendStat;
                else if (item is AllBuffPotion allPotion) defStat += allPotion.DefendStat;
            }

            Console.WriteLine($"| \"Atk.\" : {character.AttackStat.Attack:F2} + ({atkStat.Attack:F2}) |");
            Console.WriteLine($"| \"Range Atk.\" : {character.AttackStat.RangeAttack:F2} + ({atkStat.RangeAttack:F2}) |");
            Console.WriteLine($"| \"Magic Atk.\" : {character.AttackStat.MagicAttack:F2} + ({atkStat.MagicAttack:F2}) |");
            Console.WriteLine($"| \"Def.\" : {character.DefendStat.Defend:F2} + ({defStat.Defend:F2}) |");
            Console.WriteLine($"| \"Range Def.\" : {character.DefendStat.RangeDefend:F2} + ({defStat.RangeDefend:F2}) |");
            Console.WriteLine($"| \"Magic Def.\" : {character.DefendStat.MagicDefend:F2} + ({defStat.MagicDefend:F2}) |");

            if (!character.EquippedArmor.Any())
            {
                Console.WriteLine("\n| .:~:..:~:. \"장착한 방어구\" .:~:..:~:. |");
                foreach (Armor? armor in character.EquippedArmor) { if (armor != null) { Console.WriteLine($"| {armor} |"); } }
            }
            
            if(character.EquippedWeapon != null)
            {
                Console.WriteLine("\n| .:~:..:~:. \"장착한 무기\" .:~:..:~:. |");
                Console.WriteLine($"| {character.EquippedWeapon} |");
            }

            if (!character.Skills.Any())
            {
                Console.WriteLine("\n| .:~:..:~:. \" 보유 스킬 \" .:~:..:~:. |");
                foreach (Skill skill in character.Skills) { Console.WriteLine($"| {skill.ToString()} |"); }
            }
            Console.Write("\nPress enter to continue..."); Console.ReadLine();
        }

        /// <summary>
        /// Show Monster Encounter UI
        /// </summary>
        public static void MonsterEncounterUI()
        {
            Console.Clear();
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.ForegroundColor = ConsoleColor.Green;
            StringBuilder sb = new();
            foreach (Monster monster in SpawnManager.spawnedMonsters)
            {
                sb.Append($"Lv {monster.Level}: ").Append(monster.Name).Append('\n');

                string[] monsterArt;

                if (monster.Level > 10)
                {
                    if (monster.AttackType == AttackType.Close) monsterArt = Miscs.HighLevelGoblinWarrior;
                    else if (monster.AttackType == AttackType.Long) monsterArt = Miscs.HighLevelGoblinArcher;
                    else monsterArt = Miscs.HighLevelGoblinWizard;
                }
                else
                {
                    if (monster.AttackType == AttackType.Close) monsterArt = Miscs.Goblin;
                    else if (monster.AttackType == AttackType.Long) monsterArt = Miscs.GoblinArcher;
                    else monsterArt = Miscs.GoblinWizard;
                }

                foreach (string line in monsterArt) Console.WriteLine(line);
            }
            Console.ResetColor();
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine($"\n| .:~:..:~:..:~:. Warning! .:~:..:~:..:~:. |");
            Console.WriteLine($"| {SpawnManager.spawnedMonsters.Count}마리의 몬스터가 나타났다! |");
            Console.Write(sb.ToString());
            Console.WriteLine(".:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:.");
            Console.Write("\nPress enter to continue..."); Console.ReadLine();
        }

        /// <summary>
        /// Show No Monster Found UI
        /// </summary>
        public static void NoMonsterFoundUI()
        {
            int ind = new Random().Next(Miscs.Quotes.Length);
            Console.WriteLine($"| 아무 일도 없었다..., {Miscs.Quotes[ind]} |");
            Console.Write("\nPress enter to continue..."); Console.ReadLine();
        }

        /// <summary>
        /// Show Game Over UI
        /// </summary>
        public static void GameOverUI()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string line in Miscs.GameOver) Console.WriteLine(line);
            Console.ResetColor();
        }

        /// <summary>
        /// Show Revive Option UI
        /// </summary>
        /// <param name="character"></param>
        public static void ReviveOptionUI(Character character)
        {
            Console.WriteLine($"\nGold : {character.Currency}");
            if (character.Currency >= 100)
            {
                Console.WriteLine("100G를 지불하면 부활할 수 있습니다...");
                Console.Write("부활하겠습니까? (Y/N) : ");
            }
            else
            {
                Console.WriteLine("부활할 수 없습니다...");
                Console.WriteLine("메인 화면으로 돌아갑니다...");
                Console.Write("\nPress enter to continue..."); Console.ReadLine();
            }
        }

        /// <summary>
        /// Show Game Options UI
        /// </summary>
        public static void GameOptionUI()
        {
            Console.WriteLine($"\n| .:~:. Game Options .:~:. |");
            Console.WriteLine();
            int i = 1;
            foreach (var opt in Enum.GetValues(typeof(GameOption)))
            {
                Console.WriteLine($"| {i++}. {opt} |");
            }
            Console.Write("\n원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Setting Options UI
        /// </summary>
        public static void SettingOptionUI()
        {
            Console.WriteLine($"\n| .:~:..:~:. 옵션 .:~:..:~:. |");
            foreach(var line in Miscs.SettingDesign) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:.:~:.:~:.:~:..:~:. |\n");

            int i = 1;
            foreach (var opt in Enum.GetValues(typeof(SettingOptions)))
            {
                Console.WriteLine($"| {i++}. {opt} |");
            }
            Console.Write("\n원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Dungeon UI
        /// </summary>
        /// <param name="character"></param>
        /// <param name="pathOptions"></param>
        public static void DungeonUI(Character character, int[] pathOptions)
        {
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.WriteLine($"| .:~:..:~:. 던전 Lv{GameManager.GroundLevel} .:~:..:~:. |");
            Console.WriteLine($"| .:~:..:~:. 현재 시간 : {GameManager.GameTime} .:~:..:~:. |");
            Console.WriteLine($"| .:~:. 사냥한 몬스터 : {GameManager.KilledMonsterCount}, 목표량 : {GameManager.Quota} .:~:. |");
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");

            Console.WriteLine($"\n| HP : {character.Health:F2} | MP : {character.MagicPoint:F2} |");
            Console.WriteLine($"| Gold : {character.Currency} |");
            Console.WriteLine();
            for (int i = 1; i <= pathOptions.Length; i++)
            {
                Console.WriteLine($"| {i}. {(DungeonOptions)pathOptions[i - 1]} |");
            }
            for (int i = 4, j = 0; i < Enum.GetValues(typeof(DungeonOptions)).Length; i++, j++)
            {
                Console.WriteLine($"| {pathOptions.Length + j + 1}. {(DungeonOptions)(4 + j)} |");
            }
            Console.Write("\n원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Battle UI
        /// </summary>
        /// <param name="character"></param>
        /// <param name="headLine"></param>
        public static void BattleUI(Character character)
        {
            Console.Clear();
            Console.WriteLine("| .:~:..:~:..:~:..:~:. Battle .:~:..:~:..:~:..:~:. |");
            foreach (var line in Miscs.BattleDesign) Console.WriteLine(line);
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.WriteLine($"\n| .:~:..:~:. 현재 시간 : {GameManager.GameTime} .:~:..:~:. |");
            Console.WriteLine($"| Lv : {character.Level} | Gold : {character.Currency} |");
            Console.WriteLine($"| HP : {character.Health:F2} | MP : {character.MagicPoint:F2} |");

            foreach (Skill skill in character.Skills)
            {
                if (skill is BuffSkill buffSkill && buffSkill.IsActive)
                    Console.WriteLine($"| {buffSkill.Name} 효과의 남은 턴 ({GameManager.CurrentTurn - buffSkill.UsedTurn}/{buffSkill.TurnInterval}) | ");

            }

            Console.WriteLine("\n| .:~:. 몬스터 정보 .:~:. |");
            foreach (Monster monster in SpawnManager.spawnedMonsters)
            {
                float atkStat = monster.AttackType == AttackType.Close ? monster.AttackStat.Attack :
                                (monster.AttackType == AttackType.Long ? monster.AttackStat.RangeAttack : monster.AttackStat.MagicAttack);
                Console.WriteLine($"| 이름 : {monster.Name} | HP : {monster.Health:F2} | Atk : {atkStat} |");
            }
            Console.WriteLine("| .:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:..:~:. |");
            Console.WriteLine();
            int i = 1;
            foreach (var opt in Enum.GetValues(typeof(BattleOptions)))
            {
                Console.WriteLine($"| {i++}. {opt} |");
            }
            Console.Write("\n원하는 기능을 선택하세요 : ");
        }

        /// <summary>
        /// Show Base UI
        /// </summary>
        /// <param name="character"></param>
        /// <param name="headLine"></param>
        /// <param name="type"></param>
        public static void BaseUI(Character character, string headLine, Type type)
        {
            Console.Clear();
            foreach (string line in Miscs.Town) Console.WriteLine(line);
            Console.WriteLine($"\n| .:~:..:~:. {headLine} .:~:..:~:.|");
            Console.WriteLine($"| .:~:..:~:. 현재 시간 : {GameManager.GameTime} .:~:..:~:. |");
            Console.WriteLine($"\n| HP : {character.Health:F2} | MP : {character.MagicPoint:F2} |");
            Console.WriteLine($"| Gold : {character.Currency} |");
            Console.WriteLine();
            int i = 1;
            foreach (var opt in Enum.GetValues(type))
            {
                Console.WriteLine($"| {i++}. {opt} |");
            }
            Console.Write("\n원하는 기능을 선택하세요 : ");
        }
    }

    /// <summary>
    /// Contains Quotes and Ascii Arts
    /// </summary>
    static class Miscs
    {
        public static string[] Quotes = { "It's cold and silent.", "My body starts shivering", "I miss the alby's cabin.",
                                          "I should not come down here.", "It feels like someone is watching...",
                                          "I think i'm lost...", "It's dark and moist...", "This place is freaking me out...",
                                          "I hate bats...", "Something feels wrong...", "I miss the henry's shop."};

        public static string[] HardEntrance = {
            "88888888888888888888888888888888888888888888888888888888888888888888888",
            "88.._|      | `-.  | `.  -_-_ _-_  _-  _- -_ -  .'|   |.'|     |  _..88",
            "88   `-.._  |    |`!  |`.  -_ -__ -_ _- _-_-  .'  |.;'   |   _.!-'|  88",
            "88      | `-!._  |  `;!  ;. _______________ ,'| .-' |   _!.i'     |  88",
            "88..__  |     |`-!._ | `.| |_______________||.\"'|  _!.;'   |     _|..88",
            "88   |``\"..__ |    |`\";.| i|_|MMMMMMMMMMM|_|'| _!-|   |   _|..-|'    88",
            "88   |      |``--..|_ | `;!|l|MMoMMMMoMMM|l|.'j   |_..!-'|     |     88",
            "88   |      |    |   |`-,!_|_|MMMMP'YMMMM|_||.!-;'  |    |     |     88",
            "88___|______|____!.,.!,.!,!|0|MMMo * loMM|d|,!,.!.,.!..__|_____|_____88",
            "88      |     |    |  |  | |_|MMMMb,dMMMM|_|| |   |   |    |      |  88",
            "88      |     |    |..!-;'i|9|MPYMoMMMMoM|u| |`-..|   |    |      |  88",
            "88      |    _!.-j'  | _!,\"|_|M<>MMMMoMMM|_||!._|  `i-!.._ |      |  88",
            "88     _!.-'|    | _.\"|  !;|l|MbdMMoMMMMM|n|`.| `-._|    |``-.._  |  88",
            "88..-i'     |  _.''|  !-| !|_|MMMoMMMMoMM|_|.|`-. | ``._ |     |``\"..88",
            "88   |      |.|    |.|  !| |l|MoMMMMoMMMM|l||`. |`!   | `\".    |     88",
            "88   |  _.-'  |  .'  |.' |/|_|MMMMoMMMMoM|_|! |`!  `,.|    |-._|     88",
            "88  _!\"'|     !.'|  .'| .'|[@]MMMMMMMMMMM[@] \\|  `. | `._  |   `-._  88",
            "88-'    |   .'   |.|  |/| /                 \\|`.  |`!    |.|      |`-88",
            "88      |_.'|   .' | .' |/                   \\  \\ |  `.  | `._    |  88",
            "88     .'   | .'   |/|  /                     \\ |`!   |`.|    `.  |  88",
            "88  _.'     !'|   .' | /                       \\|  `  |  `.    |`.|  88",
            "88 ---Hard Stage-- 888888888888888888888888888888888888888888888(FL)888"
        };

        public static string[] EasyEntrance = {
            "|____________________________________________|",
            "|__||  ||___||  |_|___|___|__|  ||___||  ||__|",
            "||__|  |__|__|  |___|___|___||  |__|__|  |__||",
            "|__||  ||___||  |_|___|___|__|  ||___||  ||__|",
            "||__|  |__|__|  |    || |    |  |__|__|  |__||",
            "|__||  ||___||  |    || |    |  ||___||  ||__|",
            "||__|  |__|__|  |    || |    |  |__|__|  |__||",
            "|__||  ||___||  | 9조|| | Dun|  ||___||  ||__|",
            "||__|  |__|__|  |    || |    |  |__|__|  |__||",
            "|__||  ||___||  |   O|| |O   |  ||___||  ||__|",
            "||__|  |__|__|  |    || |    |  |__|__|  |__||",
            "|__||  ||___||  |    || |    |  ||___||  ||__|",
            "||__|  |__|__|__|____||_|____|  |__|__|  |__||",
            "|LLL|  |LLLLL|______________||  |LLLLL|  |LLL|",
            "|LLL|  |LLL|______________|  |  |LLLLL|  |LLL|",
            "|LLL|__|L|______________|____|__|LLLLL|__|LLL|"
        };

        public static string[] Town = {
            "                                                           |>>>",
            "                   _                      _                |",
            "    ____________ .' '.    _____/----/-\\ .' './========\\   / \\",
            "   //// ////// /V_.-._\\  |.-.-.|===| _ |-----| u    u |  /___\\",
            "  // /// // ///==\\ u |.  || | ||===||||| |T| |   ||   | .| u |_ _ _ _ _ _",
            " ///////-\\////====\\==|:::::::::::::::::::::::::::::::::::|u u| U U U U U",
            " |----/\\u |--|++++|..|'''''''''''::::::::::::::''''''''''|+++|+-+-+-+-+-+",
            " |u u|u | |u ||||||..|              '::::::::'           |===|>=== _ _ ==",
            " |===|  |u|==|++++|==|              .::::::::.           | T |....| V |..",
            " |u u|u | |u ||HH||         \\|/    .::::::::::.",
            " |===|_.|u|_.|+HH+|_              .::::::::::::.              _",
            "                __(_)___         .::::::::::::::.         ___(_)__",
            "---------------/  / \\  /|       .:::::;;;:::;;:::.       |\\  / \\  \\-------",
            "______________/_______/ |      .::::::;;:::::;;:::.      | \\_______\\________",
            "|       |     [===  =] /|     .:::::;;;::::::;;;:::.     |\\ [==  = ]   |",
            "|_______|_____[ = == ]/ |    .:::::;;;:::::::;;;::::.    | \\[ ===  ]___|____",
            "     |       |[  === ] /|   .:::::;;;::::::::;;;:::::.   |\\ [=  ===] |",
            "_____|_______|[== = =]/ |  .:::::;;;::::::::::;;;:::::.  | \\[ ==  =]_|______",
            " |       |    [ == = ] /| .::::::;;:::::::::::;;;::::::. |\\ [== == ]      |",
            "_|_______|____[=  == ]/ |.::::::;;:::::::::::::;;;::::::.| \\[  === ]______|_",
            "   |       |  [ === =] /.::::::;;::::::::::::::;;;:::::::.\\ [===  =]   |",
            "___|_______|__[ == ==]/.::::::;;;:::::::::::::::;;;:::::::.\\[=  == ]___|_____"
        };

        public static string[] Rest1 = {
            "       _____",
            "      /      \\",
            "     (____/\\  )",
            "      |___  U?(____",
            "      _\\L.   |      \\     ___",
            "    / /\"\"\"\\ /.-'     |   |\\  |",
            "   ( /  _/u     |    \\___|_)_|",
            "    \\|  \\\\      /   / \\_(___ __)",
            "     |   \\\\    /   /  |  |    |",
            "     |    )  _/   /   )  |    |",
            "     _\\__/.-'    /___(   |    |    Contemplation or Constipation ?",
            "  _/  __________/     \\  |    |",
            " //  /  (              ) |    |",
            "( \\__|___\\    \\______ /__|____|",
            " \\    (___\\   |______)_/",
            "  \\   |\\   \\  \\     /",
            "   \\  | \\__ )  )___/",
            "    \\  \\  )/  /__(       ",
            "___ |  /_//___|   \\_________",
            "  _/  ( / OUuuu    \\",
            " `----'(____________)"
        };

        public static string[] Rest2 = {
            "                           ||||||",
            "                           | o o |",
            "                           |  >  |",
            "                           | \\_/ |",
            "                            \\___/",
            "                           __| |__",
            "                          /       \\",
            "                         | |     | |",
            "        _________________| |     | |_____________---__",
            "       /                 | |_____| |         /  /  / /|",
            "      /                  /_|  _  |_\\        /  /  / / |",
            "     /                    / / / /          /  /__/ / /|",
            "    /____________________/ / / /__________/___\\_/_/ / |",
            "    |____________________| |_| |__________________|/  |",
            "    |____________________| |_| |__________________|   /",
            "____|              |     | | | | ||               |  /",
            "    | o          o | o         o || o           o | /",
            "    |______________|_____________||_______________|/",
            "_______________________________________________________"
        };
        public static string[] Rest3 = {
            "                  __..-----')",
            "        ,.--._ .-'_..--...-'",
            "       '-\"'. _/_ /  ..--''\"\"'-.",
            "       _.--\"\"...:._:(_ ..:\"::. \\",
            "    .-' ..::--\"\"_(##)#)\"':. \\ \\)    \\ _|_ /",
            "   /_:-:'/  :__(##)##)    ): )   '-./'   '\\.-'",
            "   \"  / |  :' :/\"\"\\///)  /:.'    --(       )--",
            "     / :( :( :(   (#//)  \"       .-'\\.___./'-.",
            "    / :/|\\ :\\_:\\   \\#//\\            /  |  \\",
            "    |:/ | \"\"--':\\   (#//)              '",
            "    \\/  \\ :|  \\ :\\  (#//)",
            "         \\:\\   '.':. \\#//\\",
            "          ':|    \"--'(#///)",
            "                     (#///)",
            "                     (#///)         ___/\"\"\\     ",
            "                      \\#///\\           oo##",
            "                      (##///)         `-6 #",
            "                      (##///)          ,'`.",
            "                      (##///)         // `.\\",
            "                      (##///)        ||o   \\\\",
            "                       \\##///\\        \\-+--//",
            "                       (###///)       :_|_(/",
            "                       (sjw////)__...--:: :...__",
            "                       (#/::'''        :: :     \"\"--.._",
            "                  __..-'''           __;: :            \"-._",
            "          __..--\"\"                  `---/ ;                '._",
            " ___..--\"\"                             `-'                    \"-..___",
            "",
            "   (_ \"\"---....___                                     __...--\"\" _)",
            "     \"\"\"--...  ___\"\"\"\"\"-----......._______......----\"\"\"     --\"\"\"",
            "                   \"\"\"\"       ---.....   ___....----"
        };

        public static string[] Quest = {
            "   ______________________________",
            " / \\          -Quest-            \\.",
            "|   |   ____________________     |.",
            " \\_ |   ____________________     |.",
            "    |   ____________________     |.",
            "    |   __________               |.",
            "    |                            |.",
            "    |                            |.",
            "    |                            |.",
            "    |                            |.",
            "    |                            |.",
            "    |                            |.",
            "    |                            |.",
            "    |                            |.",
            "    |   _________________________|___",
            "    |  /                            /.",
            "    \\_/dc__________________________/."
        };

        public static string[] HighLevelGoblinWarrior = {
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=  +@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@   @@@@@@@@@@%       @@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                  @@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@             #@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@          @@@ @@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@           @  %@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                  @@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                   @@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    @@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                     @@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@        @@            @    @@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@       @@@@@         @@@     @@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@      @@@@@@@@        @@@@     @@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@     @ @@@@@@@=          @@@:   :@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+ %@@@@@@@@@              @@@    @@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@  :   @ @@@@ @                :@@   @@",
            "@@@@@@@@@@@@@@@@@@@@@@@@*         %@@@@                  @:   @@",
            "@@@@@@@@@@@@@@@@@@@@             @@@@@@    @@@@         @     @@",
            "@@@@@@@@@@@@@@@@              @@@@@@@@@    @@@@@@@@@   @  @@  @@",
            "@@@@@@                       @@@@@@@@@@@   @@@@@@@@   %  @@  @@@",
            "@@@                    @@@@  @@@@@@@@@@@@@  @@@@@@@   @@@@  #@@@",
            "@@@@               @@@@@@@@@@@@@@@@@@@@@@@    @@@@@@  @@@@@@@@@@",
            "@@@@@         %@@@@@@@@@@@@@@@@@@@@@@@@     @@@@@@@    @@@@@@@@@",
            "@@@@@@   =@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" };

        public static string[] HighLevelGoblinWizard = {
            "@@@@@@@@@@@@@*=@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@         @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@            -@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@%      *%       @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@     @@@@@@@     @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@       :@@@@@    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@        .@@@%    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@       -@@    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@.   :@@   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@   @@@@@@  @@@@@@@@@@@  @@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@  @@@@@@   @@     @#           @@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@  @@@@@@@   :#                  @@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@  @@@@@@@                      @@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@  @@@@@@@@                    @@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@  @@@@@@-                @@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@ @@@@@@@@@                 @@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@   @@@@@@@.                  @@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@    @@@@@@@                    @@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@     @@@                       @@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@                               @@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@  @@@@@@@                    #@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@  @@@@@@@                     @@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@ @@@@@@         @       .     @@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@  @@@@                 +  =   %@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@  @@@@                @@@: @=  @@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@ @@@@@.    #   @+   @@@@@.@@  @@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@  @@@      @@ @@@    @@@@@@@@ *@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@#  +@@      @@@@@     @@@@@@@@ @@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@  @@@@@=@@@@@@@@@   %@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        };
        public static string[] HighLevelGoblinArcher = {
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@* @@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@# %@@@@@@@@@@@@@@@",
            "@@@@@@@@@@%   +@@@#     =@@@@@@@@@@%+-#@@@@@@@@@@@",
            "@@@@@@@@@@@@%             -@@@@@@@@#@% =@@@@@@@@@@",
            "@@@@@@@@@@@@@@            =%@@@@@@@%@@@ +%@@@@@@@@",
            "@@@@@@@@@@@@@@@@:           +@@@@@@@@@@@@ *%@@@@@@",
            "@@@@@@@@@@@@@@*+.           :@@@@@%@@@@@@ +%@@@@@@",
            "@@@@@@@@@@@@@#.=.         *=@@@@@@%@@@@@@= #@@@@@@",
            "@@@@@@@@@@-@@-           %@@@@@@@@*@@@@@@% *#@@@@@",
            "@@@@@@@@:            .*-%@*=+@@@@@@%@@@@@@= ##@@@@",
            "@@@+       =         *  :+=*@@@@@%#@%@   =*%   =@@",
            "@@+                 :#.     -@:     : +###-  +@@@@",
            "@@+.        *-       +%@            .-=++*=  #@@@@",
            "@@@@@@@@@@@+-**       @@ :     :   --++#@ =*@@@@@@",
            "@@@@@@@@@@@@      :   * @@@@@@@@**@@@@@@# **@@@@@@",
            "@@@@@@@@@@@@%    :     @@@@@@@@@@%@@@@@@ :*#@@@@@@",
            "@@@@@@@@@@@@.         @%*==%@@@@*@@@@@@@ **@@@@@@@",
            "@@@@@@%-@@  = :       : **-#@@@@*@@@@@# +#@@@@@@@@",
            "@@@@@@ :-+=-..        +*:-**@@@@#@@@  +#@@@@@@@@@@",
            "@@@@@# ++*=: -:----      =+@@@@@@@ -*@@@@@@@@@@@@@",
            "@@@@@* **%:  -:.:.:     %@*@@@@@:-*@@@@@@@@@@@@@@@",
            "@@@@@% *@:   :--:+      @@@@@@@.-@@@@@@@@@@@@@@@@@",
            "@@@@@@.*@=    :--#      @*%@@@#-%@@@@@@@@@@@@@@@@@",
            "@@@@@@#=*     .==#      #=%%%%# %%@@@@@@@@@@@@@@@@",
            "@@@@@@@@#     .++*      .%@@@@%=@@@@@@@@@@@@@@@@@@",
            "@@@@@@@+      #@*      :@@@@@@@%%%%@@@@@@@@@@@@@@@",
            "@@@@@@@+      %@%      .#%@@@@%@%@@@@@#@@@@@@@@@@@",
            "@@@@@@@%      %@@       #%@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@%+    %@@%#      #%%%%@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@%     %@@%%@:      %#*@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@%      #%%%%%%.      +##@@@@@@@@@@@@@@@@@@@",
            "@@@@@@%-:    =*#######     .:###+-*##@@@@@@@@@@@@@",
            "@@@@@@@#+-==+###*###+=-.::+***+==+#@%%@%@@@@@@@@@@",
            "@@@@@@#**=**#+*#*#*#+---=+**#*==+*@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        };
        public static string[] Goblin = new string[]
        {@"                                    ^                     
                                              -+.       
                                            .++*.       
                                    =+#.   .=+#+-       
                      .-+++++:.    :-+=-   +++++:       
    .....          .::..:--::::=-..:=+.   .++=++.       
  .--===---..     .....:--::::::.::.=+    =*+==+.       
   .:+++===-:....=........:-:::..=#===.  .*+++*-        
      .++====-:.::-..=+*%+..::..=*-==+.  -#+=+*.        
        -+====++-::.-+#%#+=-::.:**-==-  .+++=+=.        
         :+=====+=:..:-@@=:.::..-+-=:   :*++=*:         
          .-+**+=::..-=--:...::......  .+++=++.         
             -==-.::...-=-....:=-.:.   .*++-*=.         
                :=-=+=-::..:-::-+=-.   -++==+-          
               .*=----=++***#*=-+*#+.  +++++=.          
              .=+#+++**#++++++=#*+-+-:.:++=-.           
              :**-:::=**+=+*+=-+*=::=:=***+=:.          
             .#*=:::-=+#*-=+++=*#=::=+=+-:-...          
             #+=:..:==+***=---=+**==+*++--:             
            #*+**+-**+**=+***+++******==.               
           .******+**#**+#+:#:*****+*+:-:               
           +*#+==***+##*#*=:+-+*###++*..                
          -*+-::..-=----=**=-----=**++=                 
         .+++:::-=-*++++**#*+===+**++++=.               
          .::=+=--*=.:.-*+**+::::++--=:.                
       ..:::::-=:. :...:.*+.:...-                       
         .....   .:-:..:   .:...-=-:.                   
             ..:*#.#-==+....:-+===+==-.......           
                    ...................             "};

        public static string[] GoblinArcher = new string[]
        {@"
                                            ..
                           ...::::..   .=+. ..
             -*+*=..     .+:::::::::+..=*: .*-
               =++*+:++.:-::::=-:::-:--=+: .#+.        
                .++++*=:--:+%@#:::::#@#*+... -#.       
                 -++++#%#::=.%@@#=-%@=*++..   :#:      
                  .+++***-:-=#@--==+@===:.     +%.     
                    .:+++=:-*+--:-=-=-=:.      -#:     
                       .**##-:-+==+=+#+        *#.     
                       =##%#*#%%##%%*%#=.    .*%.      
                     .+##*+*%#*#***##*-=....-=%#:.     
                    .+%-=++##*:--#@###*#%%%%#*#%#-.    
                    +%=::+**:::=+%##*@@##*#+=+-=.      
                  .=#@@%%%%%##=###+%#@@+.  .*%=.       
                 .*#%%%@%%##%%####*#%#%%:   -#.        
                 =*%%%%%%##**#**%#***#%%#. .+#.        
                 .=:.=*-*+=+#%%#%%##+*#-*..+#-         
                .=+==+::-+--::...-::+... =#:.          
                  .......--:-.  .=:--:..#-.            
                  ....:***#+=::..--=+#++#:...  
                         .  ...   .    .          "};

        public static string[] GoblinWizard = new string[]
        { @"         
            ...:--:..    :+=. .-==:..   
             .*==+=..    .=::::::::::-.:-+. .=:.::=.   
               .*==*::+..-:::::-:-=-::-:*=. ---:::-:   
                .-=++++::-:-=#@-:-::+%+#+=.  ##++*..   
                 .=++++%#-:=.%@%+-:+@*=*+-   .*##*.    
                   :=+++*-::-==:=-====:=:    .*#.      
                     .-===::-*---:::-+:-.    .**.      
                       .#**#*-:::=-:=%*=.    .#*.      
                       =####+**#%%%#**##.    :#-       
                      .**#*####*****###=+..:-++=.      
                     .##*::*#***%@%***+-:+#=**==.      
                    .*@:::%#**%#%#**##@*:*#*+=:-.      
                   .#@##*#@%%%##=##*#%%%*...*%.        
                  .+#@=-=*#****#*#*#**%%#. .#+.        
                  **%*=-:=*****#*##****@#+..*=         
                ...****=-#%+*#%%##%##+%%#*:.#.         
                .-===+---=+----==--:--.....+#.         
                  ........--:=...-=--=:....#+          
                   ....:#**++=...---=*#+-..=:..      
        "};

        public static string[] Henry = new string[]
        {
            @"              /     \              ",
            @"             / (/@\) \             ",
            @"         \__/_________\__/         ",
            @"           |  O     O  |           ",
            @"           |     ^     |           ",
            @"           |   \___/   |           ",
            @"            \_________/            ",
            @"         ___/   |||   \___         ",
            @"       /`    \       /    `\       ",
            @"       \__.   |     |   .__/       ",
            @"           \  |     |  /           ",
            @"            \_|_____|_/            ",
            @"                                   ",
            "  자네! 지금 강해지고 싶어서 왔는가!?  ",
            "  하하하! 잘 찾아왔구만! 한번 골라봐~  ",
            "    많이 사면 싼 가격에 쳐출테니~     ",
        };

        public static string[] Alby = new string[]
        {
            @"             /     \             ",
            @"            / -(+)- \            ",
            @"         __/_________\__         ",
            @"        / |  O     O  | \        ",
            @"          |     ^     |          ",
            @"          |   '---'   |          ",
            @"           \_________/           ",
            @"        ___/   |||   \___        ",
            @"      /`    \       /    `\      ",
            @"      \__.   |     |   .__/      ",
            @"          \  |     |  /          ",
            @"           \_|_____|_/           ",
            " 어머~ 오셨군요~? 오랜만에 오셨어요~ ",
            "    늘 하던 스위트룸으로~? 농담~    ",
            "  오늘은 어떤방으로 안내해드릴까요~? ",
        };

        public static string[] GameStart = new string[]
        {@" 
+=====================================================================================+ 
|                           `            .              .               .             | 
|           *                                                                *        | 
|     `         ` . **   `            .     |>>>     .                 *              | 
|   *     `      `                          |                    ...            .     | 
|                                       _  _|_  _     *                      *        | 
|       ..            `       |>>>     |*| |*| |*|         |>>>       .               | 
|              `              |        \         /         |          .               | 
|        `  *             _  _|_  _     \       /      _   |_  _                      | 
|      *                 |;|_|;|_|;|    ||     |      |;| |;|_|;|                     | 
|  .       .             \         /    ||     |      \         /                     | 
|               `         \    `  /     ||     |       \  ` `  /            *         | 
|         `               ||:`    |_   _ |_   _|  _   _ |     |                       | 
|                         ||:     ||| |}||}|_|}|_|}| |}||: .  |          .            | 
|                         ||:  .  ||       `           ||:    |                       | 
|                         ||:     ||:  `         `     ||:  ` |                       | 
|                         ||: .   ||       __**__      ||: .  |                       | 
|                         ||:     ||  `   /:: ': \     ||:    |                       | 
|                         ||:     || :   ||::::: |   ` ||:    |                       | 
|                         ||:     ||     ||':::::|     ||:    |                       | 
|                    ____ ||:     ||  `  ||::::: |    _||_    |                       | 
|               -+H+       -+H+-  ||     ||:  :::___         ___                      | 
|          ____     -+      _____    ____   ____  _____   ______                      | 
|     -+H+-             ___|\    \  |    | |    ||\    \ |\     \  ++-_____  _        | 
| __                   |    |\    \ |    | |    | \\    \| \     \               ____ | 
|                      |    | |    ||    | |    |  \|    \  \     |          -+H+_-+H+| 
|                      |    | |    ||    | |    |   |     \  |    |       -+          | 
|                      |    | |    ||    | |    |   |      \ |    |                   | 
|                      |    | |    ||    | |    |   |    |\ \|    |                   | 
|                      |____|/____/||\___\_|____|   |____||\_____/|                   | 
|                      |    /    | || |    |    |   |    |/ \|   ||                   | 
|                      |____|____|/  \|____|____|   |____|   |___|/                   | 
|                        \(    )/       \(   )/       \(       )/                     | 
|                         '    '         '   '         '       '                      | 
|                                                                                     |
|                                                                         CREATED BY. | 
|                                                                                     | 
|                                                                          PARK_DOUN  | 
|                                                                         CHO_YUNJAE  | 
|                                                                        PARK_JIHWAN  | 
|                                                                        KIM_KONGSIK  | 
|                                                               ★ MVP  BANG_EUNSEONG  | 
|                                                                                     | 
+=====================================================================================+"
        };

        public static string[] CharacterSelection = new string[]
        {
            @"+===============================================================+",
            @"|                                                               |",
            @"|    [1. WARRIOR]          [2. WIZARD ]          [3. ARCHER]    |",
            @"|         /\                  '(**),                            |",
            @"|        /__\                   ||                 |\           |",
            @"|        |  |                   ||                 | '\         |",
            @"|        |  |                   ||                 |   |        |",
            @"|        |  |                   ||               >-------=>     |",
            @"|        |__|                   ||                 |   |        |",
            @"|         ||                    ||                 | ,/         |",
            @"|        .||.                   ()                 |/           |",
            @"|                                                               |",
            @"|                                                               |",
            @"|                        Select your Job!                       |",
            @"+===============================================================+",
        };

        public static string[] GameOver = new string[]
        {
            @"| ======================================================================== |",
            @"|  ██████   █████  ███    ███ ███████     ██████  ██    ██ ███████ ███████ |",
            @"| ██       ██   ██ ████  ████ ██         ██    ██ ██    ██ ██      ██   ██ |",
            @"| ██   ███ ███████ ██ ████ ██ █████      ██    ██ ██    ██ ███████ █████   |",
            @"| ██    ██ ██   ██ ██  ██  ██ ██         ██    ██ ██    ██ ██      ██   ██ |",
            @"|  ██████  ██   ██ ██      ██ ███████     ██████   ██████  ███████ ██   ██ |",
            @"| ======================================================================== |",
        };

        public static string[] WeaponDesign = new string[]
        {
            "   |\\                     /)",
            " /\\_\\\\__               (_//",
            "|   `>\\-`     _._       //`)",
            " \\ /` \\\\  _.-`:::`-._  //",
            "  `    \\|`    :::    `|/",
            "        |     :::     |",
            "        |.....:::.....|",
            "        |:::::::::::::|",
            "        |     :::     |",
            "        \\     :::     /",
            "         \\    :::    /",
            "          `-. ::: .-'",
            "           //`:::`\\\\",
            "          //   '   \\\\",
            "         |/         \\\\"
        };


        public static string[] PotionDesign = new string[]
        {
            "         @@@@@@@@         ",
            "         @@@@@@@@         ",
            "        @@@    @@@        ",
            "         @@@  @@@         ",
            "         @@@  @@@         ",
            "         @@@  @@@         ",
            "        @@@    @@@        ",
            "       @@@  @@@@@@@       ",
            "      @@@@@@@    @@@      ",
            "      @@@         @@      ",
            "     @@@@          @@     ",
            "    @@@@            @@    ",
            "     @@            @@@    ",
            "      @@@@@@@@@@@@@@ "
        };


        public static string[] ArcherDesign = new string[]
        {
            "#####                              ##",
            "%%%%#                          ##### ",
            "%%%%####################    #######  ",
            "@@%%%%%%%%%%%%%%%%%%%%####   #####   ",
            "@@   %%%%%%%%%%%%%%%%%%%##%### ##    ",
            "@@                 %%%%%%###         ",
            " @@                  %%%#######%     ",
            " @@                  %##%%%%%%###    ",
            " @@                 ###%%%%%%%%##%   ",
            "  @               ###      %%%%%##   ",
            "  @@            ###        %%%%%##   ",
            "  @@          ###           %%%%##   ",
            "  @@        ####            %%%%##   ",
            "  @@   %% ###*              %%%%#%   ",
            "   @  %%%###                %%%%#    ",
            "   @%%%##%%%                %%%##    ",
            "   %%%##%%%                 %%%##    ",
            "   @@%%%%@                   %%######",
            "      %%@@@@@@@@@@@@@@@       %%%%%##",
            "                       @@@@@@@@@%%%%#"
        };

        public static string[] MazeDesign = new string[]
        {
            "                                   ",
            "                   #########       ",
            "                ##############     ",
            "               #####*******#####   ",
            "              ####***+++++**#####  ",
            "             ####****+**+****####  ",
            "             ####*************###  ",
            "             ####************####  ",
            "              ####**********#####  ",
            "             #######*******####    ",
            "           #########               ",
            "         #########                 ",
            "        #########                  ",
            "      ########                     ",
            "    #########                      ",
            "  #########                        ",
            "  #######                          ",
            "   ####                           "
        };
        public static string[] Inventory = new string[]
        {
            "               ##% ###               ",
            "               ##   #%               ",
            "          #################          ",
            "        ##########%##########        ",
            "       #########     #########       ",
            "      ###########% ############      ",
            "      #########################      ",
            "      #########################      ",
            "      #### ############### ####      ",
            "  %## ####                 #### ###  ",
            "  ### #### ############### #### #### ",
            "      #### ############### ####      ",
            "  ### #### ############### #### #### ",
            "  ### ####################%#### #### ",
            "  ### ######################### #### ",
            "  ###                           #### ",
            "  %## ######################### ###  ",
            "      %########################      ",
            "        %###################%        "
        };


        public static string[] ArmorDesign = new string[]
        {
            "==09조==!====!=====!=====!====!===!===!=====!===!===!====",
            "      /`\\__/`\\   /`\\   /`\\  |~| |~|  /)=I=(\\  /`\"\"\"`\\",
            "     |        | |   `\"`   | | | | |  |  :  | |   :   |",
            "     '-|    |-' '-|     |-' )/\\ )/\\  |  T  \\ '-| : |-'",
            "       |    |     |     |  / \\// \\/  (  |\\  |  '---'",
            "       '.__.'     '.___.'  \\_/ \\_/   |  |/  /",
            "                                     |  /  /",
            "                                     |  \\ /",
            "                                     '--'`"
        };

        public static string[] path = {
            @"
+==================================================================================+
|                                 |               ||   ____  ____  ____  ____      |
|     _.-=-.     ____  ____  ____|            '   ||  /\   \/\   \/\   \/\   \     |
|               /\   \/\   \/\   \     .           | /  \___\ \___\ \___\ \___\    |
|              /  \___\ \___\ \___\  ┌──────────┐  | \  /   / /   / /   / /   /    |
|              \  /   / /   / /   /  │1.FORWARD │  |  \/___/\/___/\/___/\/___/     |
|               \/___/\/___/\/___/   └──────────┘  ||                              |
|                                 |                 |    _.-=-._                   |
|                                ||                 |                              |
|                                |         '        |                              |
|                                |                   |                             |
|                                ||            .     |                             |
|                                 |                  ||                            |
|            _.-=-._.             |     .             |                            |
|                                  |                  |                            |
|                           ____  ____                |                            |
|                          /\   \/\   \               ||               _.-=-.      |
|                         /  \___\ \___\    '         |                            |
|                         \  /   / /   /       .       |____  ____                 |
|                          \/___/\/___/                /\   \/\   \                |
|                                  |                  /  \___\ \___\               |
|                                  ||        .        \  /   / /   /               |
|     _.-=-._                       ||   '             \/___/\/___/                |
|                                    |          '     |                            |
|                                   ||                ||                           |
|                                    |                |                            |
|                                    |      '        ||                            |
|                                  |||               |                             |
|                                  |           '    ||                             |
+==================================================================================+
            ",
            @"
+==================================================================================+
|                                  ||                            _.                |
|     .               .               ||||                                 /\      |
|                  ,      ,              ||||                             O  O     |
|        ,                                  |||                            \/      |
|                                      .       |||       /\ /\ /\                  |
|                 ,            ┌─────────┐       ||     O  O  O  O                 |
|||                            │1. LEFT  │         ||    \/ \/ \ /\ /\             |
| |||| |||| ||||           .   └─────────┘          |           O  O  O            |
|     |          ||||||                         .    |           \/ \/             |
|                     || ||                           |                            |
|                          ||||||        ,            ||                           |
|                               ||||               .   |                           |
|            _.-=-._.             |     .               |                          |
|                                  |                  | |                          |
|      /\                          ||                 ||              _.""._.""._.   |
|     O /\ /\                      ||                  |                           |
|      O  O  O                      |       '         |                            |
|       \/ \/                       |          .       ||     _.""._.""              |
|                                   |                  |                           |
|                                  ||                  |                           |
|      O                /\         ||        .         ||                          |
|     _ -=-._          O  O         ||   '              |              /\          |
|                       \/           |          '     |||       /\ /\ O  O         |
|                                   ||                ||       O  O  O \/          |
|                                    |                |         \/ \/              |
|                                    |      '          |                           |
|                 _..-              ||                |                            |
|                                  |           '      ||                           |
+==================================================================================+
            ",
            @"
+==================================================================================+ 
|                                                         ||                         
|                *                                   |||||                         | 
|                         *                     ||||                              || 
|     *                                      |||    ┌──────────┐                |||| 
|                 *                       |||       │1. RIGHT  │             |||   | 
|                                      |||          └──────────┘       | |||       | 
|                                    ||                            |||             | 
|                                   |                          |||                 | 
|                                ||                          ||           *        | 
|   .oOo                       ||                         ||                       | 
|                  *          ||                      ||              *            | 
|                            ||                    ||                              | 
|                           ||                    ||                               | 
|                           ||                   ||                                | 
|                          |                   ||      .oO                         | 
|                         ||                  ||                                   | 
|                          |                 ||                                    | 
|                         |                  ||                    .oOo.oOo.o      | 
|  .oOo.oOo.oO             |                  |                                    | 
|                         |                  ||                                    | 
|          .oOo.oOo.oOo   |                   |                                    | 
|                         ||                   |             .oOo.oOo.oOo.oOo.     | 
|  .oOo.oO                ||                    |         .oOo.                    | 
|                         |                     ||  .oOo.oOo.oOo.o                 | 
|                         |                       |                    .oOo.o      | 
|                          |                      ||                          .oOo | 
|      .oOo.oO             ||                      |    .       .oOo.o             | 
|                           ||                 '    ||                             | 
+==================================================================================+
            ",
            @"
+==================================================================================+
|                       -+         |   .           .     | ____|____|____|____|__| |
|                                  ||   ┌────────────┐   | __|____|____|____|____| |
|         -+H+-                     |   │1. FORWARD  │   |  _________________ |__| |
|                                    |  └────────────┘     |____|____|____|__|__ __|
|                                    |                    ||__|____|____|____||_|__|
||||                       -+H+     ||              .     ||____|____|____|__|__|__|
|| |||||                             |       .           |  _________________ |_|__|
|      || ||||| |                    |                   | |____|____|____|__|__ __|
|               |  |||| ||          ||                   | |__|____|____|____||_|__|
|                          ||||||||  |             .      ||____|____|____|__|__|__|
|     .                           |||    ,              |  _________________ _|_|__|
|           ┌─────────┐   ,                        .    | |____|____|____|__|__ __ |
|        ,  │2. LEFT  │                 .                ||__|____|____|____||_|__||
|           └─────────┘                                  ||____|____|____|__|__|__||
|                 ,                                     |______________________|__||
|||                                .                   ||____|____|____|____| _|__||
| |||| |||| ||||           .                '           |__|____|____|____|__|_|__||
|     |          ||||||                        .        |____|____|____|____||_|__||
|                     || ||                             |_ ______________________  |
|                          ||||||                      |  |____|____|____|____|__| |
|                               |||||        .           ||__|____|____|____|____| |
|     -+H+-                          |   '               ||____|____|____|____|__| |
|                                    |          '       |  _________________ |__|  |
|                                    |                  |_|____|____|____|__|__  __|
|                -+H+-+H             |                  |_| _________________ _||__|
|                                    |      '           |  |____|____|____|__| _|__|
|                                   ||                  |  |__|____|____|____||_|__|
|                                  |           '       | | |____|____|____|__||_   |
+==================================================================================+
            ",
            @"
+==================================================================================+
|                            ||                   ||    .oO         ||||           |
|        *       *            |   ┌───────────┐    |           ||||||              |
|              *              |   │1. FORWARD │   ||      ||||||                   |
|                             |   └───────────┘    |   ||||                        |
|                            |                     | ||      ┌──────────┐          |
|                         *  |                      ||       │2. RIGHT  │          |
|                            ||                              └──────────┘          |
|          *                  |                                                    |
|                             |                                                  |||
|                             |                                             |||||  |
|     .                *     |                                     ||| ||| |       |
|                             |                                 |||    .-.-.   .-.-|
|                   *        |                                |||     / / \ \ / / \|
|       *                    |                             ||||      `-'   `-`-'   |
|                             |                      | ||||| . .-.-.               |
|                      *      |                   | |||       / / \ \              |
|                             |                    ||        `-'   `.oOo.oOo.o     |
|                              |                   ||                              |
|                              |                   ||     .-.-.   .-.-.            |
|           *                  |                   ||    / / \ \ / / \ \           |
|                             ||                   ||   `-'   `-`-'   `-`.-.-.  o  |
|                     *     |||                    |  .oOo.             / / \ \    |
|                            ||                    |                   `-'   `-`   |
|                             |                   ||                               |
|      *                      |                   |         .-.-.   .-.-.  Oo.oOo. |
|                            ||             '     |        / / \ \ / / \ \         |
|                          *  |                   ||    .o`-'   `-`-'   `-`        |
|                            |||               '   ||                 .o           |
+==================================================================================+
            ",
            @"
+===============================+=================================================+
|                                                   ||||                          |
|             ^v                     ^v^        || |                              |
|                                             |||                                 |
||                      ^v^               | |         ┌──────────┐                |
| ||||                                    ||          │ 2. RIGHT │                |
|    |||||||||||||||||||||               |            └──────────┘               ||
|                        ||||||||||||   ||                                  |  || |
|                                    |||||                              ||| ||    |
|                                        |                    |    ||  |          |
|                    ┌─────────┐                             ||| |||              |
|                    │ 1. LEFT │              .           |||                     |
|                    └─────────┘                        ||                        |
||||    ||||||                         .               |                          |
|  ||||||    |||||||                                 | |              ^v^v^v^     |
|                  ||||||                            ||                           |
|                       ||  |                        ||                           |
|                        |||||             '         |                            |
|                               ||||          .       |                           |
|                               | ||                  |                           |
|                                ||                   |                           |
|              ^v^v             ||          .         ||                          |
|                               |       '              |                          |
|                               ||             '     |||      ^v                  |
|                                |                   ||                           |
|                                |                   |                            |
|    ^v^v^v^                     |         '        ||                            |
|                                ||                 ||               ^v^v^        |
|                                 |           '    | |                            |
|                                 ||                 ||                           |
|                                 |                   ||                          |
|                                |||                   ||                         |
+=================================================================================+
            ",
            @"
+==================================================================================+
|                     *                  ||                 |                      |
|         *                             ||                 ||             -+H+     |
|                                     * |             .    |                       |
|                            *         ||  ┌──────────┐   |                        |
||                   |                 |   │1.FORWARD │  ||                     ||||
| |||||      |||||||   |||            ||   └──────────┘ ||             |     |||   |
|      || |              |||||||| |||| |                |         |||||  |||||     |
|                                                      ||||||||||||                |
|       *       *                                                         :        |
|             *┌─────────┐                                  ┌──────────┐           |
|              │ 2. LEFT │                                  │ 3. RIGHT │        ,  |
||             └─────────┘                                  └──────────┘        ||||
| ||||||||||||||                                                         |  ||||   |
|             |||||||||||                                            ||            |
|        *              |||||||                             .    |||               |
|                        ,    ||||                           = ||        -+H+-+H   |
|                                |                          ||                     |
|                    *           |                      ||     -+             .    |
|                                |                   ||       .                    |
|                 *             |                  ||                              |
|     *                         |    .            |                                |
|                              |                ||                                 |
|                    *        ||               ||                                  |
|                             |                |                                   |
|                             |               ||                    -+H+-+         |
|                            ||               |                                    |
|         *                  |             .  ||                                   |
|                           ||                ||                                   |
|                   *       ||                |         -+H+-+H+-                  |
|                            | |             ||                                    |
|                            |||                                                   |
+==================================================================================+
            ",
        };

        public static string[] WarriorDesign = new string[]
        {
            "           ,",
            "          / \\",
            "         {   }",
            "         p   !",
            "         ; : ;",
            "         | : |",
            "         | : |",
            "         l ; l",
            "         l ; l",
            "         I ; I",
            "         I ; I",
            "         I ; I",
            "         I ; I",
            "         d | b\t",
            "         H | H",
            "         H | H",
            "         H I H",
            " ,;,     H I H     ,;,",
            ";H@H;    ;_H_;,   ;H@H;",
            "`\\Y/d_,;|4H@HK|;,_b\\Y/'",
            " '\\;MMMMM$@@@$MMMMM;/'",
            "   \"~~~*;!8@8!;*~~~\"",
            "         ;888;",
            "         ;888;",
            "         ;888;",
            "         ;888;",
            "         d8@8b",
            "         O8@8O",
            "         T808T",
            "          `~` \t"
        };

        public static string[] BattleDesign = new string[]
        {
            "                                                       ",
            "      ##-                                     +##      ",
            "      .++++@                              .#+++%       ",
            "       +++++                           #++++*        ",
            "        ++++-                       #+++++#         ",
            "          #+++++#.                   ++++++           ",
            "            #++*++#                :#++=            ",
            "              #++#++             #++#++#              ",
            "               .#+#+=         #++#++*                ",
            "                 -+**+#      ++#++#                  ",
            "                   =+++%  -+++#                    ",
            "                     ++++++@++++#:                     ",
            "                       %+++++#-                       ",
            "                       **%++++#                        ",
            "                     :+++#++++%                      ",
            "                    #++++@  :++++*                    ",
            "                  #++++#      =+++=                  ",
            "                ++++#:         #++++#.                ",
            "     @@@@=    -+++-             #++++#     #@@@=     ",
            "        #@@@:#++++                 #++++#@@@.        ",
            "          :@@@@+#                     #@@@@           ",
            "          %@@@@@                      -@@@@@=          ",
            "        +@@@. #@@.                   @@. #@@@         ",
            "       @@@:     @@-                 %@     #@@%       ",
            "    .@@@-        @#                 @*        #@@@     ",
            "     @@           .                            -@+ "
        };

        public static string[] SettingDesign = new string[]
        {
            "            %%%%%               ",
            "      +%=  .%%%%%.  =%+         ",
            "     =%%%%%%%%%%%%%%%%%%%=      ",
            "      -%%%%%#-...-#%%%%%-       ",
            "       *%%*         *%%*        ",
            "   +%%%%%#.     .#*. *%%%%%*    ",
            "   +%%%%%*  *# #%%.  +%%%%%*    ",
            "   +%%%%%#. :%%%:    *%%%%%*    ",
            "       *%%*   .     *%%*        ",
            "      -%%%%%#-...-#%%%%%-       ",
            "     =%%%%%%%%%%%%%%%%%%%=      ",
            "       +%=  .%%%%%.  =%+        ",
            "             %%%%%              "
        };
    }

    /// <summary>
    /// Lists of items
    /// </summary>
    static class ItemLists
    {
        public static readonly Armor[] Armors = {
            new Helmet("사슬 헬멧", new DefendStat(3.1f, 2.4f, 1.2f), 15, Rarity.Common),
            new ChestArmor("사슬 갑옷상의", new DefendStat(5.1f, 4.2f, 3.3f), 30, Rarity.Common),
            new LegArmor("사슬 갑옷하의", new DefendStat(1.5f, 1.3f, 0f), 8, Rarity.Common),
            new FootArmor("사슬 장화", new DefendStat(0.5f, 0.3f, 0.1f), 4, Rarity.Common),
            new Gauntlet("사슬 건틀렛", new DefendStat(1.5f, 1.3f, 0f), 8, Rarity.Common),
            new Helmet("철제 헬멧", new DefendStat(5.1f, 4.2f, 3.3f), 50, Rarity.Exclusive),
            new ChestArmor("철제 갑옷상의", new DefendStat(7.1f, 6.2f, 5.3f), 80, Rarity.Exclusive),
            new LegArmor("철제 갑옷하의", new DefendStat(3.5f, 3.3f, 1.2f), 40, Rarity.Exclusive),
            new FootArmor("철제 장화", new DefendStat(1.5f, 1.3f, 0.6f), 30, Rarity.Exclusive),
            new Gauntlet("철제 건틀렛", new DefendStat(3.5f, 3.3f, 1f), 40, Rarity.Exclusive),
            new Helmet("티타늄 헬멧", new DefendStat(7.1f, 6.2f, 5.3f), 120, Rarity.Rare),
            new ChestArmor("티타늄 갑옷상의", new DefendStat(9.1f, 8.2f, 7.3f), 180, Rarity.Rare),
            new LegArmor("티타늄 갑옷하의", new DefendStat(5.5f, 5.3f, 3.2f), 100, Rarity.Rare),
            new FootArmor("티타늄 장화", new DefendStat(3.5f, 3.3f, 1.6f), 80, Rarity.Rare),
            new Gauntlet("티타늄 건틀렛", new DefendStat(5.5f, 5.3f, 1.2f), 100, Rarity.Rare),
            new Helmet("다이아몬드 헬멧", new DefendStat(10.1f, 9.2f, 8.3f), 260, Rarity.Hero),
            new ChestArmor("다이아몬드 갑옷상의", new DefendStat(12.1f, 11.2f, 10.3f), 480, Rarity.Hero),
            new LegArmor("다이아몬드 갑옷하의", new DefendStat(8.5f, 8.3f, 6.2f), 220, Rarity.Hero),
            new FootArmor("다이아몬드 장화", new DefendStat(6.5f, 6.3f, 4.6f), 160, Rarity.Hero),
            new Gauntlet("다이아몬드 건틀렛", new DefendStat(10.5f, 8.3f, 2.2f), 220, Rarity.Hero),
            new Helmet("\"던\"의 헬멧", new DefendStat(20.1f, 19.2f, 18.3f), 1000, Rarity.Legend),
            new ChestArmor("\"던\"의 갑옷상의", new DefendStat(22.1f, 21.2f, 20.3f), 1500, Rarity.Legend),
            new LegArmor("\"던\"의 갑옷하의", new DefendStat(18.5f, 18.3f, 16.2f), 650, Rarity.Legend),
            new FootArmor("\"던\"의 장화", new DefendStat(16.5f, 16.3f, 14.6f), 500, Rarity.Legend),
            new Gauntlet("\"던\"의 건틀렛", new DefendStat(18.5f, 18.3f, 12.2f), 650, Rarity.Legend),
        };

        public static readonly Weapon[] Weapons = {
            new Sword("목검", new AttackStat(7f, 0f, 0f), 10, Rarity.Common),
            new Bow("새총", new AttackStat(0f, 7f, 0f), 10, Rarity.Common),
            new Staff("나무 스태프", new AttackStat(0f, 0f, 7f), 10, Rarity.Common),
            new Sword("철제 검", new AttackStat(12.5f, 0f, 0f), 120, Rarity.Exclusive),
            new Bow("사냥꾼의 활", new AttackStat(0f, 12.5f, 0f), 120, Rarity.Exclusive),
            new Staff("고목나무 스태프", new AttackStat(0f, 0f, 12.5f), 120, Rarity.Exclusive),
            new Sword("티타늄 검", new AttackStat(17.5f, 0f, 0f), 250, Rarity.Rare),
            new Bow("각궁", new AttackStat(0f, 17.5f, 0f), 250, Rarity.Rare),
            new Staff("버드나무 스태프", new AttackStat(0f, 0f, 17.5f), 250, Rarity.Rare),
            new Sword("다이아몬드 검", new AttackStat(25f, 0f, 0f), 500, Rarity.Hero),
            new Bow("신궁", new AttackStat(0f, 25f, 0f), 500, Rarity.Hero),
            new Staff("딱총나무 스태프", new AttackStat(0f, 0f, 25f), 500, Rarity.Hero),
            new Sword("\"던\"의 검", new AttackStat(60f, 0f, 0f), 1000, Rarity.Legend),
            new Bow("\"던\"의 활", new AttackStat(0f, 60f, 0f), 1000, Rarity.Legend),
            new Staff("\"던\"의 스태프", new AttackStat(0f, 0f, 60f), 1000, Rarity.Legend),
        };

        public static readonly Consumables[] Consumables =
        {
            new HealthPotion("소형 HP 포션", 20, 15, Rarity.Common),
            new HealthPotion("중형 HP 포션", 50, 80, Rarity.Exclusive),
            new HealthPotion("대형 HP 포션", 100, 150, Rarity.Rare),
            new MagicPotion("소형 MP 포션", 15, 30, Rarity.Common),
            new MagicPotion("중형 MP 포션", 60, 130, Rarity.Exclusive),
            new MagicPotion("대형 MP 포션", 120, 260, Rarity.Rare),
            new AttackBuffPotion("하급 공격력 증가 포션", 5, 10, Rarity.Common),
            new AttackBuffPotion("중급 공격력 증가 포션", 10, 30, Rarity.Exclusive),
            new AttackBuffPotion("상급 공격력 증가 포션", 15, 50, Rarity.Rare),
            new DefendBuffPotion("하급 방어력 증가 포션", 5, 10, Rarity.Common),
            new DefendBuffPotion("중급 방어력 증가 포션", 10, 30, Rarity.Exclusive),
            new DefendBuffPotion("상급 방어력 증가 포션", 15, 50, Rarity.Rare),
            new AllBuffPotion("중급 모든 스텟 증가 포션", 10, 150, Rarity.Rare),
            new AllBuffPotion("상급 모든 스텟 증가 포션", 30, 350, Rarity.Hero),
            new AllBuffPotion("최상급 모든 스텟 증가 포션", 100, 1000, Rarity.Legend),
        };

        public static readonly ImportantItem[] ImportantItems =
        {
            new GoblinEar("고블린의 찢어진 귀", 10, Rarity.Common),
            new GoblinEye("고블린의 사슬어린 눈", 10, Rarity.Common),
        };
    }

    /// <summary>
    /// MonsterLists Class
    /// </summary>
    static class MonsterLists
    {
        public static Monster[] monsters = {
            new GoblinWarrior(new CharacterStat("Normal Goblin Warrior", 150, 10, 15, 1.6f, 1, new AttackStat(15f, 1f, 1f), new DefendStat(18f, 15f, 3f)), 20),
            new GoblinArcher(new CharacterStat("Normal Goblin Archer", 120, 30, 15, 1.6f, 1, new AttackStat(1f, 15f, 1f), new DefendStat(15f, 18f, 3f)), 20),
            new GoblinMage(new CharacterStat("Normal Goblin Mage", 100, 50, 15, 1.6f, 1, new AttackStat(1f, 1f, 15f), new DefendStat(3f, 15f, 18f)), 20),
        };
    }

    /// <summary>
    /// Manage quests
    /// </summary>
    static class QuestManager
    {
        // Methods
        /// <summary>
        /// Get Contracted Quests of collecting item
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public static IEnumerable<CollectItemQuest> GetContractedQuests_CollectItem(string itemName)
        {
            var contracted = from quest in Quests
                             where quest.IsContracted == true && quest.IsCompleted == false && quest is CollectItemQuest
                             where ((CollectItemQuest)quest).ItemName.Equals(itemName)
                             select (CollectItemQuest)quest;
            return contracted;
        }

        /// <summary>
        /// Get Contracted Quests of killing monster
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<KillMonsterQuest> GetContractedQuests_KillMonster()
        {
            var contracted = from quest in Quests
                             where quest.IsContracted == true && quest.IsCompleted == false && quest is KillMonsterQuest
                             select (KillMonsterQuest)quest;
            return contracted;
        }

        /// <summary>
        /// Get Contracted Quests
        /// </summary>
        /// <returns> IEnumerable Array of Contracted Quests </returns>
        public static IEnumerable<Quest> GetContractedQuests()
        {
            var contracted = from quest in Quests
                             where quest.IsContracted == true && quest.IsCompleted == false
                             select quest;
            return contracted;
        }

        /// <summary>
        /// Get Contractable Quests
        /// </summary>
        /// <returns> IEnumerable Array of Contractable Quests </returns>
        public static IEnumerable<Quest> GetContractableQuests()
        {
            var contractables = from quest in Quests
                                where quest.IsContracted == false && quest.IsCompleted == false
                                select quest;
            return contractables;
        }

        /// <summary>
        /// Get Completed Quests
        /// </summary>
        /// <returns> IEnumerable Array of Completed Quests </returns>
        public static IEnumerable<Quest> GetCompletedQuests()
        {
            var completed = from quest in Quests
                            where quest.IsCompleted == true && quest.IsContracted == false
                            select quest;
            return completed;
        }

        /// <summary>
        /// Get Completable Quests
        /// </summary>
        /// <returns> IEnumerable Array of Completable Quests </returns>
        public static IEnumerable<Quest> GetCompletableQuests()
        {
            var completables = from quest in Quests
                               where quest.IsCompleted == true && quest.IsContracted == true
                               select quest;
            return completables;
        }

        /// <summary>
        /// Get all quests
        /// </summary>
        /// <returns> IEnumerable Array of Quests </returns>
        public static IEnumerable<Quest> GetQuests() { return Quests; }

        public static void SetQuests(Quest[] quests)
        {
            Quests = quests;
        }

        /// <summary>
        /// Quest List
        /// </summary>
        private static Quest[] Quests =
        {
            new KillMonsterQuest("3 마리의 고블린을 사냥하세요", "큰일이야 큰일!\n| 고블린들이 마을에 나타나 습격을 하고있다네!\n| 자네의 그 용감한 힘으로 고블린들을 잡아와 주겠나?", QuestDifficulty.Easy, 3, 100,150),
            new CollectItemQuest("고블린을 사냥하여 귀 2개를 가져오세요.", typeof(GoblinEar).Name, "요즘 마을에 도는 유행병에 고블린 귀를 달여먹으면 효과가 좋다더군.\n| 시험을 위해 일단 3개만 구해다 주겠나?", QuestDifficulty.Normal, 2, 75, 100),
            new CollectItemQuest("고블린을 사냥하여 눈 2개를 가져오세요.", typeof(GoblinEye).Name, "자네... 그 소문 들었나..?\n| 포션을 만들때 고블린의 눈을 섞으면\n| 말도 안 되는 효능을 가지게 된다던데...\n| 우리같이 때돈한번 벌어보는건 어떨세?\n| 맛만보게 3개 가져와주겠나 그 뒤는 내가 알아서 하겠네~ 껄껄", QuestDifficulty.Normal, 2, 75, 100),
        };
    }

    /// <summary>
    /// Manage spawning monsters
    /// </summary>
    static class SpawnManager
    {
        // Field
        public static LinkedList<Monster> spawnedMonsters = new();

        // Public Methods
        /// <summary>
        /// Spawn monsters
        /// </summary>
        /// <param name="character"></param>
        /// <param name="groundLevel"></param>
        public static void SpawnMonsters(Character character, int groundLevel)
        {
            Random random = new();
            int count = random.Next(1, 5);
            for (int i = 0; i < count; i++)
            {
                int type = random.Next(MonsterLists.monsters.Length);

                if (MonsterLists.monsters[type].AttackType == AttackType.Close)
                {
                    GoblinWarrior monster = new((GoblinWarrior)MonsterLists.monsters[type]);
                    SetMonster(monster, character, groundLevel, 50);
                    AddMonster(monster);
                }
                else if (MonsterLists.monsters[type].AttackType == AttackType.Long)
                {
                    GoblinArcher monster = new((GoblinArcher)MonsterLists.monsters[type]);
                    SetMonster(monster, character, groundLevel, 65);
                    AddMonster(monster);
                }
                else if (MonsterLists.monsters[type].AttackType == AttackType.Magic)
                {
                    GoblinMage monster = new((GoblinMage)MonsterLists.monsters[type]);
                    SetMonster(monster, character, groundLevel, 80);
                    AddMonster(monster);
                }
            }
        }

        /// <summary>
        /// Get all spawned monsters
        /// </summary>
        /// <returns>Returns spawned monster count</returns>
        public static int GetMonsterCount() { return spawnedMonsters.Count; }

        /// <summary>
        /// Remove all spawned monsters
        /// </summary>
        public static void RemoveAllMonsters()
        {
            var monster = spawnedMonsters.First;
            while (monster != null)
            {
                var next = monster.Next;
                spawnedMonsters.Remove(monster);
                monster = next;
            }
        }

        // Private Methods
        /// <summary>
        /// Set monster's level and stats
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="character"></param>
        /// <param name="groundLevel"></param>
        /// <param name="currency"></param>
        private static void SetMonster(Monster monster, Character character, int groundLevel, int currency)
        {
            monster.Level = groundLevel;
            monster.AttackStat += new AttackStat(monster.AttackStat * (0.2f * (monster.Level - 1)));
            monster.DefendStat += new DefendStat(monster.DefendStat * (0.17f * (monster.Level - 1)));
            monster.OnDeath += () =>
            {
                RemoveMonster(character, monster, currency);
                var quests = QuestManager.GetContractedQuests_KillMonster();
                foreach (var quest in quests) { quest.OnProgress(); }
            };
        }

        /// <summary>
        /// Add monster to the linked list
        /// </summary>
        /// <param name="monster"></param>
        private static void AddMonster(Monster monster) { spawnedMonsters.AddLast(monster); }

        /// <summary>
        /// Remove monster from the linked list
        /// </summary>
        /// <param name="character"></param>
        /// <param name="monster"></param>
        /// <param name="currency"></param>
        private static void RemoveMonster(Character character, Monster monster, int currency)
        {
            Console.WriteLine($"| {monster.Name} is dead! |");
            Console.WriteLine($"| {character.Name} gets {currency}G |");
            GameManager.KilledMonsterCount++;
            character.Currency += currency;
            character.OnEarnExp(monster.Exp);

            // Randomly drop items
            int ind = new Random().Next(0, 4);
            if (ind == 0) GetRandomArmor(monster.Level)?.OnPicked(character);
            else if (ind <= 1) GetRandomWeapon(monster.Level)?.OnPicked(character);
            else if (ind <= 2) GetRandomConsumable(monster.Level)?.OnPicked(character);
            else GetRandomImportantItem()?.OnPicked(character);
            spawnedMonsters.Remove(monster);
        }

        // Return random items
        private static Armor? GetRandomArmor(int level)
        {
            if (new Random().Next(1, 101) % 2 != 0) return null;

            IEnumerable<Armor> filteredItems;
            if (level > 0 && level <= 15)
            {
                filteredItems = from item in ItemLists.Armors
                                where item.Rarity == Rarity.Common || item.Rarity == Rarity.Exclusive
                                select item;
            }
            else if (level > 15 && level <= 30)
            {
                filteredItems = from item in ItemLists.Armors
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare
                                select item;
            }
            else if (level > 30 && level <= 50)
            {
                filteredItems = from item in ItemLists.Armors
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare || item.Rarity == Rarity.Hero
                                select item;
            }
            else
            {
                filteredItems = from item in ItemLists.Armors
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare || item.Rarity == Rarity.Hero || item.Rarity == Rarity.Legend
                                select item;
            }
            int ind = new Random().Next(filteredItems.Count());
            return filteredItems.ElementAt(ind);
        }
        private static Weapon? GetRandomWeapon(int level)
        {
            if (new Random().Next(1, 101) % 2 != 0) return null;
            IEnumerable<Weapon> filteredItems;
            if (level > 0 && level <= 15)
            {
                filteredItems = from item in ItemLists.Weapons
                                where item.Rarity == Rarity.Common || item.Rarity == Rarity.Exclusive
                                select item;
            }
            else if (level > 15 && level <= 30)
            {
                filteredItems = from item in ItemLists.Weapons
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare
                                select item;
            }
            else if (level > 30 && level <= 50)
            {
                filteredItems = from item in ItemLists.Weapons
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare || item.Rarity == Rarity.Hero
                                select item;
            }
            else
            {
                filteredItems = from item in ItemLists.Weapons
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare || item.Rarity == Rarity.Hero || item.Rarity == Rarity.Legend
                                select item;
            }
            int ind = new Random().Next(filteredItems.Count());
            return filteredItems.ElementAt(ind);
        }
        private static Consumables? GetRandomConsumable(int level)
        {
            if (new Random().Next(1, 101) % 2 != 0) return null;

            IEnumerable<Consumables> filteredItems;
            if (level > 0 && level <= 15)
            {
                filteredItems = from item in ItemLists.Consumables
                                where item.Rarity == Rarity.Common || item.Rarity == Rarity.Exclusive
                                select item;
            }
            else if (level > 15 && level <= 30)
            {
                filteredItems = from item in ItemLists.Consumables
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare
                                select item;
            }
            else if (level > 30 && level <= 50)
            {
                filteredItems = from item in ItemLists.Consumables
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare || item.Rarity == Rarity.Hero
                                select item;
            }
            else
            {
                filteredItems = from item in ItemLists.Consumables
                                where item.Rarity == Rarity.Exclusive || item.Rarity == Rarity.Rare || item.Rarity == Rarity.Hero || item.Rarity == Rarity.Legend
                                select item;
            }
            int ind = new Random().Next(filteredItems.Count());
            return filteredItems.ElementAt(ind);
        }
        private static ImportantItem? GetRandomImportantItem()
        {
            if (new Random().Next(1, 101) % 2 != 0) return null;

            var filteredItems = from item in ItemLists.ImportantItems
                                where item.Rarity == Rarity.Common
                                select item;
            int ind = new Random().Next(filteredItems.Count());
            return filteredItems.ElementAt(ind);
        }
    }

    /// <summary>
    /// Manage controls of overall game statements and functions
    /// </summary>
    static class GameManager
    {
        // Static Field
        public static GameState GameState = GameState.MainMenu;
        public static GameTime GameTime = GameTime.Afternoon;
        public static int KilledMonsterCount = 0;
        public static int CurrentTurn = 1;
        public static int PrevPath = 0;
        public static bool IsPathSelected = false;
        public static Queue<Consumables> Exposables = new();
        public static Character SelectedCharacter;
        public static int GroundLevel { get; private set; } = 1;
        public static int Quota { get; private set; } = 10;

        // Methods
        #region Game Mechanisms
        /// <summary>
        /// Job Selection UI will be displayed.
        /// This method will return true if the job selected successfully.
        /// If not, it will return false.
        /// </summary>
        /// <returns>Returns true, if job selected successfully. If not, returns false.</returns>
        public static void SelectJob()
        {
            int option;
            while (true)
            {
                UIManager.JobSelectionUI();
                if (!int.TryParse(Console.ReadLine(), out int opt)) { Console.WriteLine("| 잘못된 입력입니다! |"); }
                else if (opt < 0 || Enum.GetValues(typeof(Job)).Length < opt) { Console.WriteLine("| 잘못된 입력입니다! |"); }
                else { option = Math.Clamp(opt, 0, Enum.GetValues(typeof(Job)).Length); break; }
                Console.Write("\nPress enter to continue..."); Console.ReadLine();
            }

            if (option <= 0) return;

            string name;
            switch ((Job)(option - 1))
            {
                case Job.Warrior:
                    Console.WriteLine("| 전사를 선택하였습니다! |");
                    Console.Write("전사의 이름을 작성해주세요 : ");
                    name = Console.ReadLine() ?? "Jake"; if (name.Length < 1) name = "Jake";
                    SelectedCharacter = new Warrior(new CharacterStat(name, 150, 50, 15, 1.6f, 1, new AttackStat(25f, 10f, 8f), new DefendStat(25, 15, 5)), 250, 0);
                    break;
                case Job.Wizard:
                    Console.WriteLine("| 법사를 선택하였습니다! |");
                    Console.Write("법사의 이름을 작성해주세요 : ");
                    name = Console.ReadLine() ?? "Lucy"; if (name.Length < 1) name = "Lucy";
                    SelectedCharacter = new Wizard(new CharacterStat(name, 100, 80, 15, 1.6f, 1, new AttackStat(8f, 10f, 25f), new DefendStat(5, 10, 30)), 250, 0);
                    break;
                case Job.Archer:
                    Console.WriteLine("| 궁수를 선택하였습니다! |");
                    Console.Write("궁수의 이름을 작성해주세요 : ");
                    name = Console.ReadLine() ?? "Omen"; if (name.Length < 1) name = "Omen";
                    SelectedCharacter = new Archer(new CharacterStat(name, 120, 65, 15, 1.6f, 1, new AttackStat(10f, 25f, 8f), new DefendStat(15, 25, 5)), 250, 0);
                    break;
            }

            GiveBasicItems(SelectedCharacter);
            GiveBasicSkills(SelectedCharacter);
            SelectedCharacter.OnDeath += GameOver;

            GameState = GameState.Town;
        }

        /// <summary>
        /// Give basic items to the character.
        /// </summary>
        /// <param name="character"></param>
        private static void GiveBasicItems(Character character)
        {
            // LINQ
            var basicHelmets = from armor in ItemLists.Armors
                               where armor is Helmet && armor.Rarity == Rarity.Common
                               select (Helmet)armor;
            var basicChestArmors = from armor in ItemLists.Armors
                                   where armor is ChestArmor && armor.Rarity == Rarity.Common
                                   select (ChestArmor)armor;

            var basicHealthPotions = from item in ItemLists.Consumables
                                     where item is HealthPotion && item.Rarity == Rarity.Common
                                     select (HealthPotion)item;
            var basicMagicPotions = from item in ItemLists.Consumables
                                    where item is MagicPotion && item.Rarity == Rarity.Common
                                    select (MagicPotion)item;

            if (basicHelmets.Any()) { character.Armors.Add(new Helmet(basicHelmets.First())); }
            if (basicChestArmors.Any()) { character.Armors.Add(new ChestArmor(basicChestArmors.First())); }
            if (basicHealthPotions.Any()) { character.Consumables.Add(new HealthPotion(basicHealthPotions.First())); }
            if (basicMagicPotions.Any()) { character.Consumables.Add(new MagicPotion(basicMagicPotions.First())); }

            if (character is Warrior)
            {
                var basicSwords = from sword in ItemLists.Weapons
                                  where sword is Sword && sword.Rarity == Rarity.Common
                                  select (Sword)sword;
                if (basicSwords.Any()) { character.Weapons.Add(new Sword(basicSwords.First())); }
            }
            else if (character is Wizard)
            {
                var basicStaffs = from staff in ItemLists.Weapons
                                  where staff is Staff && staff.Rarity == Rarity.Common
                                  select (Staff)staff;
                if (basicStaffs.Any()) { character.Weapons.Add(new Staff(basicStaffs.First())); }
            }
            else
            {
                var basicBows = from bow in ItemLists.Weapons
                                where bow is Bow && bow.Rarity == Rarity.Common
                                select (Bow)bow;
                if (basicBows.Any()) { character.Weapons.Add(new Bow(basicBows.First())); }
            }
        }

        /// <summary>
        /// Give basic skills to the character.
        /// </summary>
        /// <param name="character"></param>
        private static void GiveBasicSkills(Character character)
        {
            // Active Skills
            if (character is Warrior)
                character.Skills.Add(new ActiveSkill((ActiveSkill)SkillLists.ActiveSkills[0]));
            else if (character is Archer)
                character.Skills.Add(new ActiveSkill((ActiveSkill)SkillLists.ActiveSkills[1]));
            else character.Skills.Add(new ActiveSkill((ActiveSkill)SkillLists.ActiveSkills[2]));

            // Buff Skills
            character.Skills.Add(new BuffSkill((BuffSkill)SkillLists.BuffSkills[0]));
        }

        /// <summary>
        /// Change to GameOver state.
        /// </summary>
        private static void GameOver()
        {
            GameState = GameState.GameOver;
        }

        /// <summary>
        /// Actions when game is over.
        /// </summary>
        /// <param name="spawnManager"></param>
        public static void GameOverAction()
        {
            // Display Game Over UI
            UIManager.GameOverUI();

            // Remove all monsters
            SpawnManager.RemoveAllMonsters();

            // Low currency -> Reset game and move to main menu
            if (SelectedCharacter.Currency < 100)
            {
                UIManager.ReviveOptionUI(SelectedCharacter);
                ResetGame();
                return;
            }

            // Enough currency -> Give player option to revive
            while (true)
            {
                UIManager.ReviveOptionUI(SelectedCharacter);
                string key = Console.ReadLine();
                if (key.Equals("y", StringComparison.OrdinalIgnoreCase)) { break; }
                else if (key.Equals("n", StringComparison.OrdinalIgnoreCase)) { ResetGame(); return; }
                else { Console.WriteLine("| 잘못된 입력입니다! |"); continue; }
            }

            // If player choose to revive, revive the character and move to town
            SelectedCharacter.OnRevive();
            GameState = GameState.Town;
            GameTime = GameTime.Afternoon;
        }

        /// <summary>
        /// Reset the game to initial state.
        /// </summary>
        public static void ResetGame()
        {
            GameState = GameState.MainMenu;
            GameTime = GameTime.Afternoon;

            foreach (var quest in QuestManager.GetQuests())
                if (quest is ICancelable cancelableQuest) cancelableQuest.OnCanceled();
            Exposables.Clear();
            KilledMonsterCount = 0;
            GroundLevel = 1;
            Quota = 10;
        }

        /// <summary>
        /// Remove all buffs applied to character when night passed.
        /// </summary>
        public static void RemoveAllBuffs()
        {
            if (Exposables.Count <= 0) return;

            while (Exposables.Count > 0)
            {
                Consumables consumable = Exposables.Dequeue();
                if (consumable == null) continue;

                consumable.OnDeBuffed(SelectedCharacter);
            }
            Console.WriteLine("| 하루가 지나 모든 버프가 해제되었습니다... |");
        }

        /// <summary>
        /// Increase Dungeon level when character reached the quota.
        /// </summary>
        public static void GoToNextLevel()
        {
            Console.WriteLine("| 목표량을 달성하였습니다, 던전 레벨과 목표량이 올라갑니다! |");
            KilledMonsterCount = 0;
            Quota = 10 + (++GroundLevel - 1) * 5;
        }
        #endregion

        #region Save & Load Functions
        /// <summary>
        /// Save the character and game data to JSON files.
        /// </summary>
        public static void SaveGame()
        {
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");

            // Saving Character Data
            var characterOptions = new JsonSerializerOptions
            {
                Converters = {
                    new CharacterConverter(), new ArmorConverter(),
                    new WeaponConverter(), new ConsumableConverter(),
                    new ImportantItemConverter(), new SkillConverter(),
                    new EquippedArmorConverter(),
                },
                WriteIndented = true
            };

            string characterJson = JsonSerializer.Serialize(SelectedCharacter, characterOptions);
            File.WriteAllText("data/character.json", characterJson, new UTF8Encoding(true));

            // Saving Game Data
            var gameData = new GameData
            {
                GroundLevel = GroundLevel,
                Quota = Quota,
                KilledMonsterCount = KilledMonsterCount,
                GameState = GameState,
                GameTime = GameTime,
                Exposables = Exposables.ToList()
            };

            var gameOptions = new JsonSerializerOptions
            {
                Converters = {
                    new ConsumableConverter(),
                },
                WriteIndented = true
            };
            string gameJson = JsonSerializer.Serialize(gameData, gameOptions);
            File.WriteAllText("data/game.json", gameJson, new UTF8Encoding(true));

            //Saving Quest Data
            var questOptions = new JsonSerializerOptions
            {
                Converters = {
                     new QuestConverter(), new QuestListConverter(),
                },
                WriteIndented = true
            };

            string questJson = JsonSerializer.Serialize(QuestManager.GetQuests(), questOptions);
            File.WriteAllText("data/quest.json", questJson, new UTF8Encoding(true));

            Console.WriteLine("| 게임이 성공적으로 저장되었습니다! |");
        }

        /// <summary>
        /// Load the character and game data from JSON files.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void LoadGame()
        {
            if (!File.Exists("data/character.json") || !File.Exists("data/game.json") || !File.Exists("data/quest.json"))
            {
                Console.WriteLine("| 저장된 세이브 데이터가 없습니다! |");
                Console.Write("\nPress enter to continue..."); Console.ReadLine();
                return;
            }

            // Loading Character Data
            var options = new JsonSerializerOptions
            {
                Converters = {
                    new CharacterConverter(), new ArmorConverter(),
                    new WeaponConverter(), new ConsumableConverter(),
                    new ImportantItemConverter(), new SkillConverter(),
                    new EquippedArmorConverter(),
                },
                WriteIndented = true
            };
            string characterJson = File.ReadAllText("data/character.json", Encoding.UTF8);
            var obj = JsonSerializer.Deserialize<Character>(characterJson, options);
            SelectedCharacter = obj ?? throw new InvalidOperationException("Failed to load character data.");
            SelectedCharacter.OnDeath += GameOver;
            foreach (var armor in SelectedCharacter.Armors)
                if (armor.IsEquipped) SelectedCharacter.EquippedArmor[(int)(armor.ArmorPosition)] = armor;
            foreach (var weapon in SelectedCharacter.Weapons)
                if (weapon.IsEquipped) SelectedCharacter.EquippedWeapon = weapon;

            // Loading Game Data
            var gameOptions = new JsonSerializerOptions
            {
                Converters = {
                    new ConsumableConverter(),
                },
                WriteIndented = true
            };
            string gameJson = File.ReadAllText("data/game.json", Encoding.UTF8);
            var gameData = JsonSerializer.Deserialize<GameData>(gameJson, gameOptions) ?? throw new InvalidOperationException("Failed to load game data.");
            SetGameData(gameData);

            // Loading Quest Data
            var questOptions = new JsonSerializerOptions
            {
                Converters = {
                    new QuestConverter(), new QuestListConverter(),
                },
                WriteIndented = true
            };
            string questJson = File.ReadAllText("data/quest.json", Encoding.UTF8);
            var quests = JsonSerializer.Deserialize<Quest[]>(questJson, questOptions) ?? throw new InvalidOperationException("Failed to load quest data.");
            QuestManager.SetQuests(quests);

            Console.WriteLine("| 게임을 성공적으로 불러왔습니다! |");
        }

        /// <summary>
        /// Set GameManager data from GameData.
        /// </summary>
        /// <param name="gameData"></param>
        private static void SetGameData(GameData gameData)
        {
            GroundLevel = gameData.GroundLevel;
            Quota = gameData.Quota;
            KilledMonsterCount = gameData.KilledMonsterCount;
            GameState = gameData.GameState;
            GameTime = gameData.GameTime;
            Exposables = new Queue<Consumables>(gameData.Exposables);
        }
        #endregion
    }

    /// <summary>
    /// Mercenaries -> Purchasable Characters
    /// </summary>
    static class MercenaryManager
    {
        // Field
        private static LinkedList<Character> MercenaryList = new LinkedList<Character>();

        // Methods
        
        /// <summary>
        /// Get all mercenaries added to the list
        /// </summary>
        /// <returns>List of Added mercenaries</returns>
        public static LinkedList<Character> GetMercenaries() { return MercenaryList; }
        /// <summary>
        /// Add mercenary to the list
        /// </summary>
        /// <param name="mercenary"></param>
        public static void AddMercenary(Character mercenary) { MercenaryList.AddLast(mercenary); }

        /// <summary>
        /// Remove mercenary from the list
        /// </summary>
        /// <param name="mercenary"></param>
        public static void RemoveMercenary(Character mercenary) { MercenaryList.Remove(mercenary); }

        /// <summary>
        /// Remove all mercenaries
        /// </summary>
        public static void RemoveAllMercenaries() { MercenaryList.Clear(); }

        /// <summary>
        /// Generates Random Mercenaries
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<Character> GenerateRandomMercenaries(int count)
        {
            var mercenaries = new List<Character>();
            for (int i = 0; i < count; i++)
            {
                var mercenary = GenerateRandomMercenary();
                GiveRandomWeapon(mercenary);
                mercenary.OnDeath += () => { Console.WriteLine($"| {mercenary.Name}이 죽었습니다!"); RemoveMercenary(mercenary); };
                mercenaries.Add(mercenary);
            }
            return mercenaries;
        }

        /// <summary>
        /// Give Random Weapon to the mercenary
        /// </summary>
        /// <param name="mercenary"></param>
        private static void GiveRandomWeapon(Character mercenary)
        {
            var random = new Random();
            List<Weapon> weapons = new();
            if(mercenary is Warrior)
            {
                weapons = ItemLists.Weapons.Where(w => w is Sword && (mercenary.Level < 10 ? w.Rarity == Rarity.Common : 
                (mercenary.Level < 20 ? w.Rarity == Rarity.Common : 
                (mercenary.Level < 40 ? w.Rarity == Rarity.Rare : 
                (mercenary.Level < 60 ? w.Rarity == Rarity.Hero :
                w.Rarity == Rarity.Legend))))).ToList();
            } else if(mercenary is Archer)
            {
                weapons = ItemLists.Weapons.Where(w => w is Bow && (mercenary.Level < 10 ? w.Rarity == Rarity.Common :
                (mercenary.Level < 20 ? w.Rarity == Rarity.Common :
                (mercenary.Level < 40 ? w.Rarity == Rarity.Rare :
                (mercenary.Level < 60 ? w.Rarity == Rarity.Hero :
                w.Rarity == Rarity.Legend))))).ToList();
            } else if(mercenary is Wizard)
            {
                weapons = ItemLists.Weapons.Where(w => w is Staff && (mercenary.Level < 10 ? w.Rarity == Rarity.Common :
                (mercenary.Level < 20 ? w.Rarity == Rarity.Common :
                (mercenary.Level < 40 ? w.Rarity == Rarity.Rare :
                (mercenary.Level < 60 ? w.Rarity == Rarity.Hero :
                w.Rarity == Rarity.Legend))))).ToList();
            }
            if (!weapons.Any()) return;
            mercenary.Weapons.Add(weapons.First());
            mercenary.Weapons.First().OnEquip(mercenary);
        }

        /// <summary>
        /// Generate Random Mercenary
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static Character GenerateRandomMercenary()
        {
            var random = new Random();
            var names = new[] { "John", "Jane", "Bob", "Alice", "Mike", "Sara" };
            var name = names[random.Next(names.Length)];
            var level = GameManager.SelectedCharacter.Level;
            var maxHealth = random.Next(120, 150) + (level - 1) * 15;
            var maxMagicPoint = random.Next(50, 80) + (level - 1) * 10;
            var characterType = (Job)random.Next(0, 3);
            

            AttackStat? atkStat = null; DefendStat? defStat = null;
            if (characterType == Job.Warrior)
            {
                atkStat = new AttackStat(random.Next(18, 31), random.Next(10, 14), random.Next(1, 8));
                atkStat += level;
                defStat = new DefendStat(random.Next(20, 26), random.Next(10, 15), random.Next(1, 10));
                defStat += level;
            }
            else if (characterType == Job.Wizard)
            {
                atkStat = new AttackStat(random.Next(8, 12), random.Next(18, 31), random.Next(5, 10));
                atkStat += level;
                defStat = new DefendStat(random.Next(8, 12), random.Next(20, 26), random.Next(5, 12));
                defStat += level;
            }
            else if (characterType == Job.Archer)
            {
                atkStat = new AttackStat(random.Next(4, 10), random.Next(8, 12), random.Next(18, 31));
                atkStat += level;
                defStat = new DefendStat(random.Next(5, 12), random.Next(8, 12), random.Next(20, 26));
                defStat += level;
            }
            var price = random.Next(120, 180);

            return characterType switch
            {
                Job.Warrior => new Warrior(new CharacterStat(name, maxHealth, maxHealth, maxMagicPoint, maxMagicPoint, 10, 1.5f, level, atkStat ?? new AttackStat(1, 1, 1), defStat ?? new DefendStat(1, 1, 1)), price, 0),
                Job.Wizard => new Wizard(new CharacterStat(name, maxHealth, maxHealth, maxMagicPoint, maxMagicPoint, 10, 1.5f, level, atkStat ?? new AttackStat(1, 1, 1), defStat ?? new DefendStat(1, 1, 1)), price, 0),
                Job.Archer => new Archer(new CharacterStat(name, maxHealth, maxHealth, maxMagicPoint, maxMagicPoint, 10, 1.5f, level, atkStat ?? new AttackStat(1, 1, 1), defStat ?? new DefendStat(1, 1, 1)), price, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(characterType), characterType, null)
            };
        }
    }
}
