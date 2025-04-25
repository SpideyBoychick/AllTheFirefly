using NAudio.Wave;

namespace AllTheFirefly
{
    static class MP3player
    {
        public static void Start()
        {
            try
            {
                Console.CursorVisible = true;
                Oh.pr("Введите полный путь к файлу.");
                string path1 = Console.ReadLine();
                string path2 = path1;
                if (!(path1[path1.Length - 1] == 'v' && path1[path1.Length - 2] == 'a' && path1[path1.Length - 3] == 'w' && path1[path1.Length - 4] == '.'))
                {
                    path2 = path2.Replace(".mp3", ".wav");
                    ConvertMp3ToWav(path1, path2);
                }

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(path2);
                player.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла какая-то ошибка! Попробуйте снова, или обратитесь в техподдержку.");
                Thread.Sleep(3000);
            }
            Console.CursorVisible = false;
        }

        private static void ConvertMp3ToWav(string _inPath_, string _outPath_)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(_inPath_))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(_outPath_, pcm);
                }
            }
        }
    }
}