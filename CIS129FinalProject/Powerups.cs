enum PowerupType
{
    HealthPotion,
    MagickaPotion,
}

class Powerup
{
    public PowerupType Type;
    public bool IsUsed = false;
    public string Name;
    public int HP;
    public int MP;

    public void Use(Player player)
    {
        player.HP += HP;
        player.MP += MP;
        IsUsed = true;
    }

    public Powerup(PowerupType powerupType)
    {
        Type = powerupType;

        switch (Type)
        {
            case PowerupType.HealthPotion:
                Name = "Health Potion";
                HP = 10;
                MP = 0;
                break;
            case PowerupType.MagickaPotion:
                Name = "Magicka Potion";
                HP = 0;
                MP = 10;
                break;
            default:
                Name = "";
                HP = 0;
                MP = 0;
                break;
        }
    }
}
