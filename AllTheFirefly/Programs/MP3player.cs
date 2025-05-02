using AllTheFirefly.Main;
using NAudio.Wave;

namespace AllTheFirefly.Programs
{
    class MP3player : IProgram
    {

        int iteration = 0;
        bool wasError = false;

        public void Draw()
        {
            Console.CursorVisible = true;
            if (wasError)
            {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Произошла какая-то ошибка! Попробуйте снова, или обратитесь в техподдержку.");
                iteration++;
                if (iteration >= FMain.FPS * 5)
                {
                    iteration = 0;
                    wasError = false;
                    FMain.inMenu = true;
                    NewsHandler.isNewsGo = true;
                }
            }
            else
            {
                try
                {
                    Console.SetCursorPosition(0, 1);
                    Oh.pr("Введите полный путь к файлу.");
                    string path1, path2;
                    if (!IH.cki.Key.Equals(ConsoleKey.Enter))
                    {
                        Console.WriteLine(IH.inputStr + "                                                                                                   ");
                    }
                    else
                    {
                        
                        path1 = IH.inputStr;
                        path2 = IH.inputStr;
                        IH.inputStr = "";
                        if (!(path1[path1.Length - 1] == 'v' && path1[path1.Length - 2] == 'a' && path1[path1.Length - 3] == 'w' && path1[path1.Length - 4] == '.'))
                        {
                            path2 = path2.Replace(".mp3", ".wav");
                            ConvertMp3ToWav(path1, path2);
                        }

                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(path2);
                        player.Play();
                        FMain.inMenu = true;
                        NewsHandler.isNewsGo = true;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    wasError = true;
                }
            }
            Console.CursorVisible = false;
        }
        private void ConvertMp3ToWav(string _inPath_, string _outPath_)
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