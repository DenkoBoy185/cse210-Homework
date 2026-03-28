using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video video1 = new Video("10 Tips to Master C# in 2024", "CodeWithMosh", 732);
        video1.AddComment(new Comment("Alice M.", "This tutorial saved my semester, thank you!"));
        video1.AddComment(new Comment("DevJake99", "The section on generics was super clear."));
        video1.AddComment(new Comment("Sarah K.", "Could you do one on async/await next?"));
        videos.Add(video1);

        // --- Video 2 ---
        Video video2 = new Video("Building REST APIs with ASP.NET Core", "TechLead", 1845);
        video2.AddComment(new Comment("Omar S.", "Best API tutorial I have found online."));
        video2.AddComment(new Comment("Jenny Liu", "The authentication part confused me a bit."));
        video2.AddComment(new Comment("BackendBob", "Followed along perfectly, works great!"));
        videos.Add(video2);

        // --- Video 3 ---
        Video video3 = new Video("Object-Oriented Design Patterns Explained", "CleanCoder", 2140);
        video3.AddComment(new Comment("ProgrammerPete", "Strategy pattern finally makes sense now."));
        video3.AddComment(new Comment("Mei Zhang", "Great visuals, loved the diagrams."));
        video3.AddComment(new Comment("Carlos R.", "Would love a follow-up on SOLID principles."));
        videos.Add(video3);

        // --- Display all videos ---
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title:    {video.GetTitle()}");
            Console.WriteLine($"Author:   {video.GetAuthor()}");
            Console.WriteLine($"Length:   {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("----------------------------------------");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}