using System.IO;
//string header = "TicketID, Summary, Status, Priority, Submitter, Assigned, Watching";

//My code didn't really fit`what this assignment needed, and since this assignment more interested in LINQ, I figured that reusing your provided code would be fine.
string scrubbedFile = FileScrubber.ScrubMovies("Tickets.csv");
TicketFile ticketFile = new TicketFile(scrubbedFile);


List<Ticket> ticketList = new List<Ticket>();
Ticket newTicket = new Ticket("1", "This is a bug ticket", "Open", "High", "Drew Kjell", "Jane Doe", "Drew Kjell|John Smith|Bill Jones","???");
ticketList.Add(newTicket);
//string entry "1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones";

StreamWriter sw = new StreamWriter("Tickets.csv", append: true);
//sw.WriteLine(header);
sw.WriteLine(ticketList[0].returnString());

Console.ForegroundColor = ConsoleColor.Magenta;
System.Console.WriteLine("Enter 'ST' to search by status");
System.Console.WriteLine("Enter 'PR' to search by priority");
System.Console.WriteLine("Enter 'SU' to search by submitter");
string readLine = Console.ReadLine();
System.Console.WriteLine("Enter search term");
string search = Console.ReadLine();
if(readLine.ToLower() == "st"){
    System.Console.WriteLine("Results:");
    var term = ticketFile.Movies.Where(m => m.status.Contains(search)).Select(m => m.ticketID);
    foreach(string t in term)
    {
        System.Console.WriteLine($"   ID: {t}");
    }
    Console.WriteLine($"{term.Count()} matches retrieved.");
}else if(readLine.ToLower() == "pr"){
    System.Console.WriteLine("Results:");
    var term = ticketFile.Movies.Where(m => m.priority.Contains(search)).Select(m => m.ticketID);
    foreach(string t in term)
    {
        System.Console.WriteLine($"   ID: {t}");
    }
    Console.WriteLine($"{term.Count()} matches retrieved.");
}else if(readLine.ToLower() == "su"){
    System.Console.WriteLine("Results:");
    var term = ticketFile.Movies.Where(m => m.submitter.Contains(search)).Select(m => m.ticketID);
    foreach(string t in term)
    {
        System.Console.WriteLine($"   ID: {t}");
    }
    Console.WriteLine($"{term.Count()} matches retrieved.");
}
//I never had a proper add feature.
Console.ForegroundColor = ConsoleColor.White;
sw.Close();
