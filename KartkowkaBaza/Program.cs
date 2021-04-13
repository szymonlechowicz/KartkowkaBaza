using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BazaKartkowka
{
    public class Song
    {
        public int id { set; get; }

        public string name { set; get; }

        public string title { set; get; }

        public override string ToString()
        {
            return "Wykonawca " + name + " wykonuje piosenke " + title;
        }
    }
    public class SongDb : DbContext
    {
        public DbSet<Song> Songs { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (SongDb db = new SongDb())
            {
                var song = new Song { name = "Future", title = "Mask off" };
                db.Songs.Add(song);
                db.SaveChanges();


                var songs = (from s in db.Songs select s).ToList<Song>();
                foreach (var s in songs)
                {
                    Console.WriteLine(s.ToString());
                }
            }
            Console.ReadLine();
        }
    }
}
