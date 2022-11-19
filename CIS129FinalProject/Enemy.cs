class Enemy
{
    public bool IsAlive = true;
    public int HP;

    public void TakeDamage(int hp)
    {
        if (HP - hp > 0) HP = HP - hp;
        else if (HP < 0) IsAlive = false;
    }
}
class GoblinEnemy : Enemy
{
    public readonly string Name = "Goblin";
    public new int HP = 3;
    public readonly string AttackName = "Body Slam";
    public readonly int Damage = 2;
}

class OrcEnemy : Enemy
{
    public readonly string Name = "Orc";
    public new int HP = 5;
    public readonly string AttackName = "Cleave";
    public readonly int Damage = 3;
}

class BansheeEnemy : Enemy
{
    public readonly string Name = "Banshee";
    public new int HP = 8;
    public readonly string AttackName = "Screech";
    public readonly int Damage = 5;
}