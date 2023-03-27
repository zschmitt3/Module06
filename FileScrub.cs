using NLog;
public static class FileScrubber
{
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    public static string ScrubMovies(string readFile)
    {
        try
        {
            // determine name of writeFile
            string ext = readFile.Split('.').Last();
            string writeFile = readFile.Replace(ext, $"scrubbed.{ext}");
            // if writeFile exists, the file has already been scrubbed
            if (File.Exists(writeFile))
            {
                // file has already been scrubbed
                logger.Info("File already scrubbed");
            }
            else
            {
                // file has not been scrubbed
                logger.Info("File scrub started");
                // open write file
                StreamWriter sw = new StreamWriter(writeFile);
                // open read file
                StreamReader sr = new StreamReader(readFile);
                // remove first line - column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    // create instance of Movie class
                    Ticket movie = new Ticket();
                    string line = sr.ReadLine();
                    // look for quote(") in string
                    // this indicates a comma(,) or quote(") in movie title
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma or quote in movie title
                        // movie details are separated with comma(,)
                        string[] movieDetails = line.Split(',');
                        movie.ticketID = movieDetails[0];
                        movie.summary = movieDetails[1];
                        movie.status = movieDetails[2];
                        movie.priority = movieDetails[3];
                        movie.submitter = movieDetails[4];
                        movie.assigned = movieDetails[5];
                        movie.watching = movieDetails[6];
                        movie.severity = movieDetails[7];
                    }
                    sw.WriteLine($"{movie.ticketID},{movie.summary},{movie.status},{movie.priority},{movie.submitter},{movie.assigned},{movie.watching},{movie.severity}");
                }
                sw.Close();
                sr.Close();
                logger.Info("File scrub ended");
            }
            return writeFile;
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
        return "";
    }
}