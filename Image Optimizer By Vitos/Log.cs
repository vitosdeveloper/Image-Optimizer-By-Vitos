using System.Text;

namespace Image_Optimizer_By_Vitos
{
    internal class Log
    {
        private readonly int ProgressLength;
        private int Progress;
        private readonly string InitialLog;
        private readonly int Stage;
        private bool ShowProgress = true;

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
                static int Floor(double num) => (int)Math.Floor(num);
                int percentage = Floor((double)Progress / ProgressLength * 100);
                string oldInfo = "";
                if (Stage == 0) Console.Clear();
                if (Stage == 1) oldInfo += $"{ShowCompletedBackup(true)}\n";
                if (Stage == 2) oldInfo += $"{ShowCompletedFormating(true)}\n";
                string currentBar = $"\n[          ] {percentage}%";
                for (int i = Floor(percentage / 10); i > 0; i--) currentBar = AddProgressBar(currentBar);
                Console.WriteLine($"{oldInfo}{InitialLog}{currentBar}");
                ShowProgress = true;
            }
        }

        public static string AddProgressBar(string oldBar)
        {
            StringBuilder stringBuilder = new(oldBar);
            int indexOfFirstSpace = oldBar.IndexOf(' ');
            if (indexOfFirstSpace != -1) stringBuilder[indexOfFirstSpace] = '█';
            return stringBuilder.ToString();
        }

        public static string FullProgressBar() => "\n[██████████] 100%";

        public static string ShowCompletedBackup(bool clear = false)
        {
            if (clear) Console.Clear();
            return $"Backup completed{FullProgressBar()}";
        }

        public static string ShowCompletedFormating(bool clear = false)
        {
            if (clear) Console.Clear();
            return $"{ShowCompletedBackup()}\nAll images have been formated{FullProgressBar()}";
        }

        public static void ShowCompleted(int totalImages)
        {
            ;
            Console.WriteLine($"{ShowCompletedFormating(true)}\nAll previous images have been deleted" +
                $"{FullProgressBar()}" +
                $"\n\n{totalImages} images were formated to .webp!" +
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
