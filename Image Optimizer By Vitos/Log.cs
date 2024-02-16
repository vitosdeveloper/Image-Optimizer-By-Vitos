using System.Text;

namespace Image_Optimizer_By_Vitos
{
    internal class Log
    {
        private readonly int ProgressLength;
        private int Progress;
        private readonly string InitialLog;
        private readonly int Stage;

        public Log(string initialLog, int progressLength, int stage)
        {
            Console.WriteLine(initialLog);
            InitialLog = initialLog;
            ProgressLength = progressLength;
            Progress = 0;
            Stage = stage;
        }

        public void ProgressBar()
        {
            int percentage = GetPercentage();
            string bar = $"[          ] {percentage}%";
            AddProgressBar(bar);
            for (int i = Floor(percentage / 10); i > 0; i--) bar = AddProgressBar(bar);
            if (Stage == 1) ShowCompletedBackup();
            if (Stage == 2) ShowCompletedFormating();
            Console.WriteLine(InitialLog);
            Console.WriteLine(bar);
        }

        public static string AddProgressBar(string oldBar)
        {
            Console.Clear();
            StringBuilder stringBuilder = new(oldBar);
            int indexOfFirstSpace = oldBar.IndexOf(' ');
            if (indexOfFirstSpace != -1) stringBuilder[indexOfFirstSpace] = '█';
            return stringBuilder.ToString();
        }

        public void ProgressByOne() => Progress++;

        private int GetPercentage() => Floor((double)Progress / ProgressLength * 100);

        private static int Floor(double num) => (int)Math.Floor(num);

        public static void FullProgressBar() => Console.WriteLine("[██████████] 100%");

        public static void ShowCompletedBackup()
        {
            Console.WriteLine("Backup completed");
            Log.FullProgressBar();
        }

        public static void ShowCompletedFormating()
        {
            ShowCompletedBackup();
            Console.WriteLine("All images have been formated");
            Log.FullProgressBar();
        }

        public static void ShowCompleted(int totalImages)
        {
            ShowCompletedFormating();
            Console.WriteLine("All previous images have been deleted");
            Log.FullProgressBar();
            Console.WriteLine($"\n{totalImages} images were formated to .webp!");
            Console.WriteLine("\nThank you for choosing this App!");
            Console.WriteLine("\nCheck me out:");
            Console.WriteLine("Portfolio: https://vitosdeveloper.vercel.app/");
            Console.WriteLine("Github: https://github.com/vitosnatios");
            Console.WriteLine("Linkedin: https://www.linkedin.com/in/vitosnatios/");
            Console.WriteLine("       %%%%%%%%%%%%%%              \r\n     %%%%%%%%%%%%%%%%%%            \r\n   %%%%%%%%%%%%%%%%%%%@%@          \r\n  %%%%%%%%%%%%%%%%%%%%%@@@         \r\n *%%%%%%%%%%%%%%%%%%@@@@@@         \r\n %%%%%%-%%%%%%%%%%%%@@@@@@         \r\n  %%%%%-%%%%+%%+%%@@@@@@@@         \r\n  %%%%%-%++#%%%%+%*@@@@*+@         \r\n  *#@+%%*=+++#%#@++#@%*+@@#        \r\n      =---+-+====+=#@@%@@@@        \r\n      ------=======@@@@@ @         \r\n        ==+=======*@@@@            \r\n          =====+**%@@@@@**         \r\n          *=*@@**@@@@@@@#**        \r\n        ===**@@@@@@@@@%****##      \r\n      ======*@@@@@@@*****#*##++    \r\n     #=====++@@@@@#*******+++++++  \r\n    +++#+++++@@@@#***##++++++*##++ \r\n   ++++++++++@@@+#++*+++++++++++++ ");
            Console.ReadLine();
        }
    }
}
