
using Soup.Manga.Objects;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Soup.Manga.Logic
{
    public class MangaService
    {
        private string _path = @"C:\users\Milan\Desktop\MangaTest\mangaTest";
        public List<Soup.Manga.Objects.Manga> GetMangas()
        {
            List<Soup.Manga.Objects.Manga> mangaList;
            if (File.Exists(_path))
            {
            var json = File.ReadAllText(_path);    
            mangaList = System.Text.Json.JsonSerializer.Deserialize<List<Objects.Manga>>(json);
            }
            else
            {
                mangaList = new()
                {
                    new Objects.Manga
                    {
                      Id = 1, Name = "TestVolume"
                    }
                };
               SaveManga(mangaList);
            }
            return mangaList;
        }

        public void removeManga(Objects.Manga manga)
        {
            List<Objects.Manga> mangaList = GetMangas();
            mangaList.Remove(manga);
            SaveManga(mangaList);
        }

        private void SaveManga(List<Objects.Manga> mangaList)
        {
            var json = JsonSerializer.Serialize(mangaList);
            File.WriteAllText(_path, json);
        }
        public void addManga(Objects.Manga manga)
        {
            List<Objects.Manga> mangaList = GetMangas();
            mangaList.Add(manga);
            SaveManga(mangaList);
        }

        public void UpdateManga(Objects.Manga manga)
        {
            List<Objects.Manga> mangaList = GetMangas();
            Objects.Manga toUpdateManga = mangaList.FirstOrDefault(m => m.Id == manga.Id);
            mangaList.Remove(toUpdateManga);
            mangaList.Add(manga);
            SaveManga(mangaList);
        }

        public Objects.Manga GetMangaById(int id)
        {
            return GetMangas().FirstOrDefault(m => m.Id == id);   
        }
    }
}
