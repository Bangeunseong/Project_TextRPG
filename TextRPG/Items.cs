using System.Text;
using System.Text.Json.Serialization;

namespace TextRPG
{
    /// <summary>
    /// Stat. of Attack
    /// </summary>
    public class AttackStat
    {
        // Field
        private float attack;
        private float rangeAttack;
        private float magicAttack;

        // Property
        public float Attack { get { return attack; } set { attack = Math.Max(0, value); } }
        public float RangeAttack { get { return rangeAttack; } set { rangeAttack = Math.Max(0, value); } }
        public float MagicAttack { get { return magicAttack; } set { magicAttack = Math.Max(0, value); } }

        public AttackStat() { Attack = 0; RangeAttack = 0; MagicAttack = 0; }
        public AttackStat(float attack, float rangeAttack, float magicAttack)
        {
            this.attack = attack;
            this.rangeAttack = rangeAttack;
            this.magicAttack = magicAttack;
        }
        public AttackStat(AttackStat attackStat)
        {
            attack = attackStat.Attack;
            rangeAttack = attackStat.RangeAttack;
            magicAttack = attackStat.MagicAttack;
        }

        public static AttackStat operator +(AttackStat stat, float coef)
        {
            return new AttackStat(stat.Attack + coef, stat.RangeAttack + coef, stat.MagicAttack + coef);
        }

        public static AttackStat operator +(AttackStat stat1, AttackStat stat2)
        {
            return new AttackStat(stat1.Attack + stat2.Attack, stat1.RangeAttack + stat2.RangeAttack, stat1.MagicAttack + stat2.MagicAttack);
        }

        public static AttackStat operator -(AttackStat stat1, AttackStat stat2)
        {
            return new AttackStat(stat1.Attack - stat2.Attack, stat1.RangeAttack - stat2.RangeAttack, stat1.MagicAttack - stat2.MagicAttack);
        }

        public static AttackStat operator *(AttackStat stat, float coef)
        {
            return new AttackStat(stat.Attack * coef, stat.RangeAttack * coef, stat.MagicAttack * coef);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"Atk : {Attack}, ").Append($"Rng Atk : {RangeAttack}, ").Append($"Mag Atk : {MagicAttack}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Stat. of Defend
    /// </summary>
    public class DefendStat
    {
        // Field
        private float defend;
        private float rangeDefend;
        private float magicDefend;

        // Property
        public float Defend { get { return defend; } set { defend = Math.Max(0, value); } }
        public float RangeDefend { get { return rangeDefend; } set { rangeDefend = Math.Max(0, value); } }
        public float MagicDefend { get { return magicDefend; } set { magicDefend = Math.Max(0, value); } }

        public DefendStat() { defend = 0; rangeDefend = 0; magicDefend = 0; }
        public DefendStat(float defend, float rangeDefend, float magicDefend)
        {
            this.defend = defend;
            this.rangeDefend = rangeDefend;
            this.magicDefend = magicDefend;
        }
        public DefendStat(DefendStat defendStat)
        {
            defend = defendStat.Defend;
            rangeDefend = defendStat.RangeDefend;
            magicDefend = defendStat.MagicDefend;
        }

        public static DefendStat operator +(DefendStat stat, float coef)
        {
            return new DefendStat(stat.Defend + coef, stat.RangeDefend + coef, stat.MagicDefend + coef);
        }

        public static DefendStat operator +(DefendStat stat1, DefendStat stat2)
        {
            return new DefendStat(stat1.Defend + stat2.Defend, stat1.RangeDefend + stat2.RangeDefend, stat1.MagicDefend + stat2.MagicDefend);
        }

        public static DefendStat operator -(DefendStat stat1, DefendStat stat2)
        {
            return new DefendStat(stat1.Defend - stat2.Defend, stat1.RangeDefend - stat2.RangeDefend, stat1.MagicDefend - stat2.MagicDefend);
        }

        public static DefendStat operator *(DefendStat stat, float coef)
        {
            return new DefendStat(stat.Defend * coef, stat.RangeDefend * coef, stat.MagicDefend * coef);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"Def : {Defend}, ").Append($"Rng Def : {RangeDefend}, ").Append($"Mag Def : {MagicDefend}");
            return sb.ToString();
        }
    }

    #region Armor Class
    /// <summary>
    /// Base Armor Class
    /// </summary>
    abstract class Armor : IPurchasable, ISellable, IWearable, IPickable
    {
        // Field
        private string name;
        private Rarity rarity;
        private DefendStat defendStat;
        private bool isEquipped;
        private int price;

