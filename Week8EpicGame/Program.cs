string folderPath = @"/Users/trewor-vincentploomipuu/Projects/Week8EpicGame/Week8EpicGame";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "magic wand", "plastic fork", "banana", "wooden sword", "Lego brick" };


string hero = GetRandomValueFromArray(heroes);
string heroweapon = GetRandomValueFromArray(weapon);
int heroHP = GetcharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} with {heroweapon} saves the day!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetcharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - hit(villain, villainStrikeStrength);
    villainHP = villainHP - hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string RandomStingFromArray = someArray[randomIndex];
    return RandomStingFromArray;
}


static int GetcharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int hit(string characterName, int CharacterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, CharacterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");

    }
    else if(strike == CharacterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }

    return strike;
    
}