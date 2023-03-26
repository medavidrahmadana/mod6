using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null || title.Length > 100)
            throw new ArgumentException("Judul video harus memiliki panjang maksimal 100 karakter dan tidak boleh null.");

        this.id = new Random().Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count > 10000000)
            throw new ArgumentException("Input penambahan play count maksimal 10.000.000 per panggilan method-nya.");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            throw new OverflowException("Jumlah penambahan play count melebihi batas tertinggi integer.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("=====| Messege diatas akan muncul jika Prekondisi dan Exception tidak sesuai ketentuan |=====");
        Console.WriteLine("Video ID: {0}", this.id);
        Console.WriteLine("Title: {0}", this.title);
        Console.WriteLine("Play count: {0}", this.playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prekondisi
        try
        {
            SayaTubeVideo video1 = new SayaTubeVideo(null);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            SayaTubeVideo video2 = new SayaTubeVideo("Tutorial Design By Contract – DAVID");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Exception
        SayaTubeVideo video3 = new SayaTubeVideo("Tutorial Design By Contract – DAVID GHOLI RAHMADANA");
        try
        {
            video3.IncreasePlayCount(100000000);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        for (int i = 0; i < 10; i++)
        {
            try
            {
                video3.IncreasePlayCount(1000000);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                break;
            }
        }

        video3.PrintVideoDetails();
    }
}