        // Property
        public string Name { get { return name; } protected set { name = value; } }
        public DefendStat DefendStat { get { return defendStat; } protected set { defendStat = value; } }
        public Rarity Rarity { get { return rarity; } protected set { rarity = value; } }
        public ArmorPosition ArmorPosition { get; protected set; }
        public ItemCategory Category { get; protected set; } = ItemCategory.Armor;
        public int Price { get { return price; } protected set { price = value; } }
        public bool IsEquipped { get { return isEquipped; } set { isEquipped = value; } }

        // Constructor
        public Armor(string name = "Unknown", DefendStat? defendStat = null, int price = 0, Rarity rarity = Rarity.Common)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
            if (defendStat != null)
            {
                if ((int)rarity > (int)Rarity.Rare)
                {
                    DefendStat newStat = new(
                        defendStat.Defend + defendStat.Defend * ((int)rarity - (int)Rarity.Rare) * 0.05f,
                        defendStat.RangeDefend + defendStat.RangeDefend * ((int)rarity - (int)Rarity.Rare) * 0.05f,
                        defendStat.MagicDefend + defendStat.MagicDefend * ((int)rarity - (int)Rarity.Rare) * 0.05f
                    );
                    this.defendStat = newStat;
                }
                else this.defendStat = new(defendStat);
            }
            else this.defendStat = new(1, 1, 1);
        }

        // Methods
        /// <summary>
        /// Calls when the armor is equipped
        /// </summary>
        /// <param name="character"></param>
        public void OnEquip(Character character)
        {
            if (IsEquipped) { Console.WriteLine($"| {Name} is already equipped! |"); return; }
            if (character.EquippedArmor[(int)(ArmorPosition)] != null) { character.EquippedArmor[(int)(ArmorPosition)]?.OnUnequip(character); }
            character.EquippedArmor[(int)(ArmorPosition)] = this;
            IsEquipped = true;
            Console.WriteLine($"| {name} equipped! |");
        }

        /// <summary>
        /// Calls when the armor is unequipped
        /// </summary>
        /// <param name="character"></param>
        public void OnUnequip(Character character)
        {
            if (!IsEquipped) { Console.WriteLine($"| {Name} is not equipped! |"); return; }
            character.EquippedArmor[(int)ArmorPosition] = null;
            IsEquipped = false;
            Console.WriteLine($"| {name} unequipped! |");
        }

        /// <summary>
        /// Calls when the armor is purchased
        /// </summary>
        /// <param name="character"></param>
        public virtual void OnPurchase(Character character)
        {
            if (character.Currency < Price) { Console.WriteLine("| Not enough Money! |"); return; }
            Console.WriteLine($"| {name}을 구매하였습니다! |");
        }

        /// <summary>
        /// Calls when the armor is sold
        /// </summary>
        /// <param name="character"></param>
        public void OnSell(Character character)
        {
            if (IsEquipped) { Console.WriteLine($"| Not possible to sell!, {Name} is equipped! |"); return; }
            character.Currency += Price;
            character.Armors.Remove(this);
            Console.WriteLine($"| {Name} is sold! |");
        }

        /// <summary>
        /// Calls when the armor is picked
        /// </summary>
        /// <param name="character"></param>
        public virtual void OnPicked(Character character)
        {
            Console.WriteLine($"| Picked {name}! |");
        }

        /// <summary>
        /// Calls when the armor is dropped
        /// </summary>
        /// <param name="character"></param>
        public void OnDropped(Character character)
        {
            if (IsEquipped) { Console.WriteLine($"| Not possible to drop!, {Name} is equipped! |"); return; }
            character.Armors.Remove(this);
            Console.WriteLine($"| Dropped {name}! |");
        }

