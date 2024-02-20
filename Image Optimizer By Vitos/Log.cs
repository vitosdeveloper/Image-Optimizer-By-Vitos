using System;
using System.Diagnostics;

namespace Image_Optimizer_By_Vitos
{
    internal class Log
    {
        private readonly int ProgressLength;
        private int Progress;
        private readonly string InitialLog;
        private readonly int Stage;
        private bool ShowProgress = true;
        static readonly string FullProgressBar = "\n[██████████] 100%";
        private int NumOfBars = 0;
        string CurrentBar = "\n[          ]";
        double LastPercentage = 0;

        public Log(string initialLog, int progressLength, int stage)
        {
            Console.WriteLine(initialLog);
            InitialLog = initialLog;
            ProgressLength = progressLength;
            Progress = 0;
            Stage = stage;
            ProgressBar();
        }

        public static char ShowResizeOptions()
        {
            char pressedKey;
            List<char> optionsList = ['1', '2', '3', '4', '5', '6'];
            void ResolutionOptions(bool invalid = false)
            {
                Console.Clear();
                Console.WriteLine("Do you want to set both horizontal and vertical maximum sizes for the images?\n\n" +
                "1 - No, maintain their original resolutions.\n" +
                "2 - 480px\n" +
                "3 - 720px\n" +
                "4 - 1080px\n" +
                "5 - 1440px\n" +
                "6 - 2160px");
                if (invalid) Console.WriteLine("invalid key.");
                pressedKey = Console.ReadKey().KeyChar;
            };
            ResolutionOptions();
            while (!optionsList.Contains(pressedKey)) ResolutionOptions(true);
            Console.Clear();
            return pressedKey;
        }

        public void ProgressBar()
        {
            if (ShowProgress)
            {
                ShowProgress = false;
                Progress++;
                string oldInfo = "";
                if (Stage == 1) oldInfo += $"{ShowCompletedBackup()}\n";
                if (Stage == 2) oldInfo += $"{ShowCompletedFormating()}\n";
                double lastPercentage = Math.Floor((double)Progress / ProgressLength * 100);
                double currentNumOfBars = Math.Ceiling(LastPercentage / 10);
                if (NumOfBars < currentNumOfBars)
                {
                    NumOfBars++;
                    CurrentBar = $"{CurrentBar[..(NumOfBars + 1)]}█{CurrentBar[(NumOfBars + 2)..]}";
                }
                if (lastPercentage > LastPercentage)
                {
                    LastPercentage = lastPercentage;
                    Console.Clear();
                    Console.WriteLine($"{oldInfo}{InitialLog}{CurrentBar} {LastPercentage}%");
                    ShowProgress = true;
                    return;
                }
                ShowProgress = true;
            }
        }

        public static string ShowCompletedBackup()
        {
            return $"Backup completed{FullProgressBar}";
        }

        public static string ShowCompletedFormating()
        {
            return $"{ShowCompletedBackup()}\nAll images have been formated{FullProgressBar}";
        }

        public static void ShowCompleted(int totalImages, Stopwatch timer)
        {
            Console.Clear();
            Console.WriteLine($"{ShowCompletedFormating()}\nAll previous images have been deleted" +
                $"{FullProgressBar}" +
                $"\n\n{totalImages} images were formated to .webp in {timer.Elapsed.Minutes.ToString().PadLeft(2, '0')}:{timer.Elapsed.Seconds.ToString().PadLeft(2, '0')} min! " +
                "\nThank you for choosing this App!" +
                "\nCheck me out:" +
                "\nPortfolio: https://vitosdeveloper.vercel.app/" +
                "\nGithub: https://github.com/vitosnatios" +
                "Linkedin: https://www.linkedin.com/in/vitosnatios/" +
                "\n\n       %%%%%%%%%%%%%%              \r\n     %%%%%%%%%%%%%%%%%%            \r\n   %%%%%%%%%%%%%%%%%%%@%@          \r\n  %%%%%%%%%%%%%%%%%%%%%@@@         \r\n *%%%%%%%%%%%%%%%%%%@@@@@@         \r\n %%%%%%-%%%%%%%%%%%%@@@@@@         \r\n  %%%%%-%%%%+%%+%%@@@@@@@@         \r\n  %%%%%-%++#%%%%+%*@@@@*+@         \r\n  *#@+%%*=+++#%#@++#@%*+@@#        \r\n      =---+-+====+=#@@%@@@@        \r\n      ------=======@@@@@ @         \r\n        ==+=======*@@@@            \r\n          =====+**%@@@@@**         \r\n          *=*@@**@@@@@@@#**        \r\n        ===**@@@@@@@@@%****##      \r\n      ======*@@@@@@@*****#*##++    \r\n     #=====++@@@@@#*******+++++++  \r\n    +++#+++++@@@@#***##++++++*##++ \r\n   ++++++++++@@@+#++*+++++++++++++ \"");
            Console.ReadLine();
        }
    }
}
