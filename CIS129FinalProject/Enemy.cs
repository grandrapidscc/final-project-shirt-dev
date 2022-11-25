enum EnemyType
{
    Goblin,
    Orc,
    Banshee
}

class Enemy
{
    public EnemyType Type;
    public string Name;
    public int HP;
    public string AttackName;
    public int Damage;
    public bool IsAlive = true;

    public void TakeDamage(int hp)
    {
        if (HP - hp > 0) HP = HP - hp;
        else if (HP < 0) IsAlive = false;
    }

    public Enemy(EnemyType enemyType)
    {
        Type = enemyType;

        switch (Type)
        {
            case EnemyType.Goblin:
                Name = "Goblin";
                HP = 3;
                AttackName = "Body Slam";
                Damage = 2;
                break;
            case EnemyType.Orc:
                Name = "Orc";
                HP = 5;
                AttackName = "Cleave";
                Damage = 3;
                break;
            case EnemyType.Banshee:
                Name = "Banshee";
                HP = 8;
                AttackName = "Screech";
                Damage = 5;
                break;
            default:
                Name = "";
                HP = 0;
                AttackName = "";
                Damage = 0;
                break;
        }
    }
}
