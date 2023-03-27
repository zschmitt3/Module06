using NLog;

public class TicketFile
{
    // public property
    public string filePath { get; set; }
    public List<Ticket> Movies { get; set; }
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    // constructor is a special method that is invoked
    // when an instance of a class is created
    public TicketFile(string movieFilePath)
    {
        filePath = movieFilePath;
        Movies = new List<Ticket>();

        // to populate the list with data, read from the data file
        try
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                // create instance of Movie class
                Ticket movie = new Ticket();
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                    // no quote = no comma in movie title
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
                Movies.Add(movie);
            }
            // close file when done
            sr.Close();
            logger.Info("Movies in file {Count}", Movies.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }

   }