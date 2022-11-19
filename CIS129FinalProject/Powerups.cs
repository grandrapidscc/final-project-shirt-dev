class Powerup
{
    public bool IsUsed = false;
}

class HealthPotionPowerup : Powerup
{
    public string Name = "Health Potion";
    public int HP = 10;
    public int MP = 0;
}

class MagickaPotionPowerup : Powerup
{
    public string name = "Magicka Potion";
    public int HP = 0;
    public int MP = 10;
}