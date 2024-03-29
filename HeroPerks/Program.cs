using System;

namespace HeroPerks
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: dotnet run --project HeroPerks -- perksString");
                return;
            }

            string perksString = args[0].ToLower(); 

            int waterBreathingCount = GetOccurrences(perksString, 'w');
            int stealthCount = GetOccurrences(perksString, 's');
            int autoHealCount = GetOccurrences(perksString, 'a');
            int doubleJumpCount = GetOccurrences(perksString, 'd');

            PlayerPerks playerPerks = 0;  

            if (waterBreathingCount % 2 == 1)
            {
                playerPerks |= PlayerPerks.WaterBreathing;
            }

            if (stealthCount % 2 == 1)
            {
                playerPerks |= PlayerPerks.Stealth;
            }

            if (autoHealCount % 2 == 1)
            {
                playerPerks |= PlayerPerks.AutoHeal;
            }

            if (doubleJumpCount % 2 == 1)
            {
                playerPerks |= PlayerPerks.DoubleJump;
            }
            
            if (playerPerks == 0)
            {
                Console.WriteLine("No perks at all!");
            }
            else Console.WriteLine(playerPerks);

            if ((playerPerks & PlayerPerks.Stealth) != 0 && (playerPerks & PlayerPerks.DoubleJump) != 0)
            {
                Console.WriteLine("Silent jumper!");
            }
            if (autoHealCount == 0 || autoHealCount % 2 == 0)
            {
                Console.WriteLine("Not gonna make it!");
            }
        }

        static int GetOccurrences(string input, char target)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == target)
                {
                    count++;
                }
            }
            return count;
        }
    }
}