        /// <summary>
        /// Describe the armor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            if (IsEquipped == true) sb.Append("[E]"); else sb.Append("[ ]");
            sb.Append($"{Name} | Def. : {DefendStat.Defend:F2}, ")
              .Append($"RDef. : {DefendStat.RangeDefend:F2}, ")
              .Append($"MDef. : {DefendStat.MagicDefend:F2} | ")
              .Append($"가격 : {Price} | {Rarity}");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if(obj is Armor armor) return Name == armor.Name;
            return false;
        }
    }
    /// <summary>
    /// Helmet
    /// </summary>
    class Helmet : Armor
    {
        // Constructor
        public Helmet(string name, DefendStat defendStat, int price, Rarity rarity) : base(name, defendStat, price, rarity)
        {
            ArmorPosition = ArmorPosition.Head;
        }
        public Helmet(Helmet helmet) : base(helmet.Name, helmet.DefendStat, helmet.Price, helmet.Rarity)
        {
            ArmorPosition = helmet.ArmorPosition;
        }

        [JsonConstructor]
        public Helmet(string name, DefendStat defendStat, int price, Rarity rarity, 
                      ArmorPosition armorPosition, ItemCategory category, bool isEquipped)
            : base(name, defendStat, price, rarity)
        {
            ArmorPosition = armorPosition;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the armor is purchased, adds the armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price){ return; }
            character.Currency -= Price;
            character.Armors.Add(new Helmet(this));
        }

        /// <summary>
        /// Calls when the armor is picked, adds the armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Armors.Add(new Helmet(this));
        }
    }
    /// <summary>
    /// Chest
    /// </summary>
    class ChestArmor : Armor
    {
        // Constructor
        public ChestArmor(string name, DefendStat defendStat, int price, Rarity rarity) : base(name, defendStat, price, rarity)
        {
            ArmorPosition = ArmorPosition.Torso;
        }
        public ChestArmor(ChestArmor chestArmor) : base(chestArmor.Name, chestArmor.DefendStat, chestArmor.Price, chestArmor.Rarity)
        {
            ArmorPosition = ArmorPosition.Torso;
        }

        [JsonConstructor]
        public ChestArmor(string name, DefendStat defendStat, int price, Rarity rarity, 
                          ArmorPosition armorPosition, ItemCategory category, bool isEquipped)
            : base(name, defendStat, price, rarity)
        {
            ArmorPosition = armorPosition;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the armor is purchased, adds the chest armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Armors.Add(new ChestArmor(this));
        }

        /// <summary>
        /// Calls when the armor is picked, adds the chest armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Armors.Add(new ChestArmor(this));
        }
    }
    /// <summary>
    /// Leg
    /// </summary>
    class LegArmor : Armor
    {
        // Constructor
        public LegArmor(string name, DefendStat defendStat, int price, Rarity rarity) : base(name, defendStat, price, rarity)
        {
            ArmorPosition = ArmorPosition.Leg;
        }
        public LegArmor(LegArmor legArmor) : base(legArmor.Name, legArmor.DefendStat, legArmor.Price, legArmor.Rarity)
        {
            ArmorPosition = ArmorPosition.Leg;
        }

        [JsonConstructor]
        public LegArmor(string name, DefendStat defendStat, int price, Rarity rarity, ArmorPosition armorPosition, ItemCategory category, bool isEquipped)
            : base(name, defendStat, price, rarity)
        {
            ArmorPosition = armorPosition;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the armor is purchased, adds the leg armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Armors.Add(new LegArmor(this));
        }

        /// <summary>
        /// Calls when the armor is picked, adds the leg armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Armors.Add(new LegArmor(this));
        }
    }
    /// <summary>
    /// Foot
    /// </summary>
    class FootArmor : Armor
    {
        // Constructor
        public FootArmor(string name, DefendStat defendStat, int price, Rarity rarity) : base(name, defendStat, price, rarity)
        {
            ArmorPosition = ArmorPosition.Foot;
        }
        public FootArmor(FootArmor footArmor) : base(footArmor.Name, footArmor.DefendStat, footArmor.Price, footArmor.Rarity)
        {
            ArmorPosition = ArmorPosition.Foot;
        }

        [JsonConstructor]
        public FootArmor(string name, DefendStat defendStat, int price, Rarity rarity, 
                         ArmorPosition armorPosition, ItemCategory category, bool isEquipped)
            : base(name, defendStat, price, rarity)
        {
            ArmorPosition = armorPosition;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the armor is purchased, adds the foot armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Armors.Add(new FootArmor(this));
        }

        /// <summary>
        /// Calls when the armor is picked, adds the foot armor to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Armors.Add(new FootArmor(this));
        }
    }
    /// <summary>
    /// Arm
    /// </summary>
    class Gauntlet : Armor
    {
        // Constructor
        public Gauntlet(string name, DefendStat defendStat, int price, Rarity rarity) : base(name, defendStat, price, rarity)
        {
            ArmorPosition = ArmorPosition.Arm;
        }
        public Gauntlet(Gauntlet guntlet) : base(guntlet.Name, guntlet.DefendStat, guntlet.Price, guntlet.Rarity)
        {
            ArmorPosition = ArmorPosition.Arm;
        }

        [JsonConstructor]
        public Gauntlet(string name, DefendStat defendStat, int price, Rarity rarity, 
                        ArmorPosition armorPosition, ItemCategory category, bool isEquipped)
            : base(name, defendStat, price, rarity)
        {
            ArmorPosition = armorPosition;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the armor is purchased, adds the gauntlet to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Armors.Add(new Gauntlet(this));
        }

        /// <summary>
        /// Calls when the armor is picked, adds the gauntlet to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Armors.Add(new Gauntlet(this));
        }
    }
    #endregion

    #region Weapon Class
    /// <summary>
    /// Base Weapon Class
    /// </summary>
    abstract class Weapon : IPurchasable, ISellable, IWearable, IPickable
    {
        // Field
        private string name;
        private Rarity rarity;
        private AttackStat attackStat;
        private bool isEquipped;
        private int price;

        // Property
        public string Name { get { return name; } protected set { name = value; } }
        public AttackStat AttackStat { get { return attackStat; } protected set { attackStat = value; } }
        public Rarity Rarity { get { return rarity; } protected set { rarity = value; } }
        public ItemCategory Category { get; protected set; } = ItemCategory.Weapon;
        public AttackType AttackType { get; protected set; }
        public int Price { get { return price; } protected set { price = value; } }
        public bool IsEquipped { get { return isEquipped; } set { isEquipped = value; } }

        public Weapon(string name, AttackStat attackStat, int price, Rarity rarity)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
            if (attackStat != null)
            {
                if ((int)rarity > (int)Rarity.Rare)
                {
                    AttackStat newStat = new()
                    {
                        Attack = attackStat.Attack + attackStat.Attack * ((int)rarity - (int)Rarity.Rare) * 0.05f,
                        RangeAttack = attackStat.RangeAttack + attackStat.RangeAttack * ((int)rarity - (int)Rarity.Rare) * 0.05f,
                        MagicAttack = attackStat.MagicAttack + attackStat.MagicAttack * ((int)rarity - (int)Rarity.Rare) * 0.05f
                    };
                    this.attackStat = newStat;
                }
                else this.attackStat = new(attackStat);
            }
            else this.attackStat = new(1, 1, 1);
        }

        /// <summary>
        /// Calls when the weapon is equipped
        /// </summary>
        /// <param name="character"></param>
        public void OnEquip(Character character)
        {
            if (IsEquipped) { Console.WriteLine($"| {Name} is already equipped! |"); return; }
            if (character.EquippedWeapon != null) { character.EquippedWeapon?.OnUnequip(character); }
            character.EquippedWeapon = this;
            IsEquipped = true;
            Console.WriteLine($"| {name} equipped! |");
        }

        /// <summary>
        /// Calls when the weapon is unequipped
        /// </summary>
        /// <param name="character"></param>
        public void OnUnequip(Character character)
        {
            if (!IsEquipped) { Console.WriteLine($"| {Name} is not equipped! |"); return; }
            character.EquippedWeapon = null;
            IsEquipped = false;
            Console.WriteLine($"| {name} unequipped! |");
        }

        /// <summary>
        /// Calls when the weapon is purchased
        /// </summary>
        /// <param name="character"></param>
        public virtual void OnPurchase(Character character)
        {
            if (character.Currency < Price) { Console.WriteLine("| Not enough Money! |"); return; }
            Console.WriteLine($"| {name} is purchased |");
        }

        /// <summary>
        /// Calls when the weapon is sold
        /// </summary>
        /// <param name="character"></param>
        public void OnSell(Character character)
        {
            if(IsEquipped) { Console.WriteLine($"| Not possible to sell!, {Name} is equipped! |"); return; }
            character.Currency += Price;
            character.Weapons.Remove(this);
            Console.WriteLine($"| {Name} is sold! |");
        }

        /// <summary>
        /// Calls when the weapon is picked
        /// </summary>
        /// <param name="character"></param>
        public virtual void OnPicked(Character character)
        {
            Console.WriteLine($"| Picked {name}! |");
        }

        /// <summary>
        /// Calls when the weapon is dropped
        /// </summary>
        /// <param name="character"></param>
        public void OnDropped(Character character)
        {
            if (IsEquipped) { Console.WriteLine($"| Not possible to drop!, {Name} is equipped! |"); return; }
            character.Weapons.Remove(this);
            Console.WriteLine($"| Dropped {name}! |");
        }

        /// <summary>
        /// Compare the weapon with another object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if(obj is Weapon weapon) return Name == weapon.Name;
            return false;
        }

        /// <summary>
        /// Describe the weapon
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            if (IsEquipped == true) sb.Append("[E]"); else sb.Append("[ ]");

            if (AttackType == AttackType.Close) sb.Append($"{Name} | Atk. : {AttackStat.Attack:F2} | ");
            else if(AttackType == AttackType.Long) sb.Append($"{Name} | Rng Atk. : {AttackStat.RangeAttack:F2} | ");
            else if (AttackType == AttackType.Magic) sb.Append($"{Name} | Mag Atk. : {AttackStat.MagicAttack:F2} | ");
            sb.Append($"가격 : {Price} | {Rarity}");
            return sb.ToString();
        }
    }
    /// <summary>
    /// Sword -> Close Range Attack Stat
    /// </summary>
    class Sword : Weapon
    {
        // Constructor
        public Sword(string name, AttackStat attackStat, int price, Rarity rarity) : base(name, attackStat, price, rarity)
        {
            AttackType = AttackType.Close;
        }
        public Sword(Sword sword) : base(sword.Name, sword.AttackStat, sword.Price, sword.Rarity)
        {
            AttackType = sword.AttackType;
        }

        [JsonConstructor]
        public Sword(string name, AttackStat attackStat, int price, Rarity rarity, AttackType attackType, ItemCategory category, bool isEquipped)
            : base(name, attackStat, price, rarity)
        {
            AttackType = attackType;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the weapon is purchased, adds the sword to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Weapons.Add(new Sword(this));
        }

        /// <summary>
        /// Calls when the weapon is picked, adds the sword to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Weapons.Add(new Sword(this));
        }
    }
    /// <summary>
    /// Bow -> Range Attack Stat
    /// </summary>
    class Bow : Weapon
    {
        public Bow(string name, AttackStat attackStat, int price, Rarity rarity) : base(name, attackStat, price, rarity)
        {
            AttackType = AttackType.Long;
        }
        public Bow(Bow bow) : base(bow.Name, bow.AttackStat, bow.Price, bow.Rarity)
        {
            AttackType = bow.AttackType;
        }

        [JsonConstructor]
        public Bow(string name, AttackStat attackStat, int price, Rarity rarity, AttackType attackType, ItemCategory category, bool isEquipped)
            : base(name, attackStat, price, rarity)
        {
            AttackType = attackType;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the weapon is purchased, adds the bow to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Weapons.Add(new Bow(this));
        }

        /// <summary>
        /// Calls when the weapon is picked, adds the bow to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Weapons.Add(new Bow(this));
        }
    }
    /// <summary>
    /// Staff -> Magic Attack Stat
    /// </summary>
    class Staff : Weapon
    {
        public Staff(string name, AttackStat attackStat, int price, Rarity rarity) 
            : base(name, attackStat, price, rarity)
        {
            AttackType = AttackType.Magic;
        }
        public Staff(Staff staff) 
            : base(staff.Name, staff.AttackStat, staff.Price, staff.Rarity)
        {
            AttackType = staff.AttackType;
        }

        [JsonConstructor]
        public Staff(string name, AttackStat attackStat, int price, Rarity rarity, AttackType attackType, ItemCategory category, bool isEquipped)
            : base(name, attackStat, price, rarity)
        {
            AttackType = attackType;
            Category = category;
            IsEquipped = isEquipped;
        }

        /// <summary>
        /// Calls when the weapon is purchased, adds the staff to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Weapons.Add(new Staff(this));
        }

        /// <summary>
        /// Calls when the weapon is picked, adds the staff to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Weapons.Add(new Staff(this));
        }
    }
    #endregion

    #region Consumable Class
    /// <summary>
    /// Base Consumable Items Class
    /// </summary>
    abstract class Consumables : IUseable, IPurchasable, ISellable, IPickable
    {
        // Field
        private string name;
        private float coefficient;
        private int price;
        private Rarity rarity;
        private ConsumableCategory consumableCategory;

        // Property
        public string Name { get { return name; } protected set { name = value; } }
        public float Coefficient { get { return coefficient; } protected set { coefficient = value; } }
        public int Price { get { return price; } protected set { price = value; } }
        public ItemCategory Category { get; protected set; } = ItemCategory.Consumable;
        public Rarity Rarity { get { return rarity; } protected set { rarity = value; } }
        public ConsumableCategory ConsumableCategory { get { return consumableCategory; } protected set { consumableCategory = value; } }
        public int TargetId { get; set; }

        // Constructor
        public Consumables(string name, float coefficient, int price, ConsumableCategory consumableCategory, Rarity rarity)
        {
            this.name = name; this.coefficient = coefficient; this.price = price; this.consumableCategory = consumableCategory; this.rarity = rarity;
        }
        public Consumables(string name, float coefficient, int price, ConsumableCategory consumableCategory, Rarity rarity, int targetId)
        {
            this.name = name; this.coefficient = coefficient; this.price = price; this.consumableCategory = consumableCategory; this.rarity = rarity;
            TargetId = targetId;
        }

        // Methods
        /// <summary>
        /// Calls when the consumable is used
        /// </summary>
        /// <param name="character"></param>
        public virtual void OnUsed(Character character)
        {
            GameManager.SelectedCharacter.Consumables.Remove(this);
        }

        /// <summary>
        /// This method is called by game manager when the gametime passes night.
        /// It removes all buffs from the character given by this item.
        /// </summary>
        /// <param name="character"></param>
        public void OnDeBuffed(Character character)
        {
            Console.WriteLine($"| {Name}의 효과가 사라졌습니다! |");
        }

        /// <summary>
        /// Calls when the consumable is purchased
        /// </summary>
        /// <param name="character"></param>
        public virtual void OnPurchase(Character character)
        {
            if (character.Currency < Price) { Console.WriteLine("| Not enough Money! |"); return; }
            Console.WriteLine($"| {name} is purchased |");
        }

        /// <summary>
        /// Calls when the consumable is sold
        /// </summary>
        /// <param name="character"></param>
        public void OnSell(Character character)
        {
            character.Currency += Price;
            character.Consumables.Remove(this);
            Console.WriteLine($"| {Name} is sold! |");
        }

        /// <summary>
        /// Calls when the consumable is picked
        /// </summary>
        /// <param name="character"></param>
        public virtual void OnPicked(Character character)
        {
            Console.WriteLine($"| Picked {name}! |");
        }

        /// <summary>
        /// Calls when the consumable is dropped
        /// </summary>
        /// <param name="character"></param>
        public void OnDropped(Character character)
        {
            character.Consumables.Remove(this);
            Console.WriteLine($"| Dropped {name}! |");
        }
    }

    /// <summary>
    /// Health Potion -> Restores health partially
    /// </summary>
    class HealthPotion : Consumables
    {
        // Constructor
        public HealthPotion(string name, float coefficient, int price, Rarity rarity = Rarity.Common) : base(name, coefficient, price, ConsumableCategory.IncreaseHealth, rarity) { }
        public HealthPotion(HealthPotion potion) : base(potion.Name, potion.Coefficient, potion.Price, potion.ConsumableCategory, potion.Rarity) { }

        [JsonConstructor]
        public HealthPotion(string name, float coefficient, int price, Rarity rarity, ConsumableCategory consumableCategory)
            : base(name, coefficient, price, consumableCategory, rarity)
        {
        }

        // Methods
        /// <summary>
        /// Calls when the health potion is used, restores health to the character.
        /// Its coefficient is multiplied by the rarity of the item.
        /// </summary>
        /// <param name="character"></param>
        public override void OnUsed(Character character)
        {
            if (character.Health >= character.MaxHealth) { Console.WriteLine("| Health is already full! |"); return; }

            base.OnUsed(character);
            character.OnHeal(Coefficient + (Coefficient * (int)Rarity * 0.1f));
        }

        /// <summary>
        /// Calls when the health potion is purchased, adds the health potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Consumables.Add(new HealthPotion(this));
        }

        /// <summary>
        /// Calls when the health potion is picked, adds the health potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Consumables.Add(new HealthPotion(this));
        }

        /// <summary>
        /// Describe the health potion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{Name} | 체력 회복 : {Coefficient} | 가격 : {Price} | {Rarity}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Magic Potion -> Restores magic point partially
    /// </summary>
    class MagicPotion : Consumables
    {
        // Constructor
        public MagicPotion(string name, float coefficient, int price, Rarity rarity) : base(name, coefficient, price, ConsumableCategory.IncreaseMagicPoint, rarity) { }
        public MagicPotion(MagicPotion potion) : base(potion.Name, potion.Coefficient, potion.Price, potion.ConsumableCategory, potion.Rarity) { }

        [JsonConstructor]
        public MagicPotion(string name, float coefficient, int price, Rarity rarity, ConsumableCategory consumableCategory) : base(name, coefficient, price, consumableCategory, rarity) { }

        // Methods
        /// <summary>
        /// Calls when the magic potion is used, restores magic point to the character.
        /// Its coefficient is multiplied by the rarity of the item.
        /// </summary>
        /// <param name="character"></param>
        public override void OnUsed(Character character)
        {
            if (character.MagicPoint >= character.MaxMagicPoint) { Console.WriteLine("| Magic is already full! |"); return; }
            
            base.OnUsed(character);
            character.OnMagicPointHeal(Coefficient + (Coefficient * (int)Rarity * 0.1f));
        }

        /// <summary>
        /// Calls when the magic potion is purchased, adds the magic potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Consumables.Add(new MagicPotion(this));
        }

        /// <summary>
        /// Calls when the magic potion is picked, adds the magic potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Consumables.Add(new MagicPotion(this));
        }

        /// <summary>
        /// Describe the magic potion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{Name} | 마력 회복 : {Coefficient} | 가격 : {Price} | {Rarity}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Attack Buff Potion -> Buffs Attack Parameters until the day passes.
    /// </summary>
    class AttackBuffPotion : Consumables
    {
        // Field
        private AttackStat attackStat;

        // Property
        public AttackStat AttackStat { get { return attackStat; } protected set { attackStat = value; } }

        // Constructor
        public AttackBuffPotion(string name, float coefficient, int price, Rarity rarity, int targetId)
            : base(name, coefficient, price, ConsumableCategory.IncreaseAttack, rarity, targetId)
        {
            attackStat = new AttackStat(coefficient, coefficient, coefficient);
        }
        public AttackBuffPotion(AttackBuffPotion potion) : base(potion.Name, potion.Coefficient, potion.Price, potion.ConsumableCategory, potion.Rarity, potion.TargetId)
        {
            attackStat = new(potion.AttackStat);
        }

        [JsonConstructor]
        public AttackBuffPotion(string name, float coefficient, int price, Rarity rarity, ConsumableCategory consumableCategory, int targetId)
            : base(name, coefficient, price, consumableCategory, rarity, targetId)
        {
            attackStat = new AttackStat(coefficient, coefficient, coefficient);
        }

        // Methods
        /// <summary>
        /// Calls when the attack buff potion is used, buffs attack to the character.
        /// </summary>
        /// <param name="character"></param>
        public override void OnUsed(Character character)
        {
            TargetId = character.Id;
            GameManager.Exposables.Enqueue(this);

            base.OnUsed(character);
        }

        /// <summary>
        /// Calls when the attack buff potion is purchased, adds the attack buff potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Consumables.Add(new AttackBuffPotion(this));
        }

        /// <summary>
        /// Calls when the attack buff potion is picked, adds the attack buff potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Consumables.Add(new AttackBuffPotion(this));
        }

        /// <summary>
        /// Describe the attack buff potion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{Name} | ")
              .Append($"공격력 증가 : {AttackStat.Attack} | ")
              .Append($"가격 : {Price} | {Rarity}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Defend Buff Potion -> Buffs Defend Parameters until the day passes.
    /// </summary>
    class DefendBuffPotion : Consumables
    {
        // Field
        private DefendStat defendStat;

        // Property
        public DefendStat DefendStat { get { return defendStat; } protected set { defendStat = value; } }

        // Constructor
        public DefendBuffPotion(string name, float coefficient, int price, Rarity rarity, int targetId)
            : base(name, coefficient, price, ConsumableCategory.IncreaseDefence, rarity, targetId)
        {
            defendStat = new DefendStat(coefficient, coefficient, coefficient);
        }
        public DefendBuffPotion(DefendBuffPotion potion) : base(potion.Name, potion.Coefficient, potion.Price, potion.ConsumableCategory, potion.Rarity, potion.TargetId)
        {
            defendStat = new(potion.DefendStat);
        }

        [JsonConstructor]
        public DefendBuffPotion(string name, float coefficient, int price, Rarity rarity, ConsumableCategory consumableCategory, int targetId)
            : base(name, coefficient, price, consumableCategory, rarity, targetId)
        {
            defendStat = new DefendStat(coefficient, coefficient, coefficient);
        }

        // Methods
        /// <summary>
        /// Calls when the defend buff potion is used, buffs defend to the character.
        /// </summary>
        /// <param name="character"></param>
        public override void OnUsed(Character character)
        {
            TargetId = character.Id;
            GameManager.Exposables.Enqueue(this);

            base.OnUsed(character);
        }

        /// <summary>
        /// Calls when the defend buff potion is purchased, adds the defend buff potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Consumables.Add(new DefendBuffPotion(this));
        }

        /// <summary>
        /// Calls when the defend buff potion is picked, adds the defend buff potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Consumables.Add(new DefendBuffPotion(this));
        }

        /// <summary>
        /// Describe the defend buff potion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{Name} | ")
              .Append($"방어력 증가 : {DefendStat.Defend} | ")
              .Append($"가격 : {Price} | {Rarity}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// All Parameter Buff Potion -> Buffs All Parameters until the day passes.
    /// </summary>
    class AllBuffPotion : Consumables
    {
        // Field
        private AttackStat attackStat;
        private DefendStat defendStat;

        public AttackStat AttackStat { get { return attackStat; } protected set { attackStat = value; } }
        public DefendStat DefendStat { get { return defendStat; } protected set { defendStat = value; } }

        // Constructor
        public AllBuffPotion(string name, float coefficient, int price, Rarity rarity, int targetId)
            : base(name, coefficient, price, ConsumableCategory.IncreaseAllStat, rarity, targetId)
        {
            attackStat = new AttackStat(coefficient, coefficient, coefficient);
            defendStat = new DefendStat(coefficient, coefficient, coefficient);
        }
        public AllBuffPotion(AllBuffPotion potion) : base(potion.Name, potion.Coefficient, potion.Price, potion.ConsumableCategory, potion.Rarity, potion.TargetId)
        {
            attackStat = new(potion.AttackStat);
            defendStat = new(potion.DefendStat);
        }

        [JsonConstructor]
        public AllBuffPotion(string name, float coefficient, int price, Rarity rarity, ConsumableCategory consumableCategory, int targetId)
            : base(name, coefficient, price, consumableCategory, rarity, targetId)
        {
            attackStat = new AttackStat(coefficient, coefficient, coefficient);
            defendStat = new DefendStat(coefficient, coefficient, coefficient);
        }

        // Methods
        /// <summary>
        /// Calls when the all buff potion is used, buffs all parameters to the character.
        /// </summary>
        /// <param name="character"></param>
        public override void OnUsed(Character character)
        {
            TargetId = character.Id;
            GameManager.Exposables.Enqueue(this);

            base.OnUsed(character);
        }

        /// <summary>
        /// Calls when the all buff potion is purchased, adds the all buff potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPurchase(Character character)
        {
            base.OnPurchase(character);
            if (character.Currency < Price) { return; }
            character.Currency -= Price;
            character.Consumables.Add(new AllBuffPotion(this));
        }

        /// <summary>
        /// Calls when the all buff potion is picked, adds the all buff potion to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.Consumables.Add(new AllBuffPotion(this));
        }

        /// <summary>
        /// Describe the all buff potion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{Name} | ")
              .Append($"모든 스텟 증가 : {AttackStat.Attack:F2} | ")
              .Append($"가격 : {Price}  | {Rarity}");
            return sb.ToString();
        }
    }
    #endregion

    #region ImportantItem Class

    /// <summary>
    /// Base Important Item Class
    /// </summary>
    abstract class ImportantItem : IPickable, ISellable
    {
        // Field
        private string name;
        private int price;
        private Rarity rarity;

        // Property
        public string Name { get { return name; } protected set { name = value; } }
        public int Price { get { return price; } protected set { price = value; } }
        public Rarity Rarity { get { return rarity; } protected set { rarity = value; } }

        // Constructor
        public ImportantItem(string name, int price, Rarity rarity)
        {
            this.name = name;
            this.price = price;
            this.rarity = rarity;
        }

        // Methods
        public virtual void OnPicked(Character character)
        {
            Console.WriteLine($"| Picked {Name}! |");
        }

        public void OnDropped(Character character)
        {
            character.ImportantItems.Remove(this);
            var quests = QuestManager.GetContractedQuests_CollectItem(GetType().Name);
            foreach (var quest in quests) { quest.OnProgress(character); }
            Console.WriteLine($"| {Name} is dropped! |");
        }

        public void OnSell(Character character)
        {
            character.Currency += Price;
            character.ImportantItems.Remove(this);
            var quests = QuestManager.GetContractedQuests_CollectItem(GetType().Name);
            foreach (var quest in quests) { quest.OnProgress(character); }
            Console.WriteLine($"| {Name} is sold! |");
        }
    }

    /// <summary>
    /// Goblin Ear -> Important Item
    /// </summary>
    class GoblinEar : ImportantItem
    {
        [JsonConstructor]
        public GoblinEar(string name, int price, Rarity rarity) : base(name, price, rarity) { }
        public GoblinEar(GoblinEar goblinEar) : base(goblinEar.Name, goblinEar.Price, goblinEar.Rarity) { }

        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.ImportantItems.AddLast(new GoblinEar(this));
            var quests = QuestManager.GetContractedQuests_CollectItem(GetType().Name);
            foreach (var quest in quests) { quest.OnProgress(character); }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{Name} | 가격 : {Price} | {Rarity}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Goblin Eye -> Important Item
    /// </summary>
    class GoblinEye : ImportantItem
    {
        [JsonConstructor]
        public GoblinEye(string name, int price, Rarity rarity) : base(name, price, rarity) { }
        public GoblinEye(GoblinEye goblinEye) : base(goblinEye.Name, goblinEye.Price, goblinEye.Rarity) { }

        public override void OnPicked(Character character)
        {
            base.OnPicked(character);
            character.ImportantItems.AddLast(new GoblinEye(this));
            var quests = QuestManager.GetContractedQuests_CollectItem(GetType().Name);
            foreach (var quest in quests) { quest.OnProgress(character); }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{Name} | 가격 : {Price} | {Rarity}");
            return sb.ToString();
        }
    }

    #endregion
}